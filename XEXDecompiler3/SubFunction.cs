using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectedGraphLibWV;

namespace XEXDecompiler3
{
    public class SubFunction
    {
        public string name;
        public string[] rawLines;
        public ASMFile parent;
        public SubFunction(string n, string[] lines)
        {
            name = n;
            rawLines = lines;
        }
    }
}
