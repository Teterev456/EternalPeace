namespace WinFormsClients
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var login = new LoginForm())
                {
                    var result = login.ShowDialog();
                    if (result != DialogResult.OK)
                        break;
                }

                using (var mainForm = new MainForm())
                {
                    Application.Run(mainForm);
                    if (!mainForm.IsLogoutRequested)
                        break;
                }
            }
        }
    }
}