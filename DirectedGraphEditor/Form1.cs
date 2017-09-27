using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectedGraphLibWV;

namespace DirectedGraphEditor
{
    public partial class Form1 : Form
    {
        public Graph graph = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewFile();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        public void NewFile()
        {
            graph = new Graph();
            graph.nodes.Add(new Node("Hello"));
            graph.nodes.Add(new Node("World"));
            graph.nodes.Add(new Node("!"));
            graph.edges.Add(new Edge(0, 1, "A"));
            graph.edges.Add(new Edge(0, 2, "B"));
            graph.edges.Add(new Edge(1, 2, "C"));
            RefreshStuff();
        }

        public void RefreshStuff()
        {
            if (graph == null)
                return;
            listBox1.Items.Clear();
            for (int i = 0; i < graph.nodes.Count; i++)
                listBox1.Items.Add("Node" + i + " : " + graph.nodes[i].data.ToString());
            listBox2.Items.Clear();
            for (int i = 0; i < graph.edges.Count; i++)
                listBox2.Items.Add("Edge" + i + " : " + graph.edges[i].start + " - " + graph.edges[i].end + " - \"" + graph.edges[i].text + "\"");
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (int i = 0; i < graph.nodes.Count; i++)
            {
                comboBox1.Items.Add(i.ToString());
                comboBox2.Items.Add(i.ToString());
            }
            Render();
        }

        public void Render()
        {
            pb1.Image = null;
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\bin\\";
            if (File.Exists(path + "dot.exe"))
            {
                Delete(path + "graph.dot");
                Delete(path + "graph.png");
                graph.GenerateDotFile(path + "graph.dot");
                RunShell(path + "dot.exe", "\"" + path + "graph.dot\" -Tpng -o graph.png");
                if (File.Exists(path + "graph.png"))
                    pb1.Image = LoadImageCopy(path + "graph.png");
                Delete(path + "graph.dot");
                Delete(path + "graph.png");
            }
        }

        public void Delete(string file)
        {
            if (File.Exists(file))
                File.Delete(file);
        }

        public string RunShell(string file, string command)
        {
            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = file;
            startInfo.Arguments = command;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = Path.GetDirectoryName(file) + "\\";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            return process.StandardOutput.ReadToEnd();
        }

        public static Bitmap LoadImageCopy(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Bitmap loaded = new Bitmap(fs);
            Bitmap result = (Bitmap)loaded.Clone();
            fs.Close();
            GC.Collect();
            return result;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            removeNodeToolStripMenuItem.Enabled = (listBox1.SelectedIndex != -1 && listBox1.Items.Count > 1);
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.addNode(new Node(), listBox1.SelectedIndex);
            RefreshStuff();
        }

        private void removeNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.removeNode(listBox1.SelectedIndex);
            RefreshStuff(); 
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = listBox2.SelectedIndex;
            if (n == -1)
                return;
            Edge ed = graph.edges[n];
            comboBox1.SelectedIndex = ed.start;
            comboBox2.SelectedIndex = ed.end;
            textBox2.Text = ed.text;
        }

        private void addEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.edges.Add(new Edge(0, 0, ""));
            RefreshStuff();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            removeEdgeToolStripMenuItem.Enabled = (listBox2.SelectedIndex != -1);
        }

        private void removeEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = listBox2.SelectedIndex;
            if (n == -1)
                return;
            graph.edges.RemoveAt(n);
            RefreshStuff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = listBox2.SelectedIndex;
            if (n == -1)
                return;
            graph.edges[n].start = comboBox1.SelectedIndex;
            graph.edges[n].end = comboBox2.SelectedIndex;
            graph.edges[n].text = textBox2.Text;
            RefreshStuff();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "*.gr|*.gr";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                graph.Save(d.FileName);
                MessageBox.Show("Done.");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "*.gr|*.gr";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                graph.Load(d.FileName);
                RefreshStuff();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = listBox1.SelectedIndex;
            if (n == -1)
                return;
            textBox1.Text = graph.nodes[n].data.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = listBox1.SelectedIndex;
            if (n == -1)
                return;
            graph.nodes[n].data = textBox1.Text;
            RefreshStuff();
        }

        public void Log(string s)
        {
            rtb1.Invoke((MethodInvoker)delegate()
            {
                rtb1.AppendText(s + "\n");
                rtb1.SelectionStart = rtb1.Text.Length;
                rtb1.ScrollToCaret();
            });
        }

        private void getPreOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            Log(Helper.ListToText("Pre Order", graph.getOrder(false)));
        }

        private void getPostOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            Log(Helper.ListToText("Post Order", graph.getOrder(true)));
        }

        private void getDominatorTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            Log(Helper.TreeToText(graph.getDominatorTree(false)).Trim());
        }

        private void getPostDominatorTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            Log(Helper.TreeToText(graph.getDominatorTree(true)).Trim());
        }

        private void checkForCyclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            Log("Is cyclic:" + graph.isCyclic());
        }

        private void getStronglyConnectedComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            List<List<int>> clist = graph.getAllStronglyConnectedComponents();
            int count = 0;
            foreach (List<int> component in clist)
            {
                string s = (count++) + ". SCComponent = {";
                for (int i = 0; i < component.Count - 1; i++)
                    s += component[i] + ", ";
                s += component[component.Count - 1] + "}";
                Log(s);
            }
        }

        private void getAllSimpleCyclePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            List<List<int>> clist = graph.getAllStronglyConnectedComponents();   
            int count = 0;
            foreach (List<int> component in clist)
            {
                if (component.Count > 1)
                {
                    Log("Loop paths for component " + count + " :");
                    List<List<int>> cyclist = graph.getAllSimpleCyclePaths(component);
                    int count2 = 0;
                    foreach (List<int> path in cyclist)
                    {
                        string s = (count2++) + ". Path = {";
                        for (int i = 0; i < path.Count - 1; i++)
                            s += path[i] + ", ";
                        s += path[path.Count - 1] + "}";
                        Log(s);
                    }
                }
                count++;
            }
        }

        private void getAllSimpleLoopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;            
            List<List<int>> clist = graph.getAllStronglyConnectedComponents();
            int count = 0;
            foreach (List<int> component in clist)
            {
                if (component.Count > 1)
                {
                    Log("Simple Loops for component " + count + " :");
                    List<List<int>> loops = graph.getAllSimpleLoops(component);
                    int count2 = 0;
                    foreach (List<int> loop in loops)
                    {
                        string s = (count2) + ". Loop Header = " + loop[0] + ", Loop Body = {";
                        for (int i = 1; i < loop.Count - 1; i++)
                            s += loop[i] + ", ";
                        if (loop.Count > 1)
                            s += loop[loop.Count - 1] + "}";
                        else
                            s += "}";
                        Log(s);
                        count2++;
                    }
                }
                count++;
            }
        }

        private void getAllBackedgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            graph.getOrder(true);
            Log("Backedges:");
            for (int i = 0; i < graph.edges.Count; i++)
                if (graph.edges[i].backEdge)
                    Log("Edge " + i);                
        }

        private void getAllSimpleLoopInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            List<List<int>> clist = graph.getAllStronglyConnectedComponents();
            int count = 0;
            foreach (List<int> component in clist)
            {
                if (component.Count > 1)
                {
                    Log("Simple Loop Information for component " + count + " :");
                    List<List<int>> loops = graph.getAllSimpleLoops(component);
                    int count2 = 0;
                    foreach (List<int> loop in loops)
                    {
                        Loop l = graph.getLoopInformation(loop);
                        string s = (count2) + ". Loop\n Header : " + l.header + "\n";
                        s +=" Body  : {";
                        foreach (LoopPart p in l.body)
                            s += "\n          " + p.ToString();
                        s += "\n         }\n";
                        s += " HasMultipleExits=" + l.isMultiExit;
                        Log(s);
                        count2++;
                    }
                }
                count++;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshStuff();
        }

        private void getAllReachingPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            for (int i = 1; i < graph.nodes.Count; i++)
            {
                List<List<int>> paths = graph.getAllReachingPaths(i);
                Log("Reaching paths for Node " + i + " : ");
                foreach (List<int> path in paths)
                {
                    if (path.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(" " + path[0]);
                        for (int j = 1; j < path.Count; j++)
                            sb.Append("->" + path[j]);
                        Log(sb.ToString());
                    }
                }
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pb1.Image != null)
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "*.png|*.png";
                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pb1.Image.Save(d.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Done.");
                }
            }
        }

        private void getAllSESERegionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            List<List<int>> list = graph.getAllSESERegions();
            Log("All SESE possible regions:");
            foreach (List<int> region in list)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" ");
                sb.Append(region[0]);
                for (int i = 1; i < region.Count; i++)
                    sb.Append(", " + region[i]);
                Log(sb.ToString());
            }
        }

        private void getTopologicalOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graph == null)
                return;
            Log(Helper.ListToText("Topoligical Order", graph.getTopogicalOrder()));
        }
    }
}
