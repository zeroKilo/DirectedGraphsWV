using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectedGraphLibWV;
using System.Diagnostics;

namespace XEXDecompiler3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadASMToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "*.asm|*.asm";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Decompiler.asm = new ASMFile(d.FileName, pb1);
                Decompiler.level = 6;
                SelectStep(4);
                RefreshStuff();
            }
        }

        public void RefreshStuff()
        {
            listBox1.Items.Clear();
            if (Decompiler.asm == null)
                return;
            SelectStep(Decompiler.level);
            foreach (SubFunction sub in Decompiler.asm.subs)
                listBox1.Items.Add(sub.name + " (" + sub.rawLines.Length + ")");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSubfunction();
        }

        public void RefreshSubfunction()
        {
            int n = listBox1.SelectedIndex;
            if (n == -1 || Decompiler.asm == null)
                return;
            SelectStep(Decompiler.level);
            Decompiler.sub = Decompiler.asm.subs[n];
            Decompiler.simplefyOneBlockWhile = simplefy1BlockWhileToolStripMenuItem.Checked;
            Decompiler.simplefySequences = simplefySequencesToolStripMenuItem.Checked;
            Decompiler.simplefyIfThen = simplefyIfThenToolStripMenuItem.Checked;
            Decompiler.simplefyIfThenElse = simplefyIfThenElseToolStripMenuItem.Checked;
            Decompiler.simplefyLoopParts = simplefyLoopPartsToolStripMenuItem.Checked;
            Decompiler.simplefySimpleLoops = simplefySimpleLoopsToolStripMenuItem.Checked;
            Decompiler.simplefyACSESERegions = simplefyAcyclicSESERegionsToolStripMenuItem.Checked;
            Decompiler.saveMidStepGraphs = saveMidStepGraphsToolStripMenuItem.Checked;
            string[] files = Directory.EnumerateFiles(Path.GetDirectoryName(Application.ExecutablePath) + "\\", "MidStep*.gr").ToArray();
            foreach (string f in files)
                File.Delete(f);
            rtb1.Text = Decompiler.Decompile();
            if (Decompiler.graph != null)
                Render(n);
        }

        public void Render(int n)
        {
            pic1.Image = null;
            if (!renderToolStripMenuItem.Checked)
                return;
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\bin\\";
            Graph g = Decompiler.graph;
            g.GenerateDotFile(path + "graph.dot");
            if (File.Exists(path + "graph.dot") &&
                File.Exists(path + "dot.exe"))
            {

                GC.Collect();
                if (File.Exists(path + "image.png"))
                    File.Delete(path + "image.png");
                RunShell(path + "dot.exe", "\"" + path + "graph.dot\" -Tpng -o image.png");
                try
                {
                    if (File.Exists(path + "image.png"))
                        pic1.Image = LoadImageCopy(path + "image.png");
                }
                catch (Exception)
                {
                    pic1.Image = null;
                    GC.Collect();
                }
                if (File.Exists(path + "image.png"))
                    File.Delete(path + "image.png");
            }
        }

        public static string RunShell(string file, string command)
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

        private void saveGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = listBox1.SelectedIndex;
            if (n == -1 || Decompiler.asm == null || Decompiler.graph == null)
                return;
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "*.gr|*.gr";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Decompiler.graph.Save(d.FileName);
                MessageBox.Show("Done.");
            }
        }

        private void saveGraphImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pic1.Image == null)
                return;
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "*.png|*.png";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pic1.Image.Save(d.FileName);
                MessageBox.Show("Done.");
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Decompiler.asm != null) Decompiler.level = 0;
            RefreshSubfunction();
        }

        private void step1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Decompiler.asm != null) Decompiler.level = 1;
            RefreshSubfunction();
        }

        private void step2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Decompiler.asm != null) Decompiler.level = 2;
            RefreshSubfunction();
        }

        private void step3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Decompiler.asm != null) Decompiler.level = 3;
            RefreshSubfunction();
        }

        private void step4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Decompiler.asm != null) Decompiler.level = 4;
            RefreshSubfunction();
        }

        private void step5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Decompiler.asm != null) Decompiler.level = 5;
            RefreshSubfunction();
        }

        private void step6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Decompiler.asm != null) Decompiler.level = 6;
            RefreshSubfunction();
        }

        public void SelectStep(int n)
        {
            noneToolStripMenuItem.Checked = n == 0;
            step1ToolStripMenuItem.Checked = n == 1;
            step2ToolStripMenuItem.Checked = n == 2;
            step3ToolStripMenuItem.Checked = n == 3;
            step4ToolStripMenuItem.Checked = n == 4;
            step5ToolStripMenuItem.Checked = n == 5;
            step6ToolStripMenuItem.Checked = n == 6;
        }
    }
}
