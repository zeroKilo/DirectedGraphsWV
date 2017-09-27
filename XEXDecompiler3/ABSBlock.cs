using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XEXDecompiler3
{
    public class ABSBlock
    {
        public enum absType
        {
            SEQUENCE,
            SIMPLEWHILE,
            IFTHEN,
            IFTHENELSE,
            BREAK,
            CONTINUE,
            WHILE,
            DOWHILE,
            ACSESEREGION
        }

        public absType type;
        public object data;

        public ABSBlock()
        {
        }

        public ABSBlock(absType t)
        {
            type = t;
        }

        public override string ToString()
        {
            return type.ToString();
        }
    }
}
