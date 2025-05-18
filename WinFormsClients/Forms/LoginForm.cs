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

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = Login.Text.Trim();
            string password = Password.Text.Trim();

            if (username == "" || password == "")
            {
                AnswerLabel.Text = "Введите логин и пароль.";
                AnswerLabel.ForeColor = Color.Red;
                return;
            }
                string response = SendLoginRequest(username, password);

            if (response.StartsWith("OK"))
            {
                AnswerLabel.Text = "Успешный вход.";
                AnswerLabel.ForeColor = Color.Green;

                await Task.Delay(1000);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (response.StartsWith("FAIL"))
            {
                AnswerLabel.Text = "Неверный логин или пароль.";
                AnswerLabel.ForeColor = Color.Red;
            }
            else if (response == "ERROR")
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

                var buffer = new byte[4096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                    return "ERROR";

                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return response.Trim();
            }
            catch
            {
                return "ERROR";
            }
        }
    }
}