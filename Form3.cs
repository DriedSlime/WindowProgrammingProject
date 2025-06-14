using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PublicBillManager
{
    public partial class Form3 : Form
    {
        private Bill bill;

        Form1 mainForm = new Form1();

        public Form3(Bill selectedBill)
        {
            InitializeComponent();
            this.bill = selectedBill;

            // 버튼
            button1.Click += Button1_Click;

            // 선택한 셀의 값 채우기
            textBox1.Text = bill.Name;
            textBox2.Text = bill.Cost.ToString();
            dateTimePicker1.Value = bill.DeadLine;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(bill.BankName);
            textBox3.Text = bill.AccountNumber.ToString();
        }

        // 확인 버튼
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || !int.TryParse(textBox2.Text, out int cost))
            {
                MessageBox.Show("유효한 값을 입력하세요.");
                return;
            }
            if (comboBox1.SelectedIndex == -1 || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("은행 또는 계좌번호를 입력해주세요.");
                return;
            }

            // 값 적용
            bill.Name = textBox1.Text.Trim();
            bill.Cost = cost;
            bill.DeadLine = dateTimePicker1.Value.Date;
            bill.BankName = comboBox1.Text;
            bill.AccountNumber = textBox3.Text;

            // Form1에 확인 신호 보냄
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
