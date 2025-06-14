using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowProgrammingProject
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // 데이터 그리드 설정
            dataGridView1.ReadOnly = true;  // Form1에서 데이터그리드 수정 불가
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.DataSource = BillManager.Bills;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick; // 데이터그리드 셀 더블클릭
            dataGridView1.Columns["BankName"].Visible = false;              // BankName 표시 비활성화
            dataGridView1.Columns["AccountNumber"].Visible = false;         // AccountNumber 표시 비활성화
            dataGridView1.Columns["Bank"].Width = 236;                      // Bank열은 조금더 길게 조정


            // 버튼 이벤트 연결
            button1.Click += Button1_Click; // 추가
            button2.Click += Button2_Click; // 지불
            button3.Click += Button3_Click; // 삭제

            label6.Text = BillManager.Bills.Count.ToString() + " 개";
            label7.Text = Total().ToString();

            comboBox1.SelectedIndex = 0;
        }

        // 추가,변경, 삭제시 데이터그리드를 새로고침할 함수 
        public void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BillManager.Bills;

            // 은행명과 계좌번호는 숨기기
            if (dataGridView1.Columns.Contains("BankName"))
                dataGridView1.Columns["BankName"].Visible = false;
            if (dataGridView1.Columns.Contains("AccountNumber"))
                dataGridView1.Columns["AccountNumber"].Visible = false;

            if (dataGridView1.Columns.Contains("Bank"))
                dataGridView1.Columns["Bank"].Width = 236;

            label6.Text = BillManager.Bills.Count.ToString() + " 개";
            label7.Text = Total().ToString();
        }

        // 데이터그리드 셀 더블클릭 시 수정 폼 띄우기
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 헤더 클릭 무효

            Bill selectedBill = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bill;
            if (selectedBill == null) return;

            // Form3을 열고, 선택된 Bill 전달
            Form3 editForm = new Form3(selectedBill);

            var result = editForm.ShowDialog();

            // 확인 신호를 받으면 데이터 갱신
            if (result == DialogResult.OK)
            {
                BillManager.Save();
                RefreshGrid();
            }
        }

        // 추가 버튼 클릭
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터 유효성 검사
                if (textBox1.Text.Trim() == "" || !int.TryParse(textBox2.Text, out int cost))
                {
                    MessageBox.Show("이름을 입력하고, 금액은 숫자로 입력하세요.");
                    return;
                }
                // 이름은 중복되지 않게 제한
                if (BillManager.Bills.Exists(x => x.Name == textBox1.Text))
                {
                    MessageBox.Show("중복되는 명세서입니다.");
                    return;
                }
                if (comboBox1.SelectedIndex == -1 || textBox3.Text.Trim() == "")
                {
                    MessageBox.Show("은행 또는 계좌번호를 입력해주세요");
                    return;
                }

                // 새로운 명세서 생성
                Bill bill = new Bill()
                {
                    Name = textBox1.Text,
                    Cost = cost,
                    IsPaid = "미지불",
                    DeadLine = dateTimePicker1.Value.Date,// 년, 월, 요일만 표시   
                    BankName = comboBox1.Text,
                    AccountNumber = textBox3.Text
                };
                BillManager.Bills.Add(bill);
                BillManager.Save();

                // UI에 입력한 데이터들을 모두 초기화
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = 0;
                textBox3.Text = "";

                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 지불 완료 버튼
        private void Button2_Click(object sender, EventArgs e)
        {
            Bill selectedBill = dataGridView1.CurrentRow.DataBoundItem as Bill;
            if (selectedBill == null) return;

            selectedBill.IsPaid = "지불됨";
            BillManager.Save();
            RefreshGrid();
            MessageBox.Show("지불 완료 처리되었습니다.");
        }

        // 삭제 버튼
        private void Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var selectedBill = dataGridView1.CurrentRow.DataBoundItem as Bill;
            if (selectedBill == null) return;

            var confirm = MessageBox.Show($"정말 '{selectedBill.Name}'을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                BillManager.Bills.Remove(selectedBill);
                BillManager.Save();

                RefreshGrid();
                MessageBox.Show("삭제되었습니다.");
            }
        }

        // 지불한 요소들의 합계 반환
        private int Total()
        {
            return BillManager.Bills
                .Where(b => b.IsPaid == "지불됨")
                .Sum(b => b.Cost);
        }
    }
}