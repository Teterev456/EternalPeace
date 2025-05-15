using System.Net.Sockets;
using System.Text;

namespace WinFormsClients
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Login.Text.Trim();
            string password = Password.Text.Trim();

            if (username == "" || password == "")
            {
                AnswerLabel.Text = "Введите логин и пароль.";
                return;
            }

            string response = SendLoginRequest(username, password);

            if (response == "OK")
            {
                AnswerLabel.Text = "Успешный вход.";
                AnswerLabel.ForeColor = Color.Green;
                Hide();
                var mainForm = new MainForm();
                mainForm.Show();
            }
            else if (response == "FAIL")
            {
                AnswerLabel.Text = "Неверный логин или пароль.";
                AnswerLabel.ForeColor = Color.Red;
            }
            else
            {
                AnswerLabel.Text = "Ошибка подключения.";
                AnswerLabel.ForeColor = Color.DarkOrange;
            }
        }

        private string SendLoginRequest(string username, string password)
        {
            try
            {
                using var client = new TcpClient("127.0.0.1", 5000);
                using var stream = client.GetStream();

                string message = $"LOGIN {username} {password}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
            catch
            {
                return "ERROR";
            }
        }
    }
}

