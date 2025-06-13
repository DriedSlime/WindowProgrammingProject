using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowProgrammingProject
{
    public partial class Form3 : Form
    {
        private Bill bill;
        
        Form1 mainForm = new Form1();

        public Form3(Bill selectedBill)
        {
            InitializeComponent();
            this.bill = selectedBill;

            // 선택한 셀의 값 채우기
            textBox1.Text = bill.Name;
            textBox2.Text = bill.Cost.ToString();
            dateTimePicker1.Value = bill.DeadLine;
        }

        // 확인 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || !int.TryParse(textBox2.Text, out int cost))
            {
                MessageBox.Show("유효한 값을 입력하세요.");
                return;
            }

            bill.Name = textBox1.Text.Trim();
            bill.Cost = cost;
            bill.DeadLine = dateTimePicker1.Value.Date;

            this.DialogResult = DialogResult.OK;
            BillManager.Save();

            mainForm.RefreshGrid();
            this.Close();
        }

        // 삭제 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show($"정말 '{bill.Name}'을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                BillManager.Bills.Remove(this.bill);
                BillManager.Save();

                mainForm.RefreshGrid();
                MessageBox.Show("삭제되었습니다.");
                this.Close();
            }
        }
    }
}
