using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowProgrammingProject
{
    public partial class Form3 : Form
    {
        private Bill bill;

        public Form3(Bill selectedBill)
        {
            InitializeComponent();
            this.bill = selectedBill;

            // 기존 값 채우기
            textBox1.Text = bill.Name;
            textBox2.Text = bill.Cost.ToString();
            dateTimePicker1.Value = bill.DeadLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox2.Text, out int cost))
            {
                MessageBox.Show("유효한 값을 입력하세요.");
                return;
            }

            bill.Name = textBox1.Text.Trim();
            bill.Cost = cost;
            bill.DeadLine = dateTimePicker1.Value.Date;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show($"정말 '{bill.Name}'을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                BillManager.Bills.Remove(bill);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
