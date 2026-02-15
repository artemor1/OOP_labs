namespace MyComplexCalculator
{
    partial class Form2
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
            this.PanelMod2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelMod1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.tbValueB = new System.Windows.Forms.TextBox();
            this.tbValueA = new System.Windows.Forms.TextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.PanelMod2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PanelMod1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMod2
            // 
            this.PanelMod2.Controls.Add(this.button2);
            this.PanelMod2.Controls.Add(this.dataGridView1);
            this.PanelMod2.Location = new System.Drawing.Point(0, 0);
            this.PanelMod2.Name = "PanelMod2";
            this.PanelMod2.Size = new System.Drawing.Size(801, 453);
            this.PanelMod2.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(358, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "switch to calculator";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(34, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(143, 283);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Текущий сигнал";
            this.Column1.Name = "Column1";
            // 
            // PanelMod1
            // 
            this.PanelMod1.AutoSize = true;
            this.PanelMod1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelMod1.Controls.Add(this.button1);
            this.PanelMod1.Controls.Add(this.label4);
            this.PanelMod1.Controls.Add(this.label3);
            this.PanelMod1.Controls.Add(this.label2);
            this.PanelMod1.Controls.Add(this.label1);
            this.PanelMod1.Controls.Add(this.cbOperator);
            this.PanelMod1.Controls.Add(this.tbResult);
            this.PanelMod1.Controls.Add(this.tbValueB);
            this.PanelMod1.Controls.Add(this.tbValueA);
            this.PanelMod1.Controls.Add(this.btnCalc);
            this.PanelMod1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMod1.Location = new System.Drawing.Point(0, 0);
            this.PanelMod1.Name = "PanelMod1";
            this.PanelMod1.Size = new System.Drawing.Size(800, 450);
            this.PanelMod1.TabIndex = 19;
            this.PanelMod1.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMod1_Paint_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "switch to signal editor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(611, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Результат";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Значение Б";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Оператор";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Значение А";
            // 
            // cbOperator
            // 
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Items.AddRange(new object[] {
            "\t+",
            "\t-",
            "\t*",
            "\t|a|",
            "\t|b|",
            "\tscalar"});
            this.cbOperator.Location = new System.Drawing.Point(257, 167);
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(121, 21);
            this.cbOperator.TabIndex = 13;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(590, 168);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(100, 20);
            this.tbResult.TabIndex = 12;
            // 
            // tbValueB
            // 
            this.tbValueB.Location = new System.Drawing.Point(419, 167);
            this.tbValueB.Name = "tbValueB";
            this.tbValueB.Size = new System.Drawing.Size(100, 20);
            this.tbValueB.TabIndex = 11;
            // 
            // tbValueA
            // 
            this.tbValueA.Location = new System.Drawing.Point(108, 167);
            this.tbValueA.Name = "tbValueA";
            this.tbValueA.Size = new System.Drawing.Size(100, 20);
            this.tbValueA.TabIndex = 10;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(382, 283);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 9;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelMod1);
            this.Controls.Add(this.PanelMod2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.PanelMod2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PanelMod1.ResumeLayout(false);
            this.PanelMod1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Panel PanelMod2;
        public System.Windows.Forms.Panel PanelMod1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOperator;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.TextBox tbValueB;
        private System.Windows.Forms.TextBox tbValueA;
        private System.Windows.Forms.Button btnCalc;
    }
}

