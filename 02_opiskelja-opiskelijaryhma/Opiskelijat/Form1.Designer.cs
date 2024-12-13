namespace Opiskelijat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            numericUpDown1DeleteStudent = new NumericUpDown();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1DeleteStudent).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(798, 188);
            dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(0, 194);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(34, 398);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(125, 27);
            textBoxFirstName.TabIndex = 3;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(165, 398);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(125, 27);
            textBoxLastName.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(296, 398);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(453, 398);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "Lisää";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1DeleteStudent
            // 
            numericUpDown1DeleteStudent.Location = new Point(545, 205);
            numericUpDown1DeleteStudent.Name = "numericUpDown1DeleteStudent";
            numericUpDown1DeleteStudent.Size = new Size(150, 27);
            numericUpDown1DeleteStudent.TabIndex = 10;
            numericUpDown1DeleteStudent.ValueChanged += numericUpDown1DeleteStudent_ValueChanged;
            // 
            // button2
            // 
            button2.Location = new Point(545, 238);
            button2.Name = "button2";
            button2.Size = new Size(150, 29);
            button2.TabIndex = 11;
            button2.Text = "delete student";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(numericUpDown1DeleteStudent);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1DeleteStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private ComboBox comboBox2;
        private Button button1;
        private NumericUpDown numericUpDown1DeleteStudent;
        private Button button2;
    }
}
