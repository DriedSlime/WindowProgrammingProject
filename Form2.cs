using System;
using System.Windows.Forms;

namespace WindowProgrammingProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (ValidateUser(username, password))
            {
                this.Hide(); // 현재 로그인 폼 숨기기
                Form1 mainForm = new Form1();
                mainForm.FormClosed += (s, args) => this.Close(); // 메인폼이 닫히면 전체 앱 종료
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 잘못되었습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUser(string username, string password)
        {
            // 간단한 예시: 하드코딩된 계정
            return username == "root" && password == "root";
        }
    }
}