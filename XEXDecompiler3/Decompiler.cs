using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectedGraphLibWV;

namespace XEXDecompiler3
{
    public static class Decompiler
    {
        public static ASMFile asm;
        public static SubFunction sub;
        public static Graph graph;
        public static int level;
        public static bool simplefySequences = true;
        public static bool simplefyIfThen = true;
        public static bool simplefyIfThenElse = true;
        public static bool simplefyOneBlockWhile = true;
        public static bool simplefyLoopParts = true;
        public static bool simplefySimpleLoops = true;
        public static bool simplefyACSESERegions = true;
        public static bool saveMidStepGraphs = true;
        public static StringBuilder reductionLog;
        public static int reductionCounter;

        public static string Decompile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string line in sub.rawLines)
                sb.AppendLine(line);
            if (level == 0) return sb.ToString();

            sb = new StringBuilder();
            List<string> buff = Step01Normalize(new List<string>(sub.rawLines));
            foreach (string line in buff)
                sb.AppendLine(line);
            if (level == 1) return sb.ToString();

            sb = new StringBuilder();
            List<CodeBlock> blocks = Step02MakeBlocks(buff);
            foreach (CodeBlock block in blocks)
                sb.AppendLine(block.ToString(0));
            if (level == 2) return sb.ToString();

            sb = new StringBuilder();
            blocks = Step03ResolveJumps(blocks);
            foreach (CodeBlock block in blocks)
                sb.AppendLine(block.ToString(0));
            if (level == 3) return sb.ToString();

            Step04CreateGraph(blocks);
            if (level == 4) return sb.ToString();
            graph.Save("temp.gr");
            reductionLog = new StringBuilder();
            reductionCounter = 0;
            Step05SimplefyGraph();
            sb.AppendLine();
            sb.AppendLine("Reduction Log");
            sb.AppendLine("=============");
            sb.AppendLine(reductionLog.ToString());
            if (level == 5) return sb.ToString();

            if (level == 6 && graph.nodes.Count == 1)
            {
                sb = new StringBuilder();
                sb.Append(Step06CompileOut(blocks));
                graph.Load("temp.gr");
                return sb.ToString();
            }

            return sb.ToString();
        }

        public static List<string> Step01Normalize(List<string> input)
        {
            List<string> result = new List<string>();
            foreach (string line in input)
                if (line.StartsWith("\t\t") && !line.Trim().StartsWith("#") && !line.Trim().StartsWith("."))
                    result.Add(NormalizeLine(line.Substring(2)));
                else if (line.StartsWith("loc_") || line.StartsWith("locret_") || line.StartsWith("off_"))
                    result.Add(line.Split(':')[0].Trim());
            return result;
        }

        public static List<CodeBlock> Step02MakeBlocks(List<string> input)
        {

            List<CodeBlock> result = new List<CodeBlock>();
            List<string> lines = new List<string>();
            int start = 0;
            long offset = asm.funcOffsets[sub.name];
            for (int i = 0; i < input.Count; i++)
            {
                if (isBranchOPC(input[i]))
                {
                    for (int j = start; j <= i; j++)
                        lines.Add(input[j]);
                    start = i + 1;
                    if (lines.Count > 0)
                    {
                        result.Add(new CodeBlock(lines, ref offset, asm.sections, result.Count));
                        lines = new List<string>();
                    }
                }
                else if (input[i].StartsWith("loc_") || input[i].StartsWith("locret_") || input[i].StartsWith("off_"))
                {
                    for (int j = start; j < i; j++)
                        lines.Add(input[j]);
                    start = i;
                    if (lines.Count > 0)
                    {
                        result.Add(new CodeBlock(lines, ref offset, asm.sections, result.Count));
                        lines = new List<string>();
                    }
                }
            }
            if (start < input.Count)
            {
                for (int j = start; j < input.Count; j++)
                    lines.Add(input[j]);
                if (lines.Count > 0)
                {
                    result.Add(new CodeBlock(lines, ref offset, asm.sections, result.Count));
                    lines = new List<string>();
                }
            }
            return result;
        }

        public static List<CodeBlock> Step03ResolveJumps(List<CodeBlock> input)
        {
            foreach (CodeBlock block in input)
            {
                CodeLine line = null;
                if (block.codeLines.Count > 0)
                    line = block.codeLines[block.codeLines.Count - 1];
                if (block.canBranch || block.alwaysBranch)
                {
                    string[] parts = line.text.Split(' ');
                    foreach (string part in parts)
                        if (part.StartsWith("loc_") || part.StartsWith("locret_"))
                        {
                            bool found = false;
                            for (int i = 0; i < input.Count; i++)
                                if (input[i].isLocation && input[i].codeLines[0].text.StartsWith(part.Trim()))
                                {
                                    block.targetIndex = i;
                                    found = true;
                                    break;
                                }
                            if (found)
                                break;
                        }
                }
            }
            return input;
        }

        public static void Step04CreateGraph(List<CodeBlock> input)
        {
            graph = new Graph();
            for (int i = 0; i < input.Count; i++)
            {
                CodeBlock block = input[i];
                graph.nodes.Add(new Node(input[i]));
                string edgeA = "", edgeB = "";
                if (block.canBranch)
                {
                    edgeA = "false";
                    edgeB = "true";
                }
                if (block.alwaysBranch)
                {
                    edgeA = "after branch";
                    edgeB = "branch";
                }
                if ((i < input.Count - 1) && (!block.alwaysBranch || block.retBranch))
                    graph.edges.Add(new Edge(i, i + 1, edgeA));
                if ((block.canBranch || block.alwaysBranch) && block.targetIndex != -1)
                    graph.edges.Add(new Edge(i, block.targetIndex, edgeB));
            }
        }

        public static void Step05SimplefyGraph()
        {
            bool found = true;
            while (found)
            {
                found = false;
                if (simplefyOneBlockWhile && FindSimpleWhile()) { found = true; CheckMidSave(); }
                if (simplefySequences && FindSequences()) { found = true; CheckMidSave(); }
                if (simplefyIfThen && FindIfThen()) { found = true; CheckMidSave(); }
                if (simplefyIfThenElse && FindIfThenElse()) { found = true; CheckMidSave(); }
                if (simplefyLoopParts && FindLoopParts()) { found = true; CheckMidSave(); }
                if (simplefySimpleLoops && FindSimpleLoops()) { found = true; CheckMidSave(); }
                if (!found && simplefyACSESERegions && FindACSESERegions()) { found = true; CheckMidSave(); };
            }
        }

        public static string Step06CompileOut(List<CodeBlock> blocks)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("void " + sub.name + "()");
            sb.AppendLine("{");
            sb.Append(PrintBlock(graph.nodes[0].data, 1));
            sb.AppendLine("}");
            foreach (CodeBlock block in blocks)
            {
                sb.AppendLine();
                sb.AppendLine("void Block" + block.myIndex + "()");
                sb.AppendLine("{");
                sb.AppendLine("\t_asm");
                sb.AppendLine("\t{");
                foreach (CodeLine line in block.codeLines)
                    sb.AppendLine("\t\t" + line.text);
                sb.AppendLine("\t}");
                sb.AppendLine("}");
            }
            return sb.ToString();
        }

        #region Helper

        public static string[] branchOPCs = XEXDecompiler3.Properties.Resources.branch_opcodes.Split(';');
        public static string[] branchRetOPCs = XEXDecompiler3.Properties.Resources.branch_returning_prefixes.Split(';');
        public static string[] uncondPre = XEXDecompiler3.Properties.Resources.uncond_prefixes.Split(';');

        public static string PrintBlock(object data, int tabs)
        {
            StringBuilder sb = new StringBuilder();
            string t = "";
            for (int i = 0; i < tabs; i++) t += "\t";
            if (data is CodeBlock)
                sb.AppendLine(t + PrintCodeBlock((CodeBlock)data) + ";");
            if (data is ABSBlock)
                sb.Append(PrintAbsBlock((ABSBlock)data, tabs));
            return sb.ToString();
        }

        public static string PrintCodeBlock(CodeBlock block)
        {            
            return "Block" + block.myIndex + "()";
        }

        public static string PrintAbsBlock(ABSBlock block, int tabs)
        {
            StringBuilder sb = new StringBuilder();
            List<object> list;
            string t = "";
            for (int i = 0; i < tabs; i++) t += "\t";
                switch (block.type)
                {
                    case ABSBlock.absType.SEQUENCE:
                        list = (List<object>)block.data;
                        sb.Append(PrintBlock(list[0], tabs));
                        sb.Append(PrintBlock(list[1], tabs));
                        break;
                    case ABSBlock.absType.SIMPLEWHILE:
                        sb.AppendLine(t + "while(" + PrintCodeBlock((CodeBlock)block.data) + ");");
                        break;
                    case ABSBlock.absType.BREAK:
                        sb.AppendLine(t + "if(" + PrintCodeBlock((CodeBlock)block.data) + ") break;");
                        break;
                    case ABSBlock.absType.CONTINUE:
                        sb.AppendLine(t + "if(" + PrintCodeBlock((CodeBlock)block.data) + ") continue;");
                        break;
                    case ABSBlock.absType.IFTHEN:
                        list = (List<object>)block.data;
                        sb.AppendLine(t + "if(!" + PrintCodeBlock((CodeBlock)list[0]) + ")");
                        sb.AppendLine(t + "{");
                        sb.Append(PrintBlock(list[1], tabs + 1));
                        sb.AppendLine(t + "}");
                        break;
                    case ABSBlock.absType.IFTHENELSE:
                        list = (List<object>)block.data;
                        sb.AppendLine(t + "if(" + PrintCodeBlock((CodeBlock)list[0]) + ")");
                        sb.AppendLine(t + "{");
                        sb.Append(PrintBlock(list[1], tabs + 1));
                        sb.AppendLine(t + "}");
                        sb.AppendLine(t + "else");
                        sb.AppendLine(t + "{");
                        sb.Append(PrintBlock(list[2], tabs + 1));
                        sb.AppendLine(t + "}");
                        break;
                    case ABSBlock.absType.WHILE:
                        list = (List<object>)block.data;
                        sb.AppendLine(t + "while(" + PrintCodeBlock((CodeBlock)list[0]) + ")");
                        sb.AppendLine(t + "{");
                        sb.Append(PrintBlock(list[1], tabs + 1));
                        sb.AppendLine(t + "}");
                        break;
                    case ABSBlock.absType.DOWHILE:
                        list = (List<object>)block.data;
                        sb.AppendLine(t + "do");
                        sb.AppendLine(t + "{");
                        sb.Append(PrintBlock(list[0], tabs + 1));
                        sb.AppendLine(t + "}");
                        sb.AppendLine(t + "while(" + PrintCodeBlock((CodeBlock)list[1]) + ")");
                        break;
                    case ABSBlock.absType.ACSESEREGION:
                        sb.Append(PrintAcSESEBlock(block, tabs));
                        break;
                    default:
                        break;
                }
            return sb.ToString();
        }

        public static string PrintAcSESEBlock(ABSBlock block, int tabs)
        {
            StringBuilder sb = new StringBuilder();
            string t = "";
            for (int i = 0; i < tabs; i++) t += "\t";
            ACSESERegion region = ((ACSESERegion)block.data);
            Graph gr = region.graph;
            List<int> order = gr.getTopogicalOrder();
            for (int i = 0; i < order.Count - 1; i++)
            {
                int idx = order[i];
                if (region.codeNodes.Contains(idx))
                {
                    List<List<int>> paths = gr.getAllReachingPaths(idx);
                    StringBuilder exp = new StringBuilder();
                    exp.Append(t + "if(");
                    if (paths.Count == 1)
                    {
                        exp.Append(ConditionPathToExpression(paths[0], region));
                        exp.AppendLine(")");
                    }
                    else
                    {
                        StringBuilder sb2 = new StringBuilder();
                        foreach (List<int> path in paths)
                        {
                            if (sb2.Length != 0)
                            {
                                sb2.AppendLine(" || ");
                                sb2.Append(t + "   ");
                            }
                            sb2.Append("(" + ConditionPathToExpression(path, region) + ")");
                        }
                        exp.AppendLine(sb2.ToString());
                        exp.AppendLine(t + "  )");
                    }
                    exp.AppendLine(t + "{");
                    exp.Append(PrintBlock(gr.nodes[idx].data, tabs + 1));
                    exp.AppendLine(t + "}");
                    sb.Append(exp.ToString());
                }
            }
            sb.Append(PrintBlock(region.graph.nodes[order[order.Count - 1]].data, tabs));
            return sb.ToString();
        }

        public static string ConditionPathToExpression(List<int> path, ACSESERegion region)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < path.Count - 1; i++)
            {
                if (region.decNodes.Contains(path[i]) && region.codeNodes.Contains(path[i + 1]))
                {
                    bool cond = false;
                    foreach (Edge e in region.graph.edges)
                        if (e.start == path[i] && 
                            e.end == path[i + 1] )
                        {
                            cond = e.text == "true";
                            break;
                        }
                    if (sb.Length != 0) sb.Append(" && ");
                    sb.Append((cond ? "" : "!") + "Block" + ((CodeBlock)(region.graph.nodes[path[i]].data)).myIndex + "()");
                }
            }
            return sb.ToString();
        }

        public static void CheckMidSave()
        {
            if (saveMidStepGraphs) graph.Save("MidStep" + (reductionCounter++).ToString("d8") + ".gr");
        }

        public static bool FindSimpleWhile()
        {
            List<int> order = graph.getOrder(true);
            for (int i = 0; i < order.Count(); i++)
            {
                int idx = order[i];
                List<int> childs = graph.getChildren(idx);
                List<int> parents = graph.getParents(idx);
                if (childs.Count == 2 && childs.Contains(idx))
                {
                    for (int j = 0; j < graph.edges.Count; j++)
                        if (graph.edges[j].start == idx &&
                            graph.edges[j].end == idx)
                        {
                            graph.edges.RemoveAt(j);
                            break;
                        }
                    ABSBlock abs = new ABSBlock(ABSBlock.absType.SIMPLEWHILE);
                    abs.data = graph.nodes[idx].data;
                    graph.nodes[idx].data = abs;
                    LogReduction("Simple While Reduction: " + idx);
                    return true;
                }
            }
            return false;
        }

        public static bool FindSequences()
        {
            List<int> order = graph.getOrder(true);
            for (int i = 0; i < order.Count(); i++)
            {
                int idx = order[i];
                List<int> childs = graph.getChildren(idx);
                if (childs.Count == 1 && childs[0] != idx)
                {
                    int idx2 = childs[0];
                    List<int> parents = graph.getParents(idx2);
                    List<int> childs2 = graph.getChildren(idx2);
                    if (parents.Count == 1 && childs2.Count < 2)
                    {
                        if (childs2.Count == 1 && (childs2[0] == idx || childs2[0] == idx2))
                            continue;
                        ABSBlock abs = new ABSBlock(ABSBlock.absType.SEQUENCE);
                        List<object> tmp = new List<object>();
                        tmp.Add(graph.nodes[idx].data);
                        tmp.Add(graph.nodes[idx2].data);
                        abs.data = tmp;
                        if (childs2.Count == 1)
                            foreach (Edge e in graph.edges)
                                if (e.start == idx2)
                                    e.start = idx;
                        graph.nodes[idx].data = abs;
                        graph.removeNode(idx2);
                        LogReduction("Sequence Reduction: " + idx + "<-" + idx2);
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool FindIfThen()
        {
            List<int> order = graph.getOrder(true);
            for (int i = 0; i < order.Count(); i++)
            {
                int idxHead = order[i];
                int idxThen, idxAfter;
                idxThen = idxAfter = -1;
                List<int> childs = graph.getChildren(idxHead);
                if (childs.Count == 2)
                {
                    List<int> parents0 = graph.getParents(childs[0]);
                    List<int> parents1 = graph.getParents(childs[1]);
                    if (parents0.Count == 1)
                    {
                        List<int> tmp = graph.getChildren(childs[0]);
                        if (tmp.Count == 1 && tmp[0] == childs[1])
                        {
                            idxThen = childs[0];
                            idxAfter = childs[1];
                        }
                    }
                    else if (parents1.Count == 1)
                    {
                        List<int> tmp = graph.getChildren(childs[1]);
                        if (tmp.Count == 1 && tmp[0] == childs[0])
                        {
                            idxThen = childs[1];
                            idxAfter = childs[0];
                        }
                    }
                    if (idxAfter != -1 && idxThen != -1 && idxAfter != idxHead)
                    {
                        ABSBlock abs = new ABSBlock(ABSBlock.absType.IFTHEN);
                        List<object> tmp = new List<object>();
                        tmp.Add(graph.nodes[idxHead].data);
                        tmp.Add(graph.nodes[idxThen].data);
                        abs.data = tmp;
                        graph.nodes[idxHead].data = abs;
                        graph.removeNode(idxThen);
                        LogReduction("If-Then Reduction: " + idxHead + "<-" + idxThen);
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool FindIfThenElse()
        {
            List<int> order = graph.getOrder(true);
            for (int i = 0; i < order.Count(); i++)
            {
                int idxHead = order[i];
                int idxThen, idxElse, idxAfter;
                idxThen = idxElse = idxAfter = -1;
                List<int> childs = graph.getChildren(idxHead);
                if (childs.Count == 2)
                {
                    List<int> parents0 = graph.getParents(childs[0]);
                    List<int> parents1 = graph.getParents(childs[1]);
                    List<int> childs0 = graph.getChildren(childs[0]);
                    List<int> childs1 = graph.getChildren(childs[1]);
                    if (parents0.Count == 1 && parents1.Count == 1 &&
                        childs0.Count == 1 && childs1.Count == 1 &&
                        childs0[0] == childs1[0])
                    {
                        foreach (Edge e in graph.edges)
                            if (e.start == idxHead && e.end == childs[0])
                            {
                                if (e.text == "true")
                                {
                                    idxThen = childs[0];
                                    idxElse = childs[1];
                                    idxAfter = childs0[0];
                                }
                                else if (e.text == "false")
                                {
                                    idxThen = childs[1];
                                    idxElse = childs[0];
                                    idxAfter = childs0[0];
                                }
                                break;
                            }
                        if (idxAfter != -1 && idxThen != -1 && idxElse != -1 && idxAfter != idxHead)
                        {
                            ABSBlock abs = new ABSBlock(ABSBlock.absType.IFTHENELSE);
                            List<object> tmp = new List<object>();
                            tmp.Add(graph.nodes[idxHead].data);
                            tmp.Add(graph.nodes[idxThen].data);
                            tmp.Add(graph.nodes[idxElse].data);
                            abs.data = tmp;
                            graph.nodes[idxHead].data = abs;
                            graph.edges.Add(new Edge(idxHead, idxAfter, "branch"));
                            if (idxThen > idxElse)
                            {
                                graph.removeNode(idxThen);
                                graph.removeNode(idxElse);
                            }
                            else
                            {
                                graph.removeNode(idxElse);
                                graph.removeNode(idxThen);
                            }
                            LogReduction("If-Then-Else Reduction: " + idxHead + "<-" + idxThen + ", " + idxHead + "<-" + idxElse);
                            return true;
                        }
                    }
                    if (parents0.Count == 1 && parents1.Count == 1 &&
                        childs0.Count == 0 && childs1.Count == 0)
                    {
                        foreach (Edge e in graph.edges)
                            if (e.start == idxHead && e.end == childs[0])
                            {
                                if (e.text == "true")
                                {
                                    idxThen = childs[0];
                                    idxElse = childs[1];
                                }
                                else if (e.text == "false")
                                {
                                    idxThen = childs[1];
                                    idxElse = childs[0];
                                }
                                break;
                            }
                        if (idxThen != -1 && idxElse != -1)
                        {
                            ABSBlock abs = new ABSBlock(ABSBlock.absType.IFTHENELSE);
                            List<object> tmp = new List<object>();
                            tmp.Add(graph.nodes[idxHead].data);
                            tmp.Add(graph.nodes[idxThen].data);
                            tmp.Add(graph.nodes[idxElse].data);
                            abs.data = tmp;
                            graph.nodes[idxHead].data = abs;
                            if (idxThen > idxElse)
                            {
                                graph.removeNode(idxThen);
                                graph.removeNode(idxElse);
                            }
                            else
                            {
                                graph.removeNode(idxElse);
                                graph.removeNode(idxThen);
                            }
                            LogReduction("If-Then-Else Reduction: " + idxHead + "<-" + idxThen + ", " + idxHead + "<-" + idxElse);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool FindLoopParts()
        {
            List<List<int>> scc = graph.getAllStronglyConnectedComponents();
            List<Loop> gLoops = new List<Loop>();
            foreach (List<int> component in scc)
                if (component.Count > 1)
                {
                    List<List<int>> loops = graph.getAllSimpleLoops(component);
                    foreach (List<int> loop in loops)
                        gLoops.Add(graph.getLoopInformation(loop));
                }
            List<int> order = graph.getOrder(true);
            for (int i = 0; i < order.Count(); i++)
            {
                int idx = order[i];
                foreach (Loop loop in gLoops)
                    if (!loop.isMultiExit)
                        foreach (LoopPart part in loop.body)
                            if (part.index == idx)
                            {
                                if (!part.hasOutsideEntry && !part.isTail && !part.isHeader && part.isContinue && !part.isBreak)
                                {
                                    List<int> childs = graph.getChildren(idx);
                                    if (childs.Count != 2)
                                        break;
                                    for (int j = 0; j < graph.edges.Count; j++)
                                        if (graph.edges[j].start == idx &&
                                           graph.edges[j].end == loop.header.index)
                                        {
                                            graph.edges.RemoveAt(j);
                                            break;
                                        }
                                    ABSBlock abs = new ABSBlock(ABSBlock.absType.CONTINUE);
                                    abs.data = graph.nodes[idx].data;
                                    graph.nodes[idx].data = abs;
                                    LogReduction("Continue Reduction: " + idx);
                                    return true;
                                }
                                if (!part.hasOutsideEntry && !part.isTail && !part.isHeader && !part.isContinue && part.isBreak)
                                {
                                    List<int> childs = graph.getChildren(idx);
                                    if (childs.Count != 2)
                                        break;
                                    bool isFirst = false;
                                    foreach (LoopPart part2 in loop.body)
                                        if (part2.index == childs[0])
                                        {
                                            isFirst = true;
                                            break;
                                        }
                                    if (isFirst)
                                    {
                                        for (int j = 0; j < graph.edges.Count; j++)
                                            if (graph.edges[j].start == idx &&
                                               graph.edges[j].end == childs[1])
                                            {
                                                graph.edges.RemoveAt(j);
                                                break;
                                            }
                                    }
                                    else
                                    {
                                        for (int j = 0; j < graph.edges.Count; j++)
                                            if (graph.edges[j].start == idx &&
                                               graph.edges[j].end == childs[0])
                                            {
                                                graph.edges.RemoveAt(j);
                                                break;
                                            }
                                    }
                                    ABSBlock abs = new ABSBlock(ABSBlock.absType.BREAK);
                                    abs.data = graph.nodes[idx].data;
                                    graph.nodes[idx].data = abs;
                                    LogReduction("Break Reduction: " + idx);
                                    return true;
                                }
                            }
            }
            return false;
        }

        public static bool FindSimpleLoops()
        {
            List<List<int>> scc = graph.getAllStronglyConnectedComponents();
            List<Loop> gLoops = new List<Loop>();
            foreach (List<int> component in scc)
                if (component.Count > 1)
                {
                    List<List<int>> loops = graph.getAllSimpleLoops(component);
                    foreach (List<int> loop in loops)
                        gLoops.Add(graph.getLoopInformation(loop));
                }
            List<int> order = graph.getOrder(true);
            for (int i = 0; i < order.Count(); i++)
            {
                int idxHead = order[i];
                foreach (Loop loop in gLoops)
                    if (loop.header.index == idxHead && !loop.isMultiExit && loop.body.Count == 1 && !loop.body[0].hasOutsideEntry)
                    {
                        int idxTail = loop.body[0].index;
                        ABSBlock abs;
                        if (loop.header.isBreak)
                        {
                            List<int> childs = graph.getChildren(idxTail);
                            if (childs.Count != 1)
                            {
                                ABSBlock abs2 = new ABSBlock(ABSBlock.absType.BREAK);
                                foreach (int child in childs)
                                    if (child != idxHead)
                                        graph.removeEdge(idxTail, child);
                                abs2.data = graph.nodes[idxTail].data;
                                graph.nodes[idxTail].data = abs2;
                                LogReduction("Break Reduction: " + idxTail);
                            }
                            abs = new ABSBlock(ABSBlock.absType.WHILE);
                            LogReduction("While Reduction: " + idxHead + "<-" + idxTail);
                        }
                        else
                        {
                            List<int> childs = graph.getChildren(idxTail);
                            if (childs.Count != 2)
                                continue;
                            foreach (int child in childs)
                                if (child != idxHead)
                                    graph.edges.Add(new Edge(idxHead, child, "branch"));
                            abs = new ABSBlock(ABSBlock.absType.DOWHILE);
                            LogReduction("Do-While Reduction: " + idxHead + "<-" + idxTail);
                        }
                        List<object> tmp = new List<object>();
                        tmp.Add(graph.nodes[idxHead].data);
                        tmp.Add(graph.nodes[idxTail].data);
                        abs.data = tmp;
                        graph.nodes[idxHead].data = abs;
                        graph.removeNode(idxTail);
                        return true;
                    }
            }
            return false;
        }

        public static bool FindACSESERegions()
        {
            List<List<int>> regions = graph.getAllSESERegions();
            for (int i = 0; i < regions.Count; i++)
            {
                bool containsOther = false;
                for (int j = 0; j < regions.Count; j++)
                    if (i != j && Helper.ListContained(regions[j], regions[i]))
                    {
                        containsOther = true;
                        break;
                    }
                if (containsOther) continue;
                Graph gr = graph.getCutOut(regions[i]);
                if (gr.isCyclic()) continue;
                gr.nodes[0] = new Node(gr.nodes[0].data, gr.nodes[0].srcId);
                ABSBlock abs = new ABSBlock(ABSBlock.absType.ACSESEREGION);
                abs.data = new ACSESERegion(gr);
                graph.nodes[regions[i][0]].data = abs;
                int first = regions[i][0];
                int last = regions[i][regions[i].Count - 1];
                if (graph.getChildren(last).Count > 0)
                    graph.edges.Add(new Edge(regions[i][0], graph.getChildren(last)[0], "branch"));
                regions[i].RemoveAt(0);
                regions[i].Sort();
                regions[i].Reverse();
                foreach (int j in regions[i])
                    graph.removeNode(j);
                LogReduction("ACSESE Region Reduction: " + first + "<-" + last);
                return true;
            }
            return false;
        }

        public static void LogReduction(string text)
        {
            reductionLog.AppendLine((reductionCounter) + " : " + text);
        }

        public static bool isBranchOPC(string line)
        {
            return branchOPCs.Contains<string>(line.Split(' ')[0].Replace("+", "").Replace("-", ""));
        }

        public static bool isUnconditional(string line)
        {
            return uncondPre.Contains<string>(line.Split(' ')[0]);
        }

        public static bool isReturningBranch(string line)
        {
            return branchRetOPCs.Contains<string>(line.Split(' ')[0]);
        }

        public static string NormalizeLine(string s)
        {
            string result = "";
            while (s.Contains("\t\t"))
                s = s.Replace("\t\t", "\t");
            s = s.Replace("\t", " ");
            while (s.Contains("  "))
                s = s.Replace("  ", " ");
            string[] parts = s.Split(' ');
            int count = 0;
            foreach (string part in parts)
                if (count++ == 0)
                {
                    result = part;
                    while (result.Length % 10 != 0)
                        result += ' ';
                }
                else if (!part.Trim().StartsWith("#"))
                    result += part.Trim() + ' ';
                else
                {
                    while (result.Length % 40 != 0)
                        result += ' ';
                    result += part.Trim();
                }
            return result;
        }

        #endregion
    }
}
