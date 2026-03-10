namespace Lab_3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tobinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSignalFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.genSinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.genNoisedSinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomNoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalNoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVDDenoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correlationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aKFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aKFAcycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vKFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.chBox = new System.Windows.Forms.CheckedListBox();
            this.bParse = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generatorToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.fourierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.loadSignalFromFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totxtToolStripMenuItem,
            this.tobinToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // totxtToolStripMenuItem
            // 
            this.totxtToolStripMenuItem.Name = "totxtToolStripMenuItem";
            this.totxtToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.totxtToolStripMenuItem.Text = "To .txt";
            this.totxtToolStripMenuItem.Click += new System.EventHandler(this.totxtToolStripMenuItem_Click);
            // 
            // tobinToolStripMenuItem
            // 
            this.tobinToolStripMenuItem.Name = "tobinToolStripMenuItem";
            this.tobinToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.tobinToolStripMenuItem.Text = "To .bin";
            this.tobinToolStripMenuItem.Click += new System.EventHandler(this.tobinToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShowShortcutKeys = false;
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadSignalFromFileToolStripMenuItem
            // 
            this.loadSignalFromFileToolStripMenuItem.Name = "loadSignalFromFileToolStripMenuItem";
            this.loadSignalFromFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.loadSignalFromFileToolStripMenuItem.Text = "Load signal from file";
            this.loadSignalFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadSignalFromFileToolStripMenuItem_Click);
            // 
            // generatorToolStripMenuItem
            // 
            this.generatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPropertiesToolStripMenuItem,
            this.generateSignalToolStripMenuItem,
            this.genSinToolStripMenuItem,
            this.genNoisedSinToolStripMenuItem});
            this.generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            this.generatorToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.generatorToolStripMenuItem.Text = "Generator";
            // 
            // showPropertiesToolStripMenuItem
            // 
            this.showPropertiesToolStripMenuItem.Name = "showPropertiesToolStripMenuItem";
            this.showPropertiesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showPropertiesToolStripMenuItem.Text = "ShowProperties";
            this.showPropertiesToolStripMenuItem.Click += new System.EventHandler(this.showPropertiesToolStripMenuItem_Click);
            // 
            // generateSignalToolStripMenuItem
            // 
            this.generateSignalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomToolStripMenuItem,
            this.toolStripMenuItem1});
            this.generateSignalToolStripMenuItem.Name = "generateSignalToolStripMenuItem";
            this.generateSignalToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.generateSignalToolStripMenuItem.Text = "Generate Noise Signal";
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.randomToolStripMenuItem.Text = "Random";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.randomToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItem1.Text = "Normal";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // genSinToolStripMenuItem
            // 
            this.genSinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sinToolStripMenuItem,
            this.amToolStripMenuItem,
            this.phMToolStripMenuItem,
            this.phmToolStripMenuItem1});
            this.genSinToolStripMenuItem.Name = "genSinToolStripMenuItem";
            this.genSinToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.genSinToolStripMenuItem.Text = "Gen Signal";
            this.genSinToolStripMenuItem.Click += new System.EventHandler(this.genSinToolStripMenuItem_Click);
            // 
            // sinToolStripMenuItem
            // 
            this.sinToolStripMenuItem.Name = "sinToolStripMenuItem";
            this.sinToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sinToolStripMenuItem.Text = "Sin";
            this.sinToolStripMenuItem.Click += new System.EventHandler(this.sinToolStripMenuItem_Click);
            // 
            // amToolStripMenuItem
            // 
            this.amToolStripMenuItem.Name = "amToolStripMenuItem";
            this.amToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.amToolStripMenuItem.Text = "Am";
            this.amToolStripMenuItem.Click += new System.EventHandler(this.amToolStripMenuItem_Click);
            // 
            // phMToolStripMenuItem
            // 
            this.phMToolStripMenuItem.Name = "phMToolStripMenuItem";
            this.phMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.phMToolStripMenuItem.Text = "Fm";
            this.phMToolStripMenuItem.Click += new System.EventHandler(this.phMToolStripMenuItem_Click);
            // 
            // phmToolStripMenuItem1
            // 
            this.phmToolStripMenuItem1.Name = "phmToolStripMenuItem1";
            this.phmToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.phmToolStripMenuItem1.Text = "Phm";
            this.phmToolStripMenuItem1.Click += new System.EventHandler(this.phmToolStripMenuItem1_Click);
            // 
            // genNoisedSinToolStripMenuItem
            // 
            this.genNoisedSinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomNoiseToolStripMenuItem,
            this.normalNoiseToolStripMenuItem});
            this.genNoisedSinToolStripMenuItem.Name = "genNoisedSinToolStripMenuItem";
            this.genNoisedSinToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.genNoisedSinToolStripMenuItem.Text = "Add Noise";
            // 
            // randomNoiseToolStripMenuItem
            // 
            this.randomNoiseToolStripMenuItem.Name = "randomNoiseToolStripMenuItem";
            this.randomNoiseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.randomNoiseToolStripMenuItem.Text = "Random Noise";
            this.randomNoiseToolStripMenuItem.Click += new System.EventHandler(this.randomNoiseToolStripMenuItem_Click);
            // 
            // normalNoiseToolStripMenuItem
            // 
            this.normalNoiseToolStripMenuItem.Name = "normalNoiseToolStripMenuItem";
            this.normalNoiseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.normalNoiseToolStripMenuItem.Text = "Normal Noise";
            this.normalNoiseToolStripMenuItem.Click += new System.EventHandler(this.normalNoiseToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.calcToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.showToolStripMenuItem.Text = "Show Histogram Properties";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // calcToolStripMenuItem
            // 
            this.calcToolStripMenuItem.Name = "calcToolStripMenuItem";
            this.calcToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.calcToolStripMenuItem.Text = "Calc Histogram";
            this.calcToolStripMenuItem.Click += new System.EventHandler(this.calcToolStripMenuItem_Click);
            // 
            // fourierToolStripMenuItem
            // 
            this.fourierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sVDDenoiseToolStripMenuItem,
            this.fFTToolStripMenuItem,
            this.correlationToolStripMenuItem});
            this.fourierToolStripMenuItem.Name = "fourierToolStripMenuItem";
            this.fourierToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.fourierToolStripMenuItem.Text = "Processing";
            // 
            // sVDDenoiseToolStripMenuItem
            // 
            this.sVDDenoiseToolStripMenuItem.Name = "sVDDenoiseToolStripMenuItem";
            this.sVDDenoiseToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sVDDenoiseToolStripMenuItem.Text = "SVD denoise";
            this.sVDDenoiseToolStripMenuItem.Click += new System.EventHandler(this.sVDDenoiseToolStripMenuItem_Click);
            // 
            // fFTToolStripMenuItem
            // 
            this.fFTToolStripMenuItem.Name = "fFTToolStripMenuItem";
            this.fFTToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fFTToolStripMenuItem.Text = "Furier Transform";
            this.fFTToolStripMenuItem.Click += new System.EventHandler(this.fFTToolStripMenuItem_Click);
            // 
            // correlationToolStripMenuItem
            // 
            this.correlationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aKFToolStripMenuItem,
            this.aKFAcycleToolStripMenuItem,
            this.vKFToolStripMenuItem});
            this.correlationToolStripMenuItem.Name = "correlationToolStripMenuItem";
            this.correlationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.correlationToolStripMenuItem.Text = "Correlation";
            // 
            // aKFToolStripMenuItem
            // 
            this.aKFToolStripMenuItem.Name = "aKFToolStripMenuItem";
            this.aKFToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aKFToolStripMenuItem.Text = "AKF";
            this.aKFToolStripMenuItem.Click += new System.EventHandler(this.aKFToolStripMenuItem_Click);
            // 
            // aKFAcycleToolStripMenuItem
            // 
            this.aKFAcycleToolStripMenuItem.Name = "aKFAcycleToolStripMenuItem";
            this.aKFAcycleToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aKFAcycleToolStripMenuItem.Text = "AKF acycle";
            this.aKFAcycleToolStripMenuItem.Click += new System.EventHandler(this.aKFAcycleToolStripMenuItem_Click);
            // 
            // vKFToolStripMenuItem
            // 
            this.vKFToolStripMenuItem.Name = "vKFToolStripMenuItem";
            this.vKFToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.vKFToolStripMenuItem.Text = "VKF";
            this.vKFToolStripMenuItem.Click += new System.EventHandler(this.vKFToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.43434F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.56565F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 426);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(243, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 179);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zedGraphControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 153);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Signal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(540, 147);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zedGraphControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 153);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Processed Signal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl3.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(540, 147);
            this.zedGraphControl3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.bParse);
            this.panel1.Controls.Add(this.chBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 179);
            this.panel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(80, 179);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Data";
            this.Column1.Name = "Column1";
            this.Column1.Width = 55;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(243, 188);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(554, 235);
            this.tabControl2.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.zedGraphControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(546, 209);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Histogram";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl2.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(540, 203);
            this.zedGraphControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.zedGraphControl4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(546, 209);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Table";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl4.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollGrace = 0D;
            this.zedGraphControl4.ScrollMaxX = 0D;
            this.zedGraphControl4.ScrollMaxY = 0D;
            this.zedGraphControl4.ScrollMaxY2 = 0D;
            this.zedGraphControl4.ScrollMinX = 0D;
            this.zedGraphControl4.ScrollMinY = 0D;
            this.zedGraphControl4.ScrollMinY2 = 0D;
            this.zedGraphControl4.Size = new System.Drawing.Size(540, 203);
            this.zedGraphControl4.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 188);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.29787F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.70213F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(234, 235);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 36);
            this.panel2.TabIndex = 9;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(113, 12);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "SVD";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(61, 12);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(44, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Hist";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Gen";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.propertyGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 187);
            this.panel3.TabIndex = 10;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(228, 187);
            this.propertyGrid1.TabIndex = 9;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView2.Location = new System.Drawing.Point(154, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(80, 179);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Decoded Data";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип сигнала";
            // 
            // chBox
            // 
            this.chBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chBox.FormattingEnabled = true;
            this.chBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.chBox.Items.AddRange(new object[] {
            "Am",
            "Fm",
            "Phm"});
            this.chBox.Location = new System.Drawing.Point(85, 52);
            this.chBox.Name = "chBox";
            this.chBox.Size = new System.Drawing.Size(63, 49);
            this.chBox.TabIndex = 3;
            this.chBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chB_ItemCheck);
            // 
            // bParse
            // 
            this.bParse.Location = new System.Drawing.Point(85, 133);
            this.bParse.Name = "bParse";
            this.bParse.Size = new System.Drawing.Size(63, 23);
            this.bParse.TabIndex = 4;
            this.bParse.Text = "Parse";
            this.bParse.UseVisualStyleBackColor = true;
            this.bParse.Click += new System.EventHandler(this.bParse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tobinToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateSignalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genSinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSignalFromFileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calcToolStripMenuItem;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem fourierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVDDenoiseToolStripMenuItem;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.ToolStripMenuItem genNoisedSinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTToolStripMenuItem;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private System.Windows.Forms.ToolStripMenuItem randomNoiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalNoiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correlationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aKFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aKFAcycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vKFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phmToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bParse;
        private System.Windows.Forms.CheckedListBox chBox;
    }
}

