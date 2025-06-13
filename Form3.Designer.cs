namespace WindowProgrammingProject
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(397, 30);
            button1.Name = "button1";
            button1.Size = new Size(112, 38);
            button1.TabIndex = 2;
            button1.Text = "확인";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(121, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(255, 31);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(121, 88);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(255, 31);
            textBox2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(121, 197);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(255, 31);
            dateTimePicker1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 40);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 6;
            label1.Text = "공과금";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 91);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 7;
            label2.Text = "금액";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 202);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 8;
            label3.Text = "지불기한";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 149);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 9;
            label4.Text = "보낼 계좌";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(121, 141);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(69, 33);
            comboBox1.TabIndex = 10;
            comboBox1.Text = "은행";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(196, 141);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(180, 31);
            textBox3.TabIndex = 11;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 240);
            Controls.Add(textBox3);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private TextBox textBox3;
    }
}