namespace WinFormsClients
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ChooseTable = new ComboBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            checkTextBox = new TextBox();
            checkCondition = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ChooseTable
            // 
            ChooseTable.FormattingEnabled = true;
            ChooseTable.Location = new Point(14, 59);
            ChooseTable.Name = "ChooseTable";
            ChooseTable.Size = new Size(193, 23);
            ChooseTable.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(44, 168);
            button1.Name = "button1";
            button1.Size = new Size(123, 23);
            button1.TabIndex = 1;
            button1.Text = "Загрузить таблицу";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(224, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(468, 389);
            dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(13, 41);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 3;
            label1.Text = "Выберите таблицу:";
            // 
            // checkTextBox
            // 
            checkTextBox.Enabled = false;
            checkTextBox.Location = new Point(13, 139);
            checkTextBox.Name = "checkTextBox";
            checkTextBox.Size = new Size(194, 23);
            checkTextBox.TabIndex = 4;
            // 
            // checkCondition
            // 
            checkCondition.AutoSize = true;
            checkCondition.Enabled = false;
            checkCondition.ImageAlign = ContentAlignment.MiddleLeft;
            checkCondition.Location = new Point(12, 121);
            checkCondition.Name = "checkCondition";
            checkCondition.Size = new Size(101, 15);
            checkCondition.TabIndex = 5;
            checkCondition.Text = "Введите условие:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(14, 99);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(193, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Вывести таблицу с условиями";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 441);
            Controls.Add(checkBox1);
            Controls.Add(checkCondition);
            Controls.Add(checkTextBox);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(ChooseTable);
            MaximumSize = new Size(720, 480);
            MinimumSize = new Size(720, 480);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ChooseTable;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox checkTextBox;
        private Label checkCondition;
        private ContextMenuStrip contextMenuStrip1;
        private CheckBox checkBox1;
    }
}