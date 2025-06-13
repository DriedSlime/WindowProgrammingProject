using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowProgrammingProject
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // ������ �׸��� ����
            dataGridView1.ReadOnly = true;  // Form1���� �����ͱ׸��� ���� �Ұ�
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.DataSource = BillManager.Bills;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick; // �����ͱ׸��� �� ����Ŭ��
            dataGridView1.Columns["BankName"].Visible = false;
            dataGridView1.Columns["AccountNumber"].Visible = false;

            // ��ư �̺�Ʈ ����
            button1.Click += Button1_Click; // �߰�
            button2.Click += Button2_Click; // ����
            button3.Click += Button3_Click; // ����

            label6.Text = BillManager.Bills.Count.ToString() + " ��";
            label7.Text = Total().ToString();
        }

        // �߰�,����, ������ �����ͱ׸��带 ���ΰ�ħ�� �Լ� 
        public void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BillManager.Bills;
            // ������ ���¹�ȣ�� �����
            dataGridView1.Columns["BankName"].Visible = false;
            dataGridView1.Columns["AccountNumber"].Visible = false;
            label6.Text = BillManager.Bills.Count.ToString() + " ��";
            label7.Text = Total().ToString();
        }

        // �����ͱ׸��� �� ����Ŭ�� �� ���� �� ����
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ��� Ŭ�� ��ȿ

            var selectedBill = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bill;
            if (selectedBill == null) return;

            // Form3�� ����, ���õ� Bill ����
            Form3 editForm = new Form3(selectedBill);
            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                BillManager.Save();
                RefreshGrid(); // ���� �Ǵ� ������ ��� ����
            }
        }

        // �߰� ��ư Ŭ��
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox2.Text, out int cost))
                {
                    MessageBox.Show("�̸��� �Է��ϰ�, �ݾ��� ���ڷ� �Է��ϼ���.");
                    return;
                }

                if (BillManager.Bills.Exists(x => x.Name == textBox1.Text))
                {
                    MessageBox.Show("�ߺ��Ǵ� �����Դϴ�.");
                    return;
                }

                Bill bill = new Bill()
                {
                    Name = textBox1.Text,
                    Cost = cost,
                    IsPaid = "������",
                    DeadLine = dateTimePicker1.Value.Date,// ��, ��, ���ϸ� ǥ��   
                    BankName = comboBox1.Text,
                    AccountNumber = textBox3.Text
                };
                BillManager.Bills.Add(bill);
                BillManager.Save();

                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("���� �߻�: " + ex.Message);
            }
        }

        // ���� �Ϸ� ��ư
        private void Button2_Click(object sender, EventArgs e)
        {
            var selectedBill = dataGridView1.CurrentRow.DataBoundItem as Bill;
            if (selectedBill == null) return;

            selectedBill.IsPaid = "���ҵ�";
            BillManager.Save();
            RefreshGrid();
            MessageBox.Show("���� �Ϸ� ó���Ǿ����ϴ�.");
        }

        // ���� ��ư
        private void Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var selectedBill = dataGridView1.CurrentRow.DataBoundItem as Bill;
            if (selectedBill == null) return;

            var confirm = MessageBox.Show($"���� '{selectedBill.Name}'�� �����Ͻðڽ��ϱ�?", "Ȯ��", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                BillManager.Bills.Remove(selectedBill);
                BillManager.Save();

                RefreshGrid();
                MessageBox.Show("�����Ǿ����ϴ�.");
            }
        }

        // ������ ��ҵ��� �հ� ��ȯ
        private int Total()
        {
            return BillManager.Bills
                .Where(b => b.IsPaid == "���ҵ�")
                .Sum(b => b.Cost);
        }
    }
}