namespace XEXDecompiler3
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompilingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplefy1BlockWhileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplefySequencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplefyIfThenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplefyIfThenElseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplefyLoopPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplefySimpleLoopsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplefyAcyclicSESERegionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMidStepGraphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGraphImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 534);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(607, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Functions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(601, 502);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(233, 477);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 477);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(233, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(31, 22);
            this.toolStripButton1.Text = "Find";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(364, 502);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rtb1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(356, 476);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Output";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtb1
            // 
            this.rtb1.AcceptsTab = true;
            this.rtb1.DetectUrls = false;
            this.rtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rtb1.Location = new System.Drawing.Point(3, 3);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(350, 470);
            this.rtb1.TabIndex = 1;
            this.rtb1.Text = "";
            this.rtb1.WordWrap = false;
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.pic1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(356, 476);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Graph";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(0, 0);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(100, 50);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.decompilingToolStripMenuItem,
            this.graphToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadASMToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadASMToolStripMenuItem
            // 
            this.loadASMToolStripMenuItem.Name = "loadASMToolStripMenuItem";
            this.loadASMToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadASMToolStripMenuItem.Text = "Load ASM";
            this.loadASMToolStripMenuItem.Click += new System.EventHandler(this.loadASMToolStripMenuItem_Click);
            // 
            // decompilingToolStripMenuItem
            // 
            this.decompilingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.step1ToolStripMenuItem,
            this.step2ToolStripMenuItem,
            this.step3ToolStripMenuItem,
            this.step4ToolStripMenuItem,
            this.step5ToolStripMenuItem,
            this.step6ToolStripMenuItem});
            this.decompilingToolStripMenuItem.Name = "decompilingToolStripMenuItem";
            this.decompilingToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.decompilingToolStripMenuItem.Text = "Decompiling";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // step1ToolStripMenuItem
            // 
            this.step1ToolStripMenuItem.Name = "step1ToolStripMenuItem";
            this.step1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.step1ToolStripMenuItem.Text = "Step 1";
            this.step1ToolStripMenuItem.Click += new System.EventHandler(this.step1ToolStripMenuItem_Click);
            // 
            // step2ToolStripMenuItem
            // 
            this.step2ToolStripMenuItem.Name = "step2ToolStripMenuItem";
            this.step2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.step2ToolStripMenuItem.Text = "Step 2";
            this.step2ToolStripMenuItem.Click += new System.EventHandler(this.step2ToolStripMenuItem_Click);
            // 
            // step3ToolStripMenuItem
            // 
            this.step3ToolStripMenuItem.Name = "step3ToolStripMenuItem";
            this.step3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.step3ToolStripMenuItem.Text = "Step 3";
            this.step3ToolStripMenuItem.Click += new System.EventHandler(this.step3ToolStripMenuItem_Click);
            // 
            // step4ToolStripMenuItem
            // 
            this.step4ToolStripMenuItem.Name = "step4ToolStripMenuItem";
            this.step4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.step4ToolStripMenuItem.Text = "Step 4";
            this.step4ToolStripMenuItem.Click += new System.EventHandler(this.step4ToolStripMenuItem_Click);
            // 
            // step5ToolStripMenuItem
            // 
            this.step5ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simplefy1BlockWhileToolStripMenuItem,
            this.simplefySequencesToolStripMenuItem,
            this.simplefyIfThenToolStripMenuItem,
            this.simplefyIfThenElseToolStripMenuItem,
            this.simplefyLoopPartsToolStripMenuItem,
            this.simplefySimpleLoopsToolStripMenuItem,
            this.simplefyAcyclicSESERegionsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveMidStepGraphsToolStripMenuItem});
            this.step5ToolStripMenuItem.Name = "step5ToolStripMenuItem";
            this.step5ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.step5ToolStripMenuItem.Text = "Step 5";
            this.step5ToolStripMenuItem.Click += new System.EventHandler(this.step5ToolStripMenuItem_Click);
            // 
            // simplefy1BlockWhileToolStripMenuItem
            // 
            this.simplefy1BlockWhileToolStripMenuItem.Checked = true;
            this.simplefy1BlockWhileToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simplefy1BlockWhileToolStripMenuItem.Name = "simplefy1BlockWhileToolStripMenuItem";
            this.simplefy1BlockWhileToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.simplefy1BlockWhileToolStripMenuItem.Text = "Simplefy 1-Block-While";
            // 
            // simplefySequencesToolStripMenuItem
            // 
            this.simplefySequencesToolStripMenuItem.Checked = true;
            this.simplefySequencesToolStripMenuItem.CheckOnClick = true;
            this.simplefySequencesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simplefySequencesToolStripMenuItem.Name = "simplefySequencesToolStripMenuItem";
            this.simplefySequencesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.simplefySequencesToolStripMenuItem.Text = "Simplefy Sequences";
            // 
            // simplefyIfThenToolStripMenuItem
            // 
            this.simplefyIfThenToolStripMenuItem.Checked = true;
            this.simplefyIfThenToolStripMenuItem.CheckOnClick = true;
            this.simplefyIfThenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simplefyIfThenToolStripMenuItem.Name = "simplefyIfThenToolStripMenuItem";
            this.simplefyIfThenToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.simplefyIfThenToolStripMenuItem.Text = "Simplefy If-Then";
            // 
            // simplefyIfThenElseToolStripMenuItem
            // 
            this.simplefyIfThenElseToolStripMenuItem.Checked = true;
            this.simplefyIfThenElseToolStripMenuItem.CheckOnClick = true;
            this.simplefyIfThenElseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simplefyIfThenElseToolStripMenuItem.Name = "simplefyIfThenElseToolStripMenuItem";
            this.simplefyIfThenElseToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.simplefyIfThenElseToolStripMenuItem.Text = "Simplefy If-Then-Else";
            // 
            // simplefyLoopPartsToolStripMenuItem
            // 
            this.simplefyLoopPartsToolStripMenuItem.Checked = true;
            this.simplefyLoopPartsToolStripMenuItem.CheckOnClick = true;
            this.simplefyLoopPartsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simplefyLoopPartsToolStripMenuItem.Name = "simplefyLoopPartsToolStripMenuItem";
            this.simplefyLoopPartsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.simplefyLoopPartsToolStripMenuItem.Text = "Simplefy Loop Parts";
            // 
            // simplefySimpleLoopsToolStripMenuItem
            // 
            this.simplefySimpleLoopsToolStripMenuItem.Checked = true;
            this.simplefySimpleLoopsToolStripMenuItem.CheckOnClick = true;
            this.simplefySimpleLoopsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simplefySimpleLoopsToolStripMenuItem.Name = "simplefySimpleLoopsToolStripMenuItem";
            this.simplefySimpleLoopsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.simplefySimpleLoopsToolStripMenuItem.Text = "Simplefy Simple Loops";
            // 
            // simplefyAcyclicSESERegionsToolStripMenuItem
            // 
            this.simplefyAcyclicSESERegionsToolStripMenuItem.Checked = true;
            this.simplefyAcyclicSESERegionsToolStripMenuItem.CheckOnClick = true;
            this.simplefyAcyclicSESERegionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simplefyAcyclicSESERegionsToolStripMenuItem.Name = "simplefyAcyclicSESERegionsToolStripMenuItem";
            this.simplefyAcyclicSESERegionsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.simplefyAcyclicSESERegionsToolStripMenuItem.Text = "Simplefy Acyclic SESE Regions";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(214, 6);
            // 
            // saveMidStepGraphsToolStripMenuItem
            // 
            this.saveMidStepGraphsToolStripMenuItem.Checked = true;
            this.saveMidStepGraphsToolStripMenuItem.CheckOnClick = true;
            this.saveMidStepGraphsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveMidStepGraphsToolStripMenuItem.Name = "saveMidStepGraphsToolStripMenuItem";
            this.saveMidStepGraphsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.saveMidStepGraphsToolStripMenuItem.Text = "Save Mid Step Graphs";
            // 
            // step6ToolStripMenuItem
            // 
            this.step6ToolStripMenuItem.Name = "step6ToolStripMenuItem";
            this.step6ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.step6ToolStripMenuItem.Text = "Step 6";
            this.step6ToolStripMenuItem.Click += new System.EventHandler(this.step6ToolStripMenuItem_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderToolStripMenuItem,
            this.saveGraphToolStripMenuItem,
            this.saveGraphImageToolStripMenuItem});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // renderToolStripMenuItem
            // 
            this.renderToolStripMenuItem.Checked = true;
            this.renderToolStripMenuItem.CheckOnClick = true;
            this.renderToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.renderToolStripMenuItem.Name = "renderToolStripMenuItem";
            this.renderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.renderToolStripMenuItem.Text = "Render";
            // 
            // saveGraphToolStripMenuItem
            // 
            this.saveGraphToolStripMenuItem.Name = "saveGraphToolStripMenuItem";
            this.saveGraphToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.saveGraphToolStripMenuItem.Text = "Save Graph...";
            this.saveGraphToolStripMenuItem.Click += new System.EventHandler(this.saveGraphToolStripMenuItem_Click);
            // 
            // saveGraphImageToolStripMenuItem
            // 
            this.saveGraphImageToolStripMenuItem.Name = "saveGraphImageToolStripMenuItem";
            this.saveGraphImageToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.saveGraphImageToolStripMenuItem.Text = "Save Graph Image...";
            this.saveGraphImageToolStripMenuItem.Click += new System.EventHandler(this.saveGraphImageToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb1,
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(615, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pb1
            // 
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(200, 16);
            // 
            // status
            // 
            this.status.ForeColor = System.Drawing.Color.Red;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 580);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "XEX Decompiler 3 by Warranty Voider";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompilingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplefySequencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplefyIfThenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplefyIfThenElseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplefy1BlockWhileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step6ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pb1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGraphImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMidStepGraphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplefyLoopPartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem simplefySimpleLoopsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplefyAcyclicSESERegionsToolStripMenuItem;
    }
}

