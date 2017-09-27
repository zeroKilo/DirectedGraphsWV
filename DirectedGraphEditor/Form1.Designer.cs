namespace DirectedGraphEditor
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForCyclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAllBackedgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getPreOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getPostOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDominatorTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getPostDominatorTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getStronglyConnectedComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAllSimpleCyclePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAllSimpleLoopsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAllSimpleLoopInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAllReachingPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAllSESERegionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.getTopologicalOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.graphToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.toolStripMenuItem1,
            this.checkForCyclesToolStripMenuItem,
            this.getAllBackedgesToolStripMenuItem,
            this.getPreOrderToolStripMenuItem,
            this.getPostOrderToolStripMenuItem,
            this.getTopologicalOrderToolStripMenuItem,
            this.getDominatorTreeToolStripMenuItem,
            this.getPostDominatorTreeToolStripMenuItem,
            this.getStronglyConnectedComponentsToolStripMenuItem,
            this.getAllSimpleCyclePathsToolStripMenuItem,
            this.getAllSimpleLoopsToolStripMenuItem,
            this.getAllSimpleLoopInformationToolStripMenuItem,
            this.getAllReachingPathsToolStripMenuItem,
            this.getAllSESERegionsToolStripMenuItem});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(249, 6);
            // 
            // checkForCyclesToolStripMenuItem
            // 
            this.checkForCyclesToolStripMenuItem.Name = "checkForCyclesToolStripMenuItem";
            this.checkForCyclesToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.checkForCyclesToolStripMenuItem.Text = "Check for cycles";
            this.checkForCyclesToolStripMenuItem.Click += new System.EventHandler(this.checkForCyclesToolStripMenuItem_Click);
            // 
            // getAllBackedgesToolStripMenuItem
            // 
            this.getAllBackedgesToolStripMenuItem.Name = "getAllBackedgesToolStripMenuItem";
            this.getAllBackedgesToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getAllBackedgesToolStripMenuItem.Text = "Get All Backedges";
            this.getAllBackedgesToolStripMenuItem.Click += new System.EventHandler(this.getAllBackedgesToolStripMenuItem_Click);
            // 
            // getPreOrderToolStripMenuItem
            // 
            this.getPreOrderToolStripMenuItem.Name = "getPreOrderToolStripMenuItem";
            this.getPreOrderToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getPreOrderToolStripMenuItem.Text = "Get Pre Order";
            this.getPreOrderToolStripMenuItem.Click += new System.EventHandler(this.getPreOrderToolStripMenuItem_Click);
            // 
            // getPostOrderToolStripMenuItem
            // 
            this.getPostOrderToolStripMenuItem.Name = "getPostOrderToolStripMenuItem";
            this.getPostOrderToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getPostOrderToolStripMenuItem.Text = "Get Post Order";
            this.getPostOrderToolStripMenuItem.Click += new System.EventHandler(this.getPostOrderToolStripMenuItem_Click);
            // 
            // getDominatorTreeToolStripMenuItem
            // 
            this.getDominatorTreeToolStripMenuItem.Name = "getDominatorTreeToolStripMenuItem";
            this.getDominatorTreeToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getDominatorTreeToolStripMenuItem.Text = "Get Dominator Tree";
            this.getDominatorTreeToolStripMenuItem.Click += new System.EventHandler(this.getDominatorTreeToolStripMenuItem_Click);
            // 
            // getPostDominatorTreeToolStripMenuItem
            // 
            this.getPostDominatorTreeToolStripMenuItem.Name = "getPostDominatorTreeToolStripMenuItem";
            this.getPostDominatorTreeToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getPostDominatorTreeToolStripMenuItem.Text = "Get Post Dominator Tree";
            this.getPostDominatorTreeToolStripMenuItem.Click += new System.EventHandler(this.getPostDominatorTreeToolStripMenuItem_Click);
            // 
            // getStronglyConnectedComponentsToolStripMenuItem
            // 
            this.getStronglyConnectedComponentsToolStripMenuItem.Name = "getStronglyConnectedComponentsToolStripMenuItem";
            this.getStronglyConnectedComponentsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getStronglyConnectedComponentsToolStripMenuItem.Text = "Get Strongly Connected Components";
            this.getStronglyConnectedComponentsToolStripMenuItem.Click += new System.EventHandler(this.getStronglyConnectedComponentsToolStripMenuItem_Click);
            // 
            // getAllSimpleCyclePathsToolStripMenuItem
            // 
            this.getAllSimpleCyclePathsToolStripMenuItem.Name = "getAllSimpleCyclePathsToolStripMenuItem";
            this.getAllSimpleCyclePathsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getAllSimpleCyclePathsToolStripMenuItem.Text = "Get All Simple Cycle Paths";
            this.getAllSimpleCyclePathsToolStripMenuItem.Click += new System.EventHandler(this.getAllSimpleCyclePathsToolStripMenuItem_Click);
            // 
            // getAllSimpleLoopsToolStripMenuItem
            // 
            this.getAllSimpleLoopsToolStripMenuItem.Name = "getAllSimpleLoopsToolStripMenuItem";
            this.getAllSimpleLoopsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getAllSimpleLoopsToolStripMenuItem.Text = "Get All Simple Loops";
            this.getAllSimpleLoopsToolStripMenuItem.Click += new System.EventHandler(this.getAllSimpleLoopsToolStripMenuItem_Click);
            // 
            // getAllSimpleLoopInformationToolStripMenuItem
            // 
            this.getAllSimpleLoopInformationToolStripMenuItem.Name = "getAllSimpleLoopInformationToolStripMenuItem";
            this.getAllSimpleLoopInformationToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getAllSimpleLoopInformationToolStripMenuItem.Text = "Get All Simple Loop Information";
            this.getAllSimpleLoopInformationToolStripMenuItem.Click += new System.EventHandler(this.getAllSimpleLoopInformationToolStripMenuItem_Click);
            // 
            // getAllReachingPathsToolStripMenuItem
            // 
            this.getAllReachingPathsToolStripMenuItem.Name = "getAllReachingPathsToolStripMenuItem";
            this.getAllReachingPathsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getAllReachingPathsToolStripMenuItem.Text = "Get All Reaching Paths";
            this.getAllReachingPathsToolStripMenuItem.Click += new System.EventHandler(this.getAllReachingPathsToolStripMenuItem_Click);
            // 
            // getAllSESERegionsToolStripMenuItem
            // 
            this.getAllSESERegionsToolStripMenuItem.Name = "getAllSESERegionsToolStripMenuItem";
            this.getAllSESERegionsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getAllSESERegionsToolStripMenuItem.Text = "Get All SESE Regions";
            this.getAllSESERegionsToolStripMenuItem.Click += new System.EventHandler(this.getAllSESERegionsToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 419);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(673, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graph Data";
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(667, 387);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.textBox1);
            this.splitContainer2.Panel2.Controls.Add(this.button2);
            this.splitContainer2.Size = new System.Drawing.Size(323, 387);
            this.splitContainer2.SplitterDistance = 310;
            this.splitContainer2.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(323, 310);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeToolStripMenuItem,
            this.removeNodeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            this.addNodeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.addNodeToolStripMenuItem.Text = "Add Node";
            this.addNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
            // 
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.removeNodeToolStripMenuItem.Text = "Remove Node";
            this.removeNodeToolStripMenuItem.Click += new System.EventHandler(this.removeNodeToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Text";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(284, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label4);
            this.splitContainer3.Panel2.Controls.Add(this.button1);
            this.splitContainer3.Panel2.Controls.Add(this.textBox2);
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Panel2.Controls.Add(this.comboBox2);
            this.splitContainer3.Panel2.Controls.Add(this.label1);
            this.splitContainer3.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer3.Size = new System.Drawing.Size(340, 387);
            this.splitContainer3.SplitterDistance = 263;
            this.splitContainer3.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.ContextMenuStrip = this.contextMenuStrip2;
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.IntegralHeight = false;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(0, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(340, 263);
            this.listBox2.TabIndex = 0;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEdgeToolStripMenuItem,
            this.removeEdgeToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(141, 48);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // addEdgeToolStripMenuItem
            // 
            this.addEdgeToolStripMenuItem.Name = "addEdgeToolStripMenuItem";
            this.addEdgeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addEdgeToolStripMenuItem.Text = "Add Edge";
            this.addEdgeToolStripMenuItem.Click += new System.EventHandler(this.addEdgeToolStripMenuItem_Click);
            // 
            // removeEdgeToolStripMenuItem
            // 
            this.removeEdgeToolStripMenuItem.Name = "removeEdgeToolStripMenuItem";
            this.removeEdgeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.removeEdgeToolStripMenuItem.Text = "Remove Edge";
            this.removeEdgeToolStripMenuItem.Click += new System.EventHandler(this.removeEdgeToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Text";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(34, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(284, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(34, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(34, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.splitContainer4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(673, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Render View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.AutoScroll = true;
            this.splitContainer4.Panel1.Controls.Add(this.pb1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.rtb1);
            this.splitContainer4.Size = new System.Drawing.Size(667, 387);
            this.splitContainer4.SplitterDistance = 222;
            this.splitContainer4.TabIndex = 0;
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(-3, -3);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(100, 50);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb1.TabIndex = 1;
            this.pb1.TabStop = false;
            // 
            // rtb1
            // 
            this.rtb1.DetectUrls = false;
            this.rtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rtb1.Location = new System.Drawing.Point(0, 0);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(667, 161);
            this.rtb1.TabIndex = 3;
            this.rtb1.Text = "";
            this.rtb1.WordWrap = false;
            // 
            // getTopologicalOrderToolStripMenuItem
            // 
            this.getTopologicalOrderToolStripMenuItem.Name = "getTopologicalOrderToolStripMenuItem";
            this.getTopologicalOrderToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getTopologicalOrderToolStripMenuItem.Text = "Get Topological Order";
            this.getTopologicalOrderToolStripMenuItem.Click += new System.EventHandler(this.getTopologicalOrderToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 443);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Directed Graph Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeEdgeToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getPostOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getPreOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getDominatorTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getPostDominatorTreeToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem checkForCyclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getStronglyConnectedComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getAllSimpleCyclePathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getAllSimpleLoopsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getAllBackedgesToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.ToolStripMenuItem getAllSimpleLoopInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getAllReachingPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getAllSESERegionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getTopologicalOrderToolStripMenuItem;
    }
}

