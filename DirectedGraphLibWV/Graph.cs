using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectedGraphLibWV
{
    public class Graph
    {
        public List<Node> nodes;
        public List<Edge> edges;
        public Graph()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
        }

        public void GenerateDotFile(string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("digraph G {");
            for (int i = 0; i < nodes.Count; i++)
                sb.AppendLine("\tNode" + i + " [shape=box, fontname = \"Lucida Console\", fontsize=8, fillcolor=azure2, style=filled, label=\"Node " + i + "\\l" + nodes[i].data.ToString() + "\"];");
            for (int i = 0; i < edges.Count; i++)
                sb.AppendLine("\tNode" + edges[i].start + " -> Node" + edges[i].end + "[label=\"" + edges[i].text + "\"" + (edges[i].backEdge ? "color=\"1 1 .7\"" : "") + "];");
            sb.AppendLine("}");
            File.WriteAllText(path, sb.ToString());
        }

        public void Save(string file)
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteInt32(m, 0x78563412);
            Helper.WriteInt32(m, nodes.Count);
            foreach (Node n in nodes)
                Helper.WriteString(m, n.data.ToString());
            Helper.WriteInt32(m, edges.Count);
            foreach (Edge e in edges)
            {
                Helper.WriteInt32(m, e.start);
                Helper.WriteInt32(m, e.end);
                Helper.WriteString(m, e.text);
            }
            File.WriteAllBytes(file, m.ToArray());
        }
        public void Load(string file)
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            if (Helper.ReadInt32(fs) == 0x78563412)
            {
                int count = Helper.ReadInt32(fs);
                for (int i = 0; i < count; i++)
                    nodes.Add(new Node(Helper.ReadString(fs)));
                count = Helper.ReadInt32(fs);
                for (int i = 0; i < count; i++)
                    edges.Add(new Edge(Helper.ReadInt32(fs), Helper.ReadInt32(fs), Helper.ReadString(fs)));
            }
            fs.Close();
        }

        public void invertGraph()
        {
            int t;
            int maxIdx = nodes.Count - 1;
            foreach (Edge e in edges)
            {
                t = maxIdx - e.start;
                e.start = maxIdx - e.end;
                e.end = t;
            }
            List<Node> tmp = new List<Node>();
            for (int i = maxIdx; i >= 0; i--)
                tmp.Add(nodes[i]);
            nodes = tmp;
        }
        public void invertEdges()
        {
            int tmp;
            foreach (Edge e in edges)
            {
                tmp = e.start;
                e.start = e.end;
                e.end = tmp;
            }
        }
        public void addNode(Node n, int at = -1)
        {
            if (at == -1)
            {
                nodes.Add(n);
            }
            else
            {
                nodes.Insert(at, n);
                foreach (Edge e in edges)
                {
                    if (e.start >= at)
                        e.start++;
                    if (e.end >= at)
                        e.end++;
                }
            }
        }
        public void removeNode(int at)
        {
            nodes.RemoveAt(at);
            for (int i = 0; i < edges.Count; i++)
                if (edges[i].start == at || edges[i].end == at)
                {
                    edges.RemoveAt(i);
                    i--;
                }
            foreach (Edge e in edges)
            {
                if (e.start > at)
                    e.start--;
                if (e.end > at)
                    e.end--;
            }
        }
        public void removeEdge(int s, int e)
        {
            for(int i=0;i<edges.Count;i++)
                if (edges[i].start == s && edges[i].end == e)
                {
                    edges.RemoveAt(i);
                    i--;
                }
        }

        public List<int> getChildren(int node)
        {
            List<int> result = new List<int>();
            foreach (Edge e in edges)
                if (e.start == node)
                    result.Add(e.end);
            result.Sort();
            return result;
        }
        public List<int> getParents(int node)
        {
            List<int> result = new List<int>();
            foreach (Edge e in edges)
                if (e.end == node)
                    result.Add(e.start);
            return result;
        }
        public void setAllNodes(bool visited)
        {
            foreach (Node n in nodes)
                n.visited = visited;
        }
        public void setAllEdges(bool backEdge)
        {
            foreach (Edge e in edges)
                e.backEdge = backEdge;
        }

        public List<int> getOrder(bool post)
        {
            List<int> result = new List<int>();
            setAllNodes(false);
            setAllEdges(false);
            for (int i = 0; i < nodes.Count; i++)
                if (!nodes[i].visited)
                    DFSOrder(i, new List<int>(), result, post);
            return result;
        }
        public TreeNode getDominatorTree(bool post = false)
        {
            if (post) invertGraph();
            List<int> postOrder = getOrder(true);
            if (post) setAllEdges(false);
            TreeNode tree;
            if (post)
                tree = new TreeNode("PostDominator Tree");
            else
                tree = new TreeNode("Dominator Tree");
            List<List<int>> dominators = new List<List<int>>();
            for (int i = 0; i < nodes.Count; i++)
            {
                List<int> tmp = new List<int>();
                for (int j = 0; j < nodes.Count; j++)
                    tmp.Add(j);
                dominators.Add(tmp);
            }
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 0; i < postOrder.Count; i++)
                {
                    int current = postOrder[i];
                    List<int> currDoms;
                    List<int> pred = getParents(current);
                    if (pred.Count > 0)
                    {
                        currDoms = dominators[pred[0]];
                        foreach (int j in pred)
                            currDoms = Helper.ListIntersection(currDoms, dominators[j]);
                    }
                    else
                        currDoms = new List<int>();
                    if (!currDoms.Contains(current))
                        currDoms.Add(current);
                    if (Helper.ListChanged(dominators[current], currDoms))
                    {
                        dominators[current] = currDoms;
                        changed = true;
                    }
                }
            }
            if (post)
            {
                invertGraph();
                for (int i = 0; i < dominators.Count; i++)
                    for (int j = 0; j < dominators[i].Count; j++)
                        dominators[i][j] = (nodes.Count - 1) - dominators[i][j];
            }
            foreach (List<int> list in dominators)
                tree = Helper.AddPath(tree, list);
            return tree;
        }
        public bool isCyclic()
        {
            List<int> white = new List<int>();
            List<int> grey = new List<int>();
            List<int> black = new List<int>();
            for (int i = 0; i < nodes.Count; i++)
                white.Add(i);
            while (white.Count > 0)
                if (DFSCycleCheck(white[0], white, grey, black))
                    return true;
            return false;
        }
        public List<List<int>> getAllStronglyConnectedComponents()
        {
            List<List<int>> result = new List<List<int>>();
            List<int> finished = new List<int>();
            setAllNodes(false);
            for (int i = 0; i < nodes.Count; i++)
                if (!nodes[i].visited)
                    DFSStronglyConnectedComponents(i, finished);
            invertEdges();
            setAllNodes(false);
            for (int i = finished.Count - 1; i >= 0; i--)
                if (!nodes[finished[i]].visited)
                    result.Add(getStronglyConnectedComponent(finished[i]));
            invertEdges();
            return result;
        }
        public List<int> getStronglyConnectedComponent(int node)
        {
            List<int> result = new List<int>();
            result.Add(node);
            nodes[node].visited = true;
            List<int> childs = getChildren(node);
            foreach (int child in childs)
                if (!nodes[child].visited)
                    result.AddRange(getStronglyConnectedComponent(child));
            return result;
        }
        public List<List<int>> getAllSimpleCyclePaths(List<int> component)
        {
            List<List<int>> result = new List<List<int>>();
            setAllNodes(false);
            for (int i = 0; i < component.Count; i++)
            {
                DFSSimpleCycles(component, component[i], component[i], new List<int>(), new List<int>(), new List<Tuple<int, int>>(), result);
                nodes[component[i]].visited = true;
            }
            setAllNodes(true);
            return result;
        }
        public List<List<int>> getAllSimpleLoops(List<int> component)
        {
            List<List<int>> result = new List<List<int>>();
            getOrder(true);
            List<int> hnodes = new List<int>();
            foreach (Edge e in edges)
                if (e.backEdge && !hnodes.Contains(e.end))
                    hnodes.Add(e.end);
            List<List<int>> cyclist = getAllSimpleCyclePaths(component);
            foreach (int hnode in hnodes)
                if (component.Contains(hnode))
                {
                    List<List<int>> simplePaths = new List<List<int>>();
                    foreach (List<int> path in cyclist)
                    {
                        if (!path.Contains(hnode))
                            continue;
                        bool skip = false;
                        foreach (int hn2 in hnodes)
                            if (hn2 != hnode && path.Contains(hn2))
                            {
                                skip = true;
                                break;
                            }
                        if (skip)
                            continue;
                        simplePaths.Add(path);
                    }
                    if (simplePaths.Count == 0)
                        continue;
                    List<int> loopParts = new List<int>();
                    loopParts.Add(hnode);
                    foreach (List<int> path in simplePaths)
                        loopParts = Helper.ListUnion(loopParts, path);
                    result.Add(loopParts);
                }
            return result;
        }
        public Loop getLoopInformation(List<int> loop)
        {
            List<LoopPart> b = new List<LoopPart>();
            LoopPart h = new LoopPart(loop[0], true);
            List<int> childs = getChildren(loop[0]);
            List<int> exits = new List<int>();
            foreach (int c in childs)
                if (!loop.Contains(c))
                {
                    h.isBreak = true;
                    if (!exits.Contains(c)) exits.Add(c);
                }
            for (int i = 1; i < loop.Count; i++)
            {
                childs = getChildren(loop[i]);
                bool isContinue = false;
                bool isBreak = false;
                bool isTail = true;
                foreach (int c in childs)
                    if (c == h.index)
                        isContinue = true;
                    else if (loop.Contains(c))
                        isTail = false;
                    else
                    {
                        isBreak = true;
                        if (!exits.Contains(c)) exits.Add(c);
                    }
                bool hasOutsideEntry = false;
                List<int> parents = getParents(loop[i]);
                foreach (int p in parents)
                    if (!loop.Contains(p))
                        hasOutsideEntry = true;
                b.Add(new LoopPart(loop[i], false, isTail, isBreak, isContinue, hasOutsideEntry));
            }
            return new Loop(h, b, exits.Count > 1);
        }
        public List<List<int>> getAllReachingPaths(int idx)
        {
            List<List<int>> result = new List<List<int>>();
            DFSReachingPath(idx, 0, new List<int>(), result);
            return result;
        }
        public List<List<int>> getAllSESERegions()
        {
            TreeNode domTree = getDominatorTree(false);
            TreeNode postDomTree = getDominatorTree(true);
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < nodes.Count; i++)
                for (int j = 0; j < nodes.Count; j++)
                    if (i != j &&
                        Helper.ADominatesB(i, j, domTree.Nodes[0]) &&
                        Helper.ADominatesB(j, i, postDomTree.Nodes[0]) &&
                        getChildren(j).Count < 2 &&
                        getParents(i).Count < 2)
                    {
                        List<int> region = new List<int>();
                        DFSRegionParts(i, region, j);
                        region.Add(j);
                        result.Add(region);
                    }
            return result;
        }
        public List<int> getTopogicalOrder()
        {
            List<int> result = new List<int>();
            setAllNodes(false);
            while (true)
            {
                bool found = false;
                for (int i = 0; i < nodes.Count; i++)
                    if (!nodes[i].visited)
                    {
                        bool found2 = false;
                        foreach (Edge e in edges)
                            if (e.end == i && !nodes[e.start].visited)
                            {
                                found2 = true;
                                break;
                            }
                        if (!found2)
                        {
                            nodes[i].visited = true;
                            result.Add(i);
                            found = true;
                            break;
                        }
                    }
                if (!found)
                    break;
            }
            return result;
        }
        public Graph getCutOut(List<int> idxList)
        {
            Graph result = new Graph();
            int[] idxTrans = new int[nodes.Count];
            foreach (int i in idxList)
            {
                idxTrans[i] = result.nodes.Count;
                result.nodes.Add(nodes[i]);
            }
            foreach(Edge e in edges)
                if (idxList.Contains(e.start) && idxList.Contains(e.end))
                {
                    Edge copy = new Edge(idxTrans[e.start], idxTrans[e.end], e.text);
                    copy.backEdge = e.backEdge;
                    result.edges.Add(copy);
                }
            return result;
        }

        #region DFS
        public void DFSOrder(int index, List<int> stack, List<int> result, bool post)
        {
            nodes[index].visited = true;
            if (!post) result.Add(index);
            stack.Add(index);
            List<int> childs = getChildren(index);
            foreach (int i in childs)
                if (!nodes[i].visited)
                    DFSOrder(i, stack, result, post);
                else if (stack.Contains(i))
                    foreach (Edge e in edges)
                        if (e.start == index && e.end == i && post)
                            e.backEdge = true;
            if (post) result.Add(index);
            stack.Remove(index);
        }
        public bool DFSCycleCheck(int current, List<int> white, List<int> grey, List<int> black)
        {
            Helper.ListMoveIndex(current, white, grey);
            List<int> neighbours = getChildren(current);
            foreach (int i in neighbours)
            {
                if (black.Contains(i))
                    continue;
                if (grey.Contains(i))
                    return true;
                if (DFSCycleCheck(i, white, grey, black))
                    return true;
            }
            Helper.ListMoveIndex(current, grey, black);
            return false;
        }
        public void DFSStronglyConnectedComponents(int node, List<int> finished)
        {
            nodes[node].visited = true;
            List<int> childs = getChildren(node);
            foreach (int child in childs)
                if (!nodes[child].visited)
                    DFSStronglyConnectedComponents(child, finished);
            finished.Add(node);
        }
        public bool DFSSimpleCycles(List<int> component, int sindex, int index, List<int> stack, List<int> blocked, List<Tuple<int, int>> blockMap, List<List<int>> result)
        {
            bool foundCycle = false;
            stack.Add(index);
            blocked.Add(index);
            List<int> childs = getChildren(index);
            foreach (int n in childs)
                if (!nodes[n].visited && component.Contains(n))
                {
                    if (n == sindex)
                    {
                        List<int> tmp = new List<int>();
                        foreach (int m in stack)
                            tmp.Add(m);
                        result.Add(tmp);
                        foundCycle = true;
                    }
                    else if (!blocked.Contains(n) && DFSSimpleCycles(component, sindex, n, stack, blocked, blockMap, result))
                        foundCycle = true;
                }
            if (foundCycle)
                Helper.Unblock(index, blocked, blockMap);
            else
                foreach (int n in childs)
                    if (!nodes[n].visited && component.Contains(n))
                        blockMap.Add(new Tuple<int, int>(index, n));
            stack.Remove(index);
            return foundCycle;
        }
        public void DFSReachingPath(int target, int current, List<int> path, List<List<int>> stack)
        {
            path.Add(current);
            List<int> childs = getChildren(current);
            foreach (int child in childs)
            {
                List<int> npath = new List<int>();
                npath.AddRange(path);
                if (child == target)
                {                   
                    npath.Add(target);
                    stack.Add(npath);
                    continue;
                }
                if (path.Contains(child))
                    continue;
                DFSReachingPath(target, child, npath, stack);
            }
        }
        public void DFSRegionParts(int current, List<int> stack, int end)
        {
            if (stack.Contains(current)) return;
            stack.Add(current);
            List<int> childs = getChildren(current);
            foreach (int c in childs)
                if (c != end)
                    DFSRegionParts(c, stack, end);
        }
        #endregion
    }

    public class Edge
    {
        public int start;
        public int end;
        public bool backEdge;
        public string text;
        public Edge(int s, int e, string t)
        {
            start = s;
            end = e;
            backEdge = false;
            text = t;
        }
    }

    public class Node
    {
        public bool visited;
        public int srcId;
        public object data;
        public Node(object d = null, int src = -1)
        {
            visited = false;
            srcId = src;
            data = d;
        }
    }

    public class Loop
    {
        public LoopPart header;
        public List<LoopPart> body;
        public bool isMultiExit;
        public Loop(LoopPart h, List<LoopPart> b, bool multi)
        {
            header = h;
            body = b;
            isMultiExit = multi;
        }
    }

    public class LoopPart
    {
        public int index;
        public bool isHeader;
        public bool isTail;
        public bool isBreak;
        public bool isContinue;
        public bool hasOutsideEntry;
        public LoopPart(int idx, bool header = false, bool tail = false, bool brk= false, bool cont = false, bool outEnt = false)
        {
            index = idx;
            isHeader = header;
            isTail = tail;
            isBreak = brk;
            isContinue = cont;
            hasOutsideEntry = outEnt;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Idx=" + index);
            if (isHeader) sb.Append(", IsHeader");
            if (isTail) sb.Append(", IsTail");
            if (isBreak) sb.Append(", IsBreak");
            if (isContinue) sb.Append(", IsContinue");
            if (hasOutsideEntry) sb.Append(", HasOutsideEntry");
            return sb.ToString();
        }
    }

    public static class Helper
    {
        public static void WriteInt32(Stream s, int i)
        {
            s.Write(BitConverter.GetBytes(i), 0, 4);
        }

        public static void WriteString(Stream s, string t)
        {
            WriteInt32(s, t.Length);
            foreach (char c in t)
                s.WriteByte((byte)c);
        }

        public static int ReadInt32(Stream s)
        {
            byte[] buff = new byte[4];
            s.Read(buff, 0, 4);
            return BitConverter.ToInt32(buff, 0);
        }

        public static string ReadString(Stream s)
        {
            StringBuilder sb = new StringBuilder();
            int count = ReadInt32(s);
            for (int i = 0; i < count; i++)
                sb.Append((char)s.ReadByte());
            return sb.ToString();
        }

        public static string ListToText(string name, List<int> data)
        {
            StringBuilder s = new StringBuilder();
            s.Append(name + " = {");
            for (int i = 0; i < data.Count - 1; i++)
                s.Append(data[i] + ", ");
            if (data.Count > 0)
                s.Append(data[data.Count - 1]);
            s.Append("}");
            return s.ToString();
        }

        public static string TreeToText(TreeNode t, int tabs = 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tabs - 1; i++)
                sb.Append("| ");
            if (tabs > 0)
                sb.Append("+-");
            sb.AppendLine(t.Text);
            foreach (TreeNode t2 in t.Nodes)
                sb.Append(TreeToText(t2, tabs + 1));
            return sb.ToString();
        }

        public static TreeNode AddPath(TreeNode t, List<int> path)
        {
            if (path.Count > 0)
            {
                TreeNode t2 = null;
                bool found = false;
                foreach (TreeNode t3 in t.Nodes)
                    if (t3.Text == path[0].ToString())
                    {
                        t2 = t3;
                        found = true;
                        break;
                    }
                if (!found)
                {
                    t2 = new TreeNode(path[0].ToString());
                    t2.Name = t2.Text;
                }
                List<int> tmp = new List<int>();
                for (int i = 1; i < path.Count; i++)
                    tmp.Add(path[i]);
                t2 = AddPath(t2, tmp);
                if (!found)
                    t.Nodes.Add(t2);
            }
            return t;
        }

        public static bool ListChanged(List<int> before, List<int> after)
        {
            if (before.Count != after.Count)
                return true;
            bool differs = false;
            foreach (int i in before)
                if (!after.Contains(i))
                {
                    differs = true;
                    break;
                }
            return differs;
        }

        public static bool ListContained(List<int> inner, List<int> outer)
        {
            if (inner.Count > outer.Count)
                return false;
            foreach (int i in inner)
                if (!outer.Contains(i))
                    return false;
            return true;
        }

        public static List<int> ListIntersection(List<int> a, List<int> b)
        {
            List<int> result = new List<int>();
            foreach (int i in a)
                if (b.Contains(i))
                    result.Add(i);
            return result;
        }

        public static List<int> ListUnion(List<int> a, List<int> b)
        {
            List<int> result = new List<int>();
            result.AddRange(a);
            foreach (int i in b)
                if (!result.Contains(i))
                    result.Add(i);
            return result;
        }

        public static void ListMoveIndex(int index, List<int> a, List<int> b)
        {
            for (int i = 0; i < a.Count; i++)
                if (a[i] == index)
                {
                    a.RemoveAt(i);
                    break;
                }
            b.Add(index);
        }

        public static void Unblock(int index, List<int> blocked, List<Tuple<int, int>> blockMap)
        {
            blocked.Remove(index);
            for (int i = 0; i < blockMap.Count; i++)
            {
                if (blockMap[i].Item1 == index)
                    Unblock(blockMap[i].Item2, blocked, blockMap);
                blockMap.RemoveAt(i);
                i--;
            }
        }

        public static bool ADominatesB(int a, int b, TreeNode t)
        {
            TreeNode tmp = t;
            if (t.Text != a.ToString())
            {
                TreeNode[] res = t.Nodes.Find(a.ToString(), true);
                if (res.Length != 1)
                    return false;
                tmp = res[0];
            }
            if (tmp.Nodes.Find(b.ToString(), true).Length != 1)
                return false;
            return true;
        }
    }
}
