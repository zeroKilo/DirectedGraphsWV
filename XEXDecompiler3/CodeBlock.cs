using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XEXDecompiler3
{
    public class CodeBlock
    {
        public List<CodeLine> codeLines;
        public bool alwaysBranch;
        public bool isLocation;
        public bool canBranch;
        public bool retBranch;
        public int targetIndex;
        public int myIndex;
        public long offset;
        public List<CodeBlock> subBlocks;

        public CodeBlock()
        { }

        public CodeBlock(List<string> lines, ref long off, Dictionary<long, byte[]> sections, int index = -1)
        {
            subBlocks = new List<CodeBlock>();
            codeLines = new List<CodeLine>();
            offset = off;
            myIndex = index;
            targetIndex = -1;
            MemoryStream secData = null;
            long secOffset = -1;
            foreach (KeyValuePair<long, byte[]> sec in sections)
                if (off >= sec.Key && off < sec.Key + sec.Value.Length)
                {
                    secData = new MemoryStream(sec.Value);
                    secOffset = sec.Key;
                    break;
                }
            if (secData == null || secOffset == -1)
                throw new Exception("Cant find section data for this subfunction!");
            foreach (string s in lines)
            {
                if (s.StartsWith("loc_") || s.StartsWith("locret_"))
                    codeLines.Add(new CodeLine(s, off, new byte[0]));
                else
                {
                    byte[] tmp = new byte[4];
                    secData.Seek(off - secOffset, 0);
                    secData.Read(tmp, 0, 4);
                    codeLines.Add(new CodeLine(s, off, tmp));
                    off += 4;
                }
            }
            if (lines.Count > 0)
            {
                string line = lines[lines.Count - 1];
                if (lines[0].StartsWith("loc_") || lines[0].StartsWith("locret_"))
                    isLocation = true;
                if (Decompiler.isBranchOPC(line) && Decompiler.isUnconditional(line))
                {
                    alwaysBranch = true;
                    retBranch = Decompiler.isReturningBranch(line);
                }
                else if (Decompiler.isBranchOPC(line))
                    canBranch = true;
            }
        }

        public override string ToString()
        {
            return ToString(0).Replace("\"", "'").Replace("\n","\\l");
        }

        public string ToString(int tabs)
        {
            string tab = "";
            for (int i = 0; i < tabs; i++)
                tab += '\t';
            StringBuilder sb = new StringBuilder();
            sb.Append(tab + "Block " + myIndex + ": ");
            if (alwaysBranch)
                sb.Append("[ALWAYS BRANCH] ");
            if (isLocation)
                sb.Append("[IS LOCATION] ");
            if (canBranch)
                sb.Append("[CAN BRANCH] ");
            if (targetIndex != -1)
                sb.Append("[TARGET BLOCK=" + targetIndex + "] ");
            sb.AppendLine();
            foreach (CodeLine line in codeLines)
            {
                sb.Append(line.offset.ToString("X8") + " : ");
                foreach (byte b in line.opcBytes)
                    sb.Append(b.ToString("X2") + " ");
                sb.AppendLine(tab + line.text);
            }
            if (subBlocks.Count > 0)
            {
                sb.AppendLine(tab + "{");
                foreach (CodeBlock block in subBlocks)
                    sb.Append(block.ToString(tabs + 1));
                sb.AppendLine(tab + "}");
            }
            return sb.ToString();
        }
    }
}
