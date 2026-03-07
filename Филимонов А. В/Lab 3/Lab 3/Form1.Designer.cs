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
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.sVDDenoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.genNoisedSinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbRank = new System.Windows.Forms.TextBox();
            this.tbIterations = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.showPropertiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showPropertiesToolStripMenuItem.Text = "ShowProperties";
            this.showPropertiesToolStripMenuItem.Click += new System.EventHandler(this.showPropertiesToolStripMenuItem_Click);
            // 
            // generateSignalToolStripMenuItem
            // 
            this.generateSignalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomToolStripMenuItem,
            this.toolStripMenuItem1});
            this.generateSignalToolStripMenuItem.Name = "generateSignalToolStripMenuItem";
            this.generateSignalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generateSignalToolStripMenuItem.Text = "Generate Signal";
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
            this.genSinToolStripMenuItem.Name = "genSinToolStripMenuItem";
            this.genSinToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.genSinToolStripMenuItem.Text = "GenSin";
            this.genSinToolStripMenuItem.Click += new System.EventHandler(this.genSinToolStripMenuItem_Click);
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
            this.sVDDenoiseToolStripMenuItem});
            this.fourierToolStripMenuItem.Name = "fourierToolStripMenuItem";
            this.fourierToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.fourierToolStripMenuItem.Text = "Processing";
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
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbIterations);
            this.panel1.Controls.Add(this.tbRank);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 179);
            this.panel1.TabIndex = 6;
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
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(546, 209);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.checkBox3.Size = new System.Drawing.Size(58, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "Fourier";
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
            // sVDDenoiseToolStripMenuItem
            // 
            this.sVDDenoiseToolStripMenuItem.Name = "sVDDenoiseToolStripMenuItem";
            this.sVDDenoiseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sVDDenoiseToolStripMenuItem.Text = "SVD denoise";
            this.sVDDenoiseToolStripMenuItem.Click += new System.EventHandler(this.sVDDenoiseToolStripMenuItem_Click);
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
            // genNoisedSinToolStripMenuItem
            // 
            this.genNoisedSinToolStripMenuItem.Name = "genNoisedSinToolStripMenuItem";
            this.genNoisedSinToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.genNoisedSinToolStripMenuItem.Text = "GenNoisedSin";
            this.genNoisedSinToolStripMenuItem.Click += new System.EventHandler(this.genNoisedSinToolStripMenuItem_Click);
            // 
            // tbRank
            // 
            this.tbRank.Location = new System.Drawing.Point(14, 47);
            this.tbRank.Name = "tbRank";
            this.tbRank.Size = new System.Drawing.Size(44, 20);
            this.tbRank.TabIndex = 0;
            // 
            // tbIterations
            // 
            this.tbIterations.Location = new System.Drawing.Point(14, 94);
            this.tbIterations.Name = "tbIterations";
            this.tbIterations.Size = new System.Drawing.Size(44, 20);
            this.tbIterations.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ранг шумоподавления";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество итераций";
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIterations;
        private System.Windows.Forms.TextBox tbRank;
    }
}

