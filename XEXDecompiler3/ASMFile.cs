using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XEXDecompiler3
{
    public class ASMFile
    {
        public List<SubFunction> subs;
        public Dictionary<string, long> funcOffsets = new Dictionary<string, long>();
        public Dictionary<long, byte[]> sections = new Dictionary<long, byte[]>();

        public ASMFile(string path, ToolStripProgressBar pb = null)
        {
            subs = new List<SubFunction>();
            string[] lines = File.ReadAllLines(path);
            bool hasStart = false;
            int start = -1;
            if (pb != null)
            {
                pb.Maximum = lines.Length;
                pb.Value = 0;
            }
            for (int i = 0; i < lines.Length; i++)
            {
                if (!hasStart && lines[i].StartsWith("# =============== S U B"))
                {
                    hasStart = true;
                    start = i + 1;
                }
                if (hasStart && lines[i].StartsWith("# End of function"))
                {
                    if (pb != null)
                        pb.Value = i;
                    string name = lines[i].Substring(18);
                    hasStart = false;
                    List<string> lin = new List<string>();
                    for (int j = start; j < i; j++)
                        lin.Add(lines[j]);
                    subs.Add(new SubFunction(name, lin.ToArray()));
                }
            }
            if (pb != null)
                pb.Value = 0;
            string basepath = Path.GetDirectoryName(path) + "\\";
            if (!File.Exists(basepath + "functions.txt"))
                throw new Exception("Functions.txt not found!");
            string[] offsets = File.ReadAllLines(basepath + "functions.txt");
            funcOffsets = new Dictionary<string,long>();
            foreach (string line in offsets)
                if (line.Trim() != "")
                {
                    string[] parts = line.Split(';');
                    if (parts.Length != 2)
                        continue;
                    if (!funcOffsets.ContainsKey(parts[1]))
                        funcOffsets.Add(parts[1], Convert.ToInt64(parts[0], 16));
                }
            string[] files = Directory.GetFiles(basepath, "*.bin", SearchOption.TopDirectoryOnly);
            sections = new Dictionary<long, byte[]>();
            pb.Maximum = files.Length;           
            foreach (string file in files)
            {
                pb.Value++;
                try
                {
                    sections.Add(Convert.ToInt64(Path.GetFileNameWithoutExtension(file), 16), File.ReadAllBytes(file));
                }
                catch { }
            }
            pb.Value = 0;
        }
    }   
}
