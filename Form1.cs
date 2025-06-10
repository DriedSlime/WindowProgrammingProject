using System.Windows.Forms;

namespace WindowProgrammingProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 데이터 그리드 설정
            dataGridView1.ReadOnly = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.DataSource = BillManager.Bills;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            // 버튼 이벤트 연결
            button1.Click += button1_Click; // 추가
        }

        // 추가,변경, 삭제시 데이터그리드를 새로고침할 함수 
        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BillManager.Bills;
            label4.Text = "총 지불할 금액: " + BillManager.Total;
        }

        // 셀 선택 시 텍스트박스에 값 표시
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null) return;

                Bill bill = dataGridView1.CurrentRow.DataBoundItem as Bill;
                if (bill != null)
                {
                    textBox1.Text = bill.Name;
                    textBox2.Text = bill.Cost.ToString();
                }
            }
            catch (Exception) { }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 헤더 클릭 방지

            var selectedBill = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bill;
            if (selectedBill == null) return;

            // Form3을 열고, 선택된 Bill 전달
            Form3 editForm = new Form3(selectedBill);
            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                BillManager.Save();
                RefreshGrid(); // 수정 또는 삭제된 경우 갱신
            }
        }


        // 추가 버튼 클릭
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox2.Text, out int cost))
                {
                    MessageBox.Show("이름을 입력하고, 금액은 숫자로 입력하세요.");
                    return;
                }

                if (BillManager.Bills.Exists(x => x.Name == textBox1.Text))
                {
                    MessageBox.Show("중복되는 명세서입니다.");
                    return;
                }

                Bill bill = new Bill()
                {
                    Name = textBox1.Text,
                    Cost = cost,
                    DeadLine = dateTimePicker1.Value.Date // 년, 월, 요일만 표시
                };
                BillManager.Bills.Add(bill);
                BillManager.Save();

                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 삭제 버튼 클릭
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            Bill selectedBill = dataGridView1.CurrentRow.DataBoundItem as Bill;
            if (selectedBill == null) return;

            var confirm = MessageBox.Show(
                $"정말 '{selectedBill.Name}'을(를) 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                BillManager.Bills.Remove(selectedBill);
                BillManager.Save();

                RefreshGrid();
                MessageBox.Show("삭제되었습니다.");
            }
        }

        // 수정 버튼 클릭
        private void button3_Click(object sender, EventArgs e)
        {
            Bill selectedBill = dataGridView1.CurrentRow.DataBoundItem as Bill;
            if (selectedBill == null) return;

            string newName = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("명세서 이름을 입력하세요.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int newCost))
            {
                MessageBox.Show("금액은 숫자로 입력하세요.");
                return;
            }

            if (BillManager.Bills.Any(x => x != selectedBill && x.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("이미 존재하는 명세서 이름입니다.");
                return;
            }

            selectedBill.Name = newName;
            selectedBill.Cost = newCost;

            BillManager.Save();

            RefreshGrid();

            MessageBox.Show("수정되었습니다.");
        }

    }
}