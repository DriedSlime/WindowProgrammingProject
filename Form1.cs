using System.Windows.Forms;

namespace WindowProgrammingProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // �Ѿ� ���
            label4.Text = "�� ������ �ݾ�: " + BillManager.Total;

            // ������ �׸��� ����
            dataGridView1.ReadOnly = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.DataSource = BillManager.Bills;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;

            // ��ư �̺�Ʈ ����
            button1.Click += button1_Click; // �߰�
            button2.Click += button2_Click; // ����
            button3.Click += button3_Click; // ����
        }

        // �� ���� �� �ؽ�Ʈ�ڽ��� �� ǥ��
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null) return;

                Bill bill = dataGridView1.CurrentRow.DataBoundItem as Bill;
                if (bill != null)
                {
                    textBox4.Text = bill.Name;
                    textBox5.Text = bill.Cost.ToString();
                }
            }
            catch (Exception) { }
        }

        // �߰� ��ư Ŭ��
        private void button1_Click(object sender, EventArgs e)
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
                    DeadLine = dateTimePicker1.Value.Date // �ð� ����
                };
                BillManager.Bills.Add(bill);
                BillManager.Save();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BillManager.Bills;
                label4.Text = "�� ������ �ݾ�: " + BillManager.Total;
            }
            catch (Exception ex)
            {
                MessageBox.Show("���� �߻�: " + ex.Message);
            }
        }

        // ���� ��ư Ŭ��
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            Bill selectedBill = dataGridView1.CurrentRow.DataBoundItem as Bill;
            if (selectedBill == null) return;

            var confirm = MessageBox.Show(
                $"���� '{selectedBill.Name}'��(��) �����Ͻðڽ��ϱ�?",
                "���� Ȯ��",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                BillManager.Bills.Remove(selectedBill);
                BillManager.Save();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BillManager.Bills;
                label4.Text = "�� ������ �ݾ�: " + BillManager.Total;
                MessageBox.Show("�����Ǿ����ϴ�.");
            }
        }

        // ���� ��ư Ŭ��
        private void button3_Click(object sender, EventArgs e)
        {
            Bill selectedBill = dataGridView1.CurrentRow.DataBoundItem as Bill;
            if (selectedBill == null) return;

            string newName = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("���� �̸��� �Է��ϼ���.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int newCost))
            {
                MessageBox.Show("�ݾ��� ���ڷ� �Է��ϼ���.");
                return;
            }

            if (BillManager.Bills.Any(x => x != selectedBill && x.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("�̹� �����ϴ� ���� �̸��Դϴ�.");
                return;
            }

            selectedBill.Name = newName;
            selectedBill.Cost = newCost;

            BillManager.Save();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BillManager.Bills;
            label4.Text = "�� ������ �ݾ�: " + BillManager.Total;

            MessageBox.Show("�����Ǿ����ϴ�.");
        }
    }
}