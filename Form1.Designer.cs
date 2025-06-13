namespace WindowProgrammingProject
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
            groupBox1 = new GroupBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            label8 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(492, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(479, 216);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "사용자 입력";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(186, 136);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(195, 31);
            textBox3.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "국민", "신한", "우리", "하나", "농협", "기업", "카카오", "토스", "시티", "" });
            comboBox1.Location = new Point(107, 134);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(73, 33);
            comboBox1.TabIndex = 9;
            comboBox1.Text = "은행";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(2, 134);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 8;
            label8.Text = "보낼계좌";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(107, 179);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(274, 31);
            dateTimePicker1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(387, 169);
            button1.Name = "button1";
            button1.Size = new Size(86, 45);
            button1.TabIndex = 6;
            button1.Text = "추가";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(107, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(274, 31);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(107, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(274, 31);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 179);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 2;
            label3.Text = "기한";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 90);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 1;
            label2.Text = "금액";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 40);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 0;
            label1.Text = "지출명";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(67, 50);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(383, 186);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(168, 90);
            label7.Name = "label7";
            label7.Size = new Size(60, 25);
            label7.TabIndex = 3;
            label7.Text = "label7";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(168, 46);
            label6.Name = "label6";
            label6.Size = new Size(60, 25);
            label6.TabIndex = 2;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 90);
            label5.Name = "label5";
            label5.Size = new Size(130, 25);
            label5.TabIndex = 1;
            label5.Text = "총 지출 합계 : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 46);
            label4.Name = "label4";
            label4.Size = new Size(124, 25);
            label4.TabIndex = 0;
            label4.Text = "공과금 개수 : ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(67, 259);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(832, 252);
            dataGridView1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(905, 328);
            button2.Name = "button2";
            button2.Size = new Size(60, 45);
            button2.TabIndex = 8;
            button2.Text = "지불";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(905, 391);
            button3.Name = "button3";
            button3.Size = new Size(60, 45);
            button3.TabIndex = 9;
            button3.Text = "삭제";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1042, 532);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(groupBox2);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Label label5;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Button button2;
        private Button button3;
        private Label label7;
        private Label label6;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Label label8;
    }
}
