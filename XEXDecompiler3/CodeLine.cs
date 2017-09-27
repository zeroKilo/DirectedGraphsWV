using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XEXDecompiler3
{
    public class CodeLine
    {
        public long offset;
        public byte[] opcBytes;
        public uint opcDWORD;
        public string text;
        public string withoutComment;
        public CodeLine(string s, long off, byte[] data)
        {
            text = s;
            if (s.Contains("#"))
                withoutComment = text.Split('#')[0].Trim();
            else
                withoutComment = text.Trim();
            offset = off;
            opcBytes = data;
            if (data.Length == 4)
                opcDWORD = BitConverter.ToUInt32(opcBytes, 0);
        }
    }
}
