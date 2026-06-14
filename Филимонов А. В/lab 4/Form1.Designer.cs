namespace ImageProcessingLab
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToGreyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussLowpassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussHighpassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spatialLowpassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spatialHighpassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findFragmentSpatialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findFragmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSource = new System.Windows.Forms.TabPage();
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabDest = new System.Windows.Forms.TabPage();
            this.pbDest = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            this.tabDest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDest)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.saveImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openImageToolStripMenuItem.Text = "&Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveImageToolStripMenuItem.Text = "&Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToGreyToolStripMenuItem,
            this.showFFTToolStripMenuItem,
            this.gaussLowpassToolStripMenuItem,
            this.gaussHighpassToolStripMenuItem,
            this.spatialLowpassToolStripMenuItem,
            this.spatialHighpassToolStripMenuItem,
            this.findFragmentSpatialToolStripMenuItem,
            this.findFragmentToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // convertToGreyToolStripMenuItem
            // 
            this.convertToGreyToolStripMenuItem.Name = "convertToGreyToolStripMenuItem";
            this.convertToGreyToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.convertToGreyToolStripMenuItem.Text = "&Convert to Grey";
            this.convertToGreyToolStripMenuItem.Click += new System.EventHandler(this.convertToGreyToolStripMenuItem_Click);
            // 
            // showFFTToolStripMenuItem
            // 
            this.showFFTToolStripMenuItem.Name = "showFFTToolStripMenuItem";
            this.showFFTToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.showFFTToolStripMenuItem.Text = "&Show FFT Spectrum";
            this.showFFTToolStripMenuItem.Click += new System.EventHandler(this.showFFTToolStripMenuItem_Click);
            // 
            // gaussLowpassToolStripMenuItem
            // 
            this.gaussLowpassToolStripMenuItem.Name = "gaussLowpassToolStripMenuItem";
            this.gaussLowpassToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.gaussLowpassToolStripMenuItem.Text = "Gauss &Lowpass Filter";
            this.gaussLowpassToolStripMenuItem.Click += new System.EventHandler(this.gaussLowpassToolStripMenuItem_Click);
            // 
            // gaussHighpassToolStripMenuItem
            // 
            this.gaussHighpassToolStripMenuItem.Name = "gaussHighpassToolStripMenuItem";
            this.gaussHighpassToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.gaussHighpassToolStripMenuItem.Text = "Gauss &Highpass Filter";
            this.gaussHighpassToolStripMenuItem.Click += new System.EventHandler(this.gaussHighpassToolStripMenuItem_Click);
            // 
            // spatialLowpassToolStripMenuItem
            // 
            this.spatialLowpassToolStripMenuItem.Name = "spatialLowpassToolStripMenuItem";
            this.spatialLowpassToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.spatialLowpassToolStripMenuItem.Text = "Spatial &Lowpass Filter (Blur)";
            this.spatialLowpassToolStripMenuItem.Click += new System.EventHandler(this.spatialLowpassToolStripMenuItem_Click);
            // 
            // spatialHighpassToolStripMenuItem
            // 
            this.spatialHighpassToolStripMenuItem.Name = "spatialHighpassToolStripMenuItem";
            this.spatialHighpassToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.spatialHighpassToolStripMenuItem.Text = "Spatial &Highpass Filter (Edges)";
            this.spatialHighpassToolStripMenuItem.Click += new System.EventHandler(this.spatialHighpassToolStripMenuItem_Click);
            // 
            // findFragmentSpatialToolStripMenuItem
            // 
            this.findFragmentSpatialToolStripMenuItem.Name = "findFragmentSpatialToolStripMenuItem";
            this.findFragmentSpatialToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.findFragmentSpatialToolStripMenuItem.Text = "Find Fragment (Spatial Domain)";
            this.findFragmentSpatialToolStripMenuItem.Click += new System.EventHandler(this.findFragmentSpatialToolStripMenuItem_Click);
            // 
            // findFragmentToolStripMenuItem
            // 
            this.findFragmentToolStripMenuItem.Name = "findFragmentToolStripMenuItem";
            this.findFragmentToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.findFragmentToolStripMenuItem.Text = "Find Fragment (Frequency Domain)";
            this.findFragmentToolStripMenuItem.Click += new System.EventHandler(this.findFragmentToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSource);
            this.tabControl1.Controls.Add(this.tabDest);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 537);
            this.tabControl1.TabIndex = 1;
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.pbSource);
            this.tabSource.Controls.Add(this.propertyGrid1);
            this.tabSource.Location = new System.Drawing.Point(4, 22);
            this.tabSource.Name = "tabSource";
            this.tabSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabSource.Size = new System.Drawing.Size(976, 511);
            this.tabSource.TabIndex = 0;
            this.tabSource.Text = "Source Image";
            // 
            // pbSource
            // 
            this.pbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSource.Location = new System.Drawing.Point(3, 3);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(970, 310);
            this.pbSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSource.TabIndex = 0;
            this.pbSource.TabStop = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 313);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(970, 195);
            this.propertyGrid1.TabIndex = 1;
            // 
            // tabDest
            // 
            this.tabDest.Controls.Add(this.pbDest);
            this.tabDest.Location = new System.Drawing.Point(4, 22);
            this.tabDest.Name = "tabDest";
            this.tabDest.Padding = new System.Windows.Forms.Padding(3);
            this.tabDest.Size = new System.Drawing.Size(976, 511);
            this.tabDest.TabIndex = 1;
            this.tabDest.Text = "Result Image";
            // 
            // pbDest
            // 
            this.pbDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDest.Location = new System.Drawing.Point(3, 3);
            this.pbDest.Name = "pbDest";
            this.pbDest.Size = new System.Drawing.Size(970, 505);
            this.pbDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDest.TabIndex = 0;
            this.pbDest.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Image Processing Lab";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            this.tabDest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToGreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussLowpassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussHighpassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spatialLowpassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spatialHighpassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findFragmentSpatialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findFragmentToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSource;
        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage tabDest;
        private System.Windows.Forms.PictureBox pbDest;
    }
}