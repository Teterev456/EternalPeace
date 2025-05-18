namespace WinFormsClients
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            Login = new TextBox();
            Password = new TextBox();
            label3 = new Label();
            button1 = new Button();
            AnswerLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 54);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 98);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // Login
            // 
            Login.Location = new Point(61, 72);
            Login.Name = "Login";
            Login.Size = new Size(116, 23);
            Login.TabIndex = 2;
            // 
            // Password
            // 
            Password.Location = new Point(61, 116);
            Password.Name = "Password";
            Password.Size = new Size(116, 23);
            Password.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(86, 15);
            label3.Name = "label3";
            label3.Size = new Size(64, 30);
            label3.TabIndex = 4;
            label3.Text = "Вход";
            // 
            // button1
            // 
            button1.Location = new Point(86, 148);
            button1.Name = "button1";
            button1.Size = new Size(64, 23);
            button1.TabIndex = 5;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AnswerLabel
            // 
            AnswerLabel.Location = new Point(12, 185);
            AnswerLabel.Name = "AnswerLabel";
            AnswerLabel.Size = new Size(220, 15);
            AnswerLabel.TabIndex = 6;
            AnswerLabel.Text = "Введите логин и пароль";
            AnswerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(244, 221);
            Controls.Add(AnswerLabel);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(Password);
            Controls.Add(Login);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(260, 260);
            MinimumSize = new Size(260, 260);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox Login;
        private TextBox Password;
        private Label label3;
        private Button button1;
        private Label AnswerLabel;
    }
}