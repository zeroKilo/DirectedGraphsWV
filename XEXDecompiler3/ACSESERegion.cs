using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectedGraphLibWV;

namespace XEXDecompiler3
{
    public class ACSESERegion
    {
        public Graph graph;
        public List<int> decNodes = new List<int>();
        public List<int> codeNodes = new List<int>();
        public ACSESERegion(Graph gr)
        {
            graph = gr;
            for (int i = 0; i < gr.nodes.Count; i++)
                if (gr.getChildren(i).Count > 1)
                    decNodes.Add(i);
                else
                    codeNodes.Add(i);
        }
    }
}
