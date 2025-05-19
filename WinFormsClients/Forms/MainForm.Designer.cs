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
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            поискТаблицыToolStripMenuItem = new ToolStripMenuItem();
            добавлениеТаблицыToolStripMenuItem = new ToolStripMenuItem();
            удалениеToolStripMenuItem = new ToolStripMenuItem();
            обновлениеToolStripMenuItem = new ToolStripMenuItem();
            sQLЗапросToolStripMenuItem = new ToolStripMenuItem();
            созданиеНовогоПользователяToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            panelAdd = new Panel();
            label46 = new Label();
            txtDoctorWorkExperience = new TextBox();
            txtDoctorSpeciallity = new TextBox();
            txtDoctorBirthday = new TextBox();
            txtDoctorSex = new TextBox();
            txtDoctorName = new TextBox();
            txtDoctorId = new TextBox();
            AddDoctorButton = new Button();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label15 = new Label();
            label16 = new Label();
            txtWardType = new TextBox();
            txtWardNumBeds = new TextBox();
            txtWardId = new TextBox();
            AddWardButton = new Button();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            txtMedHistoryDischargeDate = new TextBox();
            txtMedHistoryRecordDate = new TextBox();
            txtMedHistoryTreatmentCost = new TextBox();
            label30 = new Label();
            label29 = new Label();
            label28 = new Label();
            txtMedHistoryIdWard = new TextBox();
            txtMedHistoryIdDoctor = new TextBox();
            txtMedHistoryStatus = new TextBox();
            txtMedHistoryDeseases = new TextBox();
            txtMedHistoryIdPatient = new TextBox();
            txtMedHistoryId = new TextBox();
            AddMedHistoryButton = new Button();
            label14 = new Label();
            label18 = new Label();
            label19 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            txtPatientInsuranceExp = new TextBox();
            txtPatientInsuranceType = new TextBox();
            txtPatientBirthDate = new TextBox();
            txtPatientSex = new TextBox();
            txtPatientAddress = new TextBox();
            txtPatientName = new TextBox();
            txtPatientId = new TextBox();
            AddPatientButton = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label9 = new Label();
            label17 = new Label();
            panelSearch = new Panel();
            OperationLabel = new Label();
            checkBox1 = new CheckBox();
            checkCondition = new Label();
            checkTextBox = new TextBox();
            labelTable = new Label();
            button1 = new Button();
            ChooseTable = new ComboBox();
            dataGridView1 = new DataGridView();
            panelSqlQuery = new Panel();
            label41 = new Label();
            label40 = new Label();
            ChooseTable_3 = new ComboBox();
            sqlButton = new Button();
            txtSqlOutput = new RichTextBox();
            txtSqlInput = new TextBox();
            label39 = new Label();
            label38 = new Label();
            label37 = new Label();
            panelDelete = new Panel();
            deleteButton = new Button();
            txtDeleteId = new TextBox();
            label33 = new Label();
            label32 = new Label();
            label31 = new Label();
            ChooseTable_2 = new ComboBox();
            panelCreateUser = new Panel();
            buttonCreateUser = new Button();
            txtPasswordEnter = new TextBox();
            label36 = new Label();
            txtUserEnter = new TextBox();
            label35 = new Label();
            label34 = new Label();
            panelUpdate = new Panel();
            label45 = new Label();
            txtEnterIdForTable = new TextBox();
            ChooseTable_4 = new ComboBox();
            label44 = new Label();
            label42 = new Label();
            label43 = new Label();
            buttonUpdate = new Button();
            txtConditionForTable = new TextBox();
            menuStrip1.SuspendLayout();
            panelAdd.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelSqlQuery.SuspendLayout();
            panelDelete.SuspendLayout();
            panelCreateUser.SuspendLayout();
            panelUpdate.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { поискТаблицыToolStripMenuItem, добавлениеТаблицыToolStripMenuItem, удалениеToolStripMenuItem, обновлениеToolStripMenuItem, sQLЗапросToolStripMenuItem, созданиеНовогоПользователяToolStripMenuItem, выходToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // поискТаблицыToolStripMenuItem
            // 
            поискТаблицыToolStripMenuItem.Name = "поискТаблицыToolStripMenuItem";
            поискТаблицыToolStripMenuItem.Size = new Size(54, 20);
            поискТаблицыToolStripMenuItem.Text = "Поиск";
            поискТаблицыToolStripMenuItem.Click += поискТаблицыToolStripMenuItem_Click;
            // 
            // добавлениеТаблицыToolStripMenuItem
            // 
            добавлениеТаблицыToolStripMenuItem.Name = "добавлениеТаблицыToolStripMenuItem";
            добавлениеТаблицыToolStripMenuItem.Size = new Size(86, 20);
            добавлениеТаблицыToolStripMenuItem.Text = "Добавление";
            добавлениеТаблицыToolStripMenuItem.Click += добавлениеТаблицыToolStripMenuItem_Click;
            // 
            // удалениеToolStripMenuItem
            // 
            удалениеToolStripMenuItem.Name = "удалениеToolStripMenuItem";
            удалениеToolStripMenuItem.Size = new Size(71, 20);
            удалениеToolStripMenuItem.Text = "Удаление";
            удалениеToolStripMenuItem.Click += удалениеToolStripMenuItem_Click;
            // 
            // обновлениеToolStripMenuItem
            // 
            обновлениеToolStripMenuItem.Name = "обновлениеToolStripMenuItem";
            обновлениеToolStripMenuItem.Size = new Size(81, 20);
            обновлениеToolStripMenuItem.Text = "Изменение";
            обновлениеToolStripMenuItem.Click += обновлениеToolStripMenuItem_Click;
            // 
            // sQLЗапросToolStripMenuItem
            // 
            sQLЗапросToolStripMenuItem.Name = "sQLЗапросToolStripMenuItem";
            sQLЗапросToolStripMenuItem.Size = new Size(81, 20);
            sQLЗапросToolStripMenuItem.Text = "SQL запрос";
            sQLЗапросToolStripMenuItem.Click += sQLЗапросToolStripMenuItem_Click;
            // 
            // созданиеНовогоПользователяToolStripMenuItem
            // 
            созданиеНовогоПользователяToolStripMenuItem.Name = "созданиеНовогоПользователяToolStripMenuItem";
            созданиеНовогоПользователяToolStripMenuItem.Size = new Size(191, 20);
            созданиеНовогоПользователяToolStripMenuItem.Text = "Создание нового пользователя";
            созданиеНовогоПользователяToolStripMenuItem.Click += созданиеНовогоПользователяToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            выходToolStripMenuItem.Margin = new Padding(0, 0, 5, 0);
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(54, 20);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // panelAdd
            // 
            panelAdd.BackColor = SystemColors.Control;
            panelAdd.Controls.Add(label46);
            panelAdd.Controls.Add(txtDoctorWorkExperience);
            panelAdd.Controls.Add(txtDoctorSpeciallity);
            panelAdd.Controls.Add(txtDoctorBirthday);
            panelAdd.Controls.Add(txtDoctorSex);
            panelAdd.Controls.Add(txtDoctorName);
            panelAdd.Controls.Add(txtDoctorId);
            panelAdd.Controls.Add(AddDoctorButton);
            panelAdd.Controls.Add(label10);
            panelAdd.Controls.Add(label11);
            panelAdd.Controls.Add(label12);
            panelAdd.Controls.Add(label13);
            panelAdd.Controls.Add(label15);
            panelAdd.Controls.Add(label16);
            panelAdd.Controls.Add(txtWardType);
            panelAdd.Controls.Add(txtWardNumBeds);
            panelAdd.Controls.Add(txtWardId);
            panelAdd.Controls.Add(AddWardButton);
            panelAdd.Controls.Add(label20);
            panelAdd.Controls.Add(label21);
            panelAdd.Controls.Add(label22);
            panelAdd.Controls.Add(label23);
            panelAdd.Controls.Add(txtMedHistoryDischargeDate);
            panelAdd.Controls.Add(txtMedHistoryRecordDate);
            panelAdd.Controls.Add(txtMedHistoryTreatmentCost);
            panelAdd.Controls.Add(label30);
            panelAdd.Controls.Add(label29);
            panelAdd.Controls.Add(label28);
            panelAdd.Controls.Add(txtMedHistoryIdWard);
            panelAdd.Controls.Add(txtMedHistoryIdDoctor);
            panelAdd.Controls.Add(txtMedHistoryStatus);
            panelAdd.Controls.Add(txtMedHistoryDeseases);
            panelAdd.Controls.Add(txtMedHistoryIdPatient);
            panelAdd.Controls.Add(txtMedHistoryId);
            panelAdd.Controls.Add(AddMedHistoryButton);
            panelAdd.Controls.Add(label14);
            panelAdd.Controls.Add(label18);
            panelAdd.Controls.Add(label19);
            panelAdd.Controls.Add(label24);
            panelAdd.Controls.Add(label25);
            panelAdd.Controls.Add(label26);
            panelAdd.Controls.Add(label27);
            panelAdd.Controls.Add(txtPatientInsuranceExp);
            panelAdd.Controls.Add(txtPatientInsuranceType);
            panelAdd.Controls.Add(txtPatientBirthDate);
            panelAdd.Controls.Add(txtPatientSex);
            panelAdd.Controls.Add(txtPatientAddress);
            panelAdd.Controls.Add(txtPatientName);
            panelAdd.Controls.Add(txtPatientId);
            panelAdd.Controls.Add(AddPatientButton);
            panelAdd.Controls.Add(label8);
            panelAdd.Controls.Add(label7);
            panelAdd.Controls.Add(label6);
            panelAdd.Controls.Add(label5);
            panelAdd.Controls.Add(label4);
            panelAdd.Controls.Add(label3);
            panelAdd.Controls.Add(label2);
            panelAdd.Controls.Add(label1);
            panelAdd.Controls.Add(label9);
            panelAdd.Controls.Add(label17);
            panelAdd.Dock = DockStyle.Fill;
            panelAdd.Location = new Point(0, 0);
            panelAdd.Name = "panelAdd";
            panelAdd.Size = new Size(884, 561);
            panelAdd.TabIndex = 18;
            panelAdd.Visible = false;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(18, 39);
            label46.Name = "label46";
            label46.Size = new Size(170, 15);
            label46.TabIndex = 148;
            label46.Text = "Добавление нового пациента";
            label46.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDoctorWorkExperience
            // 
            txtDoctorWorkExperience.Location = new Point(219, 526);
            txtDoctorWorkExperience.Name = "txtDoctorWorkExperience";
            txtDoctorWorkExperience.Size = new Size(100, 23);
            txtDoctorWorkExperience.TabIndex = 147;
            // 
            // txtDoctorSpeciallity
            // 
            txtDoctorSpeciallity.Location = new Point(219, 497);
            txtDoctorSpeciallity.Name = "txtDoctorSpeciallity";
            txtDoctorSpeciallity.Size = new Size(100, 23);
            txtDoctorSpeciallity.TabIndex = 146;
            // 
            // txtDoctorBirthday
            // 
            txtDoctorBirthday.Location = new Point(219, 468);
            txtDoctorBirthday.Name = "txtDoctorBirthday";
            txtDoctorBirthday.Size = new Size(100, 23);
            txtDoctorBirthday.TabIndex = 145;
            // 
            // txtDoctorSex
            // 
            txtDoctorSex.Location = new Point(219, 439);
            txtDoctorSex.Name = "txtDoctorSex";
            txtDoctorSex.Size = new Size(100, 23);
            txtDoctorSex.TabIndex = 144;
            // 
            // txtDoctorName
            // 
            txtDoctorName.Location = new Point(219, 410);
            txtDoctorName.Name = "txtDoctorName";
            txtDoctorName.Size = new Size(100, 23);
            txtDoctorName.TabIndex = 143;
            // 
            // txtDoctorId
            // 
            txtDoctorId.Location = new Point(219, 381);
            txtDoctorId.Name = "txtDoctorId";
            txtDoctorId.Size = new Size(100, 23);
            txtDoctorId.TabIndex = 142;
            // 
            // AddDoctorButton
            // 
            AddDoctorButton.Location = new Point(245, 350);
            AddDoctorButton.Name = "AddDoctorButton";
            AddDoctorButton.Size = new Size(74, 23);
            AddDoctorButton.TabIndex = 141;
            AddDoctorButton.Text = "Добавить";
            AddDoctorButton.UseVisualStyleBackColor = true;
            AddDoctorButton.Click += AddDoctorButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ImageAlign = ContentAlignment.MiddleLeft;
            label10.Location = new Point(20, 531);
            label10.Name = "label10";
            label10.Size = new Size(79, 15);
            label10.TabIndex = 140;
            label10.Text = "Стаж работы";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ImageAlign = ContentAlignment.MiddleLeft;
            label11.Location = new Point(19, 502);
            label11.Name = "label11";
            label11.Size = new Size(92, 15);
            label11.TabIndex = 139;
            label11.Text = "Специальность";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ImageAlign = ContentAlignment.MiddleLeft;
            label12.Location = new Point(20, 473);
            label12.Name = "label12";
            label12.Size = new Size(90, 15);
            label12.TabIndex = 138;
            label12.Text = "Дата рождения";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ImageAlign = ContentAlignment.MiddleLeft;
            label13.Location = new Point(20, 444);
            label13.Name = "label13";
            label13.Size = new Size(30, 15);
            label13.TabIndex = 137;
            label13.Text = "Пол";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ImageAlign = ContentAlignment.MiddleLeft;
            label15.Location = new Point(20, 413);
            label15.Name = "label15";
            label15.Size = new Size(31, 15);
            label15.TabIndex = 136;
            label15.Text = "Имя";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ImageAlign = ContentAlignment.MiddleLeft;
            label16.Location = new Point(20, 384);
            label16.Name = "label16";
            label16.Size = new Size(18, 15);
            label16.TabIndex = 135;
            label16.Text = "ID";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtWardType
            // 
            txtWardType.Location = new Point(725, 129);
            txtWardType.Name = "txtWardType";
            txtWardType.Size = new Size(100, 23);
            txtWardType.TabIndex = 133;
            // 
            // txtWardNumBeds
            // 
            txtWardNumBeds.Location = new Point(725, 100);
            txtWardNumBeds.Name = "txtWardNumBeds";
            txtWardNumBeds.Size = new Size(100, 23);
            txtWardNumBeds.TabIndex = 132;
            // 
            // txtWardId
            // 
            txtWardId.Location = new Point(725, 71);
            txtWardId.Name = "txtWardId";
            txtWardId.Size = new Size(100, 23);
            txtWardId.TabIndex = 131;
            // 
            // AddWardButton
            // 
            AddWardButton.Location = new Point(751, 36);
            AddWardButton.Name = "AddWardButton";
            AddWardButton.Size = new Size(74, 23);
            AddWardButton.TabIndex = 130;
            AddWardButton.Text = "Добавить";
            AddWardButton.UseVisualStyleBackColor = true;
            AddWardButton.Click += AddWardButton_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ImageAlign = ContentAlignment.MiddleLeft;
            label20.Location = new Point(526, 134);
            label20.Name = "label20";
            label20.Size = new Size(70, 15);
            label20.TabIndex = 129;
            label20.Text = "Тип палаты";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.ImageAlign = ContentAlignment.MiddleLeft;
            label21.Location = new Point(526, 103);
            label21.Name = "label21";
            label21.Size = new Size(100, 15);
            label21.TabIndex = 128;
            label21.Text = "Количество коек";
            label21.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ImageAlign = ContentAlignment.MiddleLeft;
            label22.Location = new Point(526, 74);
            label22.Name = "label22";
            label22.Size = new Size(18, 15);
            label22.TabIndex = 127;
            label22.Text = "ID";
            label22.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(527, 40);
            label23.Name = "label23";
            label23.Size = new Size(154, 15);
            label23.TabIndex = 126;
            label23.Text = "Добавление новой палаты";
            label23.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMedHistoryDischargeDate
            // 
            txtMedHistoryDischargeDate.Location = new Point(725, 526);
            txtMedHistoryDischargeDate.Name = "txtMedHistoryDischargeDate";
            txtMedHistoryDischargeDate.Size = new Size(100, 23);
            txtMedHistoryDischargeDate.TabIndex = 111;
            // 
            // txtMedHistoryRecordDate
            // 
            txtMedHistoryRecordDate.Location = new Point(725, 497);
            txtMedHistoryRecordDate.Name = "txtMedHistoryRecordDate";
            txtMedHistoryRecordDate.Size = new Size(100, 23);
            txtMedHistoryRecordDate.TabIndex = 110;
            // 
            // txtMedHistoryTreatmentCost
            // 
            txtMedHistoryTreatmentCost.Location = new Point(725, 468);
            txtMedHistoryTreatmentCost.Name = "txtMedHistoryTreatmentCost";
            txtMedHistoryTreatmentCost.Size = new Size(100, 23);
            txtMedHistoryTreatmentCost.TabIndex = 109;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.ImageAlign = ContentAlignment.MiddleLeft;
            label30.Location = new Point(526, 500);
            label30.Name = "label30";
            label30.Size = new Size(73, 15);
            label30.TabIndex = 108;
            label30.Text = "Дата записи";
            label30.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.ImageAlign = ContentAlignment.MiddleLeft;
            label29.Location = new Point(526, 529);
            label29.Name = "label29";
            label29.Size = new Size(83, 15);
            label29.TabIndex = 107;
            label29.Text = "Дата выписки";
            label29.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.ImageAlign = ContentAlignment.MiddleLeft;
            label28.Location = new Point(526, 471);
            label28.Name = "label28";
            label28.Size = new Size(116, 15);
            label28.TabIndex = 106;
            label28.Text = "Стоимость лечения";
            label28.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMedHistoryIdWard
            // 
            txtMedHistoryIdWard.Location = new Point(725, 439);
            txtMedHistoryIdWard.Name = "txtMedHistoryIdWard";
            txtMedHistoryIdWard.Size = new Size(100, 23);
            txtMedHistoryIdWard.TabIndex = 105;
            // 
            // txtMedHistoryIdDoctor
            // 
            txtMedHistoryIdDoctor.Location = new Point(725, 410);
            txtMedHistoryIdDoctor.Name = "txtMedHistoryIdDoctor";
            txtMedHistoryIdDoctor.Size = new Size(100, 23);
            txtMedHistoryIdDoctor.TabIndex = 104;
            // 
            // txtMedHistoryStatus
            // 
            txtMedHistoryStatus.Location = new Point(725, 381);
            txtMedHistoryStatus.Name = "txtMedHistoryStatus";
            txtMedHistoryStatus.Size = new Size(100, 23);
            txtMedHistoryStatus.TabIndex = 103;
            // 
            // txtMedHistoryDeseases
            // 
            txtMedHistoryDeseases.Location = new Point(725, 352);
            txtMedHistoryDeseases.Name = "txtMedHistoryDeseases";
            txtMedHistoryDeseases.Size = new Size(100, 23);
            txtMedHistoryDeseases.TabIndex = 102;
            // 
            // txtMedHistoryIdPatient
            // 
            txtMedHistoryIdPatient.Location = new Point(725, 323);
            txtMedHistoryIdPatient.Name = "txtMedHistoryIdPatient";
            txtMedHistoryIdPatient.Size = new Size(100, 23);
            txtMedHistoryIdPatient.TabIndex = 101;
            // 
            // txtMedHistoryId
            // 
            txtMedHistoryId.Location = new Point(725, 294);
            txtMedHistoryId.Name = "txtMedHistoryId";
            txtMedHistoryId.Size = new Size(100, 23);
            txtMedHistoryId.TabIndex = 100;
            // 
            // AddMedHistoryButton
            // 
            AddMedHistoryButton.Location = new Point(751, 265);
            AddMedHistoryButton.Name = "AddMedHistoryButton";
            AddMedHistoryButton.Size = new Size(74, 23);
            AddMedHistoryButton.TabIndex = 99;
            AddMedHistoryButton.Text = "Добавить";
            AddMedHistoryButton.UseVisualStyleBackColor = true;
            AddMedHistoryButton.Click += AddMedHistoryButton_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ImageAlign = ContentAlignment.MiddleLeft;
            label14.Location = new Point(526, 442);
            label14.Name = "label14";
            label14.Size = new Size(60, 15);
            label14.TabIndex = 98;
            label14.Text = "Id палаты";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ImageAlign = ContentAlignment.MiddleLeft;
            label18.Location = new Point(525, 415);
            label18.Name = "label18";
            label18.Size = new Size(110, 15);
            label18.TabIndex = 97;
            label18.Text = "Id лечащего врача";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ImageAlign = ContentAlignment.MiddleLeft;
            label19.Location = new Point(526, 386);
            label19.Name = "label19";
            label19.Size = new Size(43, 15);
            label19.TabIndex = 96;
            label19.Text = "Статус";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.ImageAlign = ContentAlignment.MiddleLeft;
            label24.Location = new Point(526, 357);
            label24.Name = "label24";
            label24.Size = new Size(52, 15);
            label24.TabIndex = 95;
            label24.Text = "Болезнь";
            label24.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.ImageAlign = ContentAlignment.MiddleLeft;
            label25.Location = new Point(526, 326);
            label25.Name = "label25";
            label25.Size = new Size(71, 15);
            label25.TabIndex = 94;
            label25.Text = "Id пациента";
            label25.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.ImageAlign = ContentAlignment.MiddleLeft;
            label26.Location = new Point(526, 297);
            label26.Name = "label26";
            label26.Size = new Size(18, 15);
            label26.TabIndex = 93;
            label26.Text = "ID";
            label26.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(525, 269);
            label27.Name = "label27";
            label27.Size = new Size(187, 15);
            label27.TabIndex = 92;
            label27.Text = "Добавление новой мед. истории";
            label27.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPatientInsuranceExp
            // 
            txtPatientInsuranceExp.Location = new Point(218, 240);
            txtPatientInsuranceExp.Name = "txtPatientInsuranceExp";
            txtPatientInsuranceExp.Size = new Size(100, 23);
            txtPatientInsuranceExp.TabIndex = 64;
            // 
            // txtPatientInsuranceType
            // 
            txtPatientInsuranceType.Location = new Point(218, 211);
            txtPatientInsuranceType.Name = "txtPatientInsuranceType";
            txtPatientInsuranceType.Size = new Size(100, 23);
            txtPatientInsuranceType.TabIndex = 63;
            // 
            // txtPatientBirthDate
            // 
            txtPatientBirthDate.Location = new Point(218, 182);
            txtPatientBirthDate.Name = "txtPatientBirthDate";
            txtPatientBirthDate.Size = new Size(100, 23);
            txtPatientBirthDate.TabIndex = 62;
            // 
            // txtPatientSex
            // 
            txtPatientSex.Location = new Point(218, 153);
            txtPatientSex.Name = "txtPatientSex";
            txtPatientSex.Size = new Size(100, 23);
            txtPatientSex.TabIndex = 61;
            // 
            // txtPatientAddress
            // 
            txtPatientAddress.Location = new Point(218, 124);
            txtPatientAddress.Name = "txtPatientAddress";
            txtPatientAddress.Size = new Size(100, 23);
            txtPatientAddress.TabIndex = 60;
            // 
            // txtPatientName
            // 
            txtPatientName.Location = new Point(218, 95);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(100, 23);
            txtPatientName.TabIndex = 59;
            // 
            // txtPatientId
            // 
            txtPatientId.Location = new Point(218, 66);
            txtPatientId.Name = "txtPatientId";
            txtPatientId.Size = new Size(100, 23);
            txtPatientId.TabIndex = 58;
            // 
            // AddPatientButton
            // 
            AddPatientButton.Location = new Point(244, 35);
            AddPatientButton.Name = "AddPatientButton";
            AddPatientButton.Size = new Size(74, 23);
            AddPatientButton.TabIndex = 57;
            AddPatientButton.Text = "Добавить";
            AddPatientButton.UseVisualStyleBackColor = true;
            AddPatientButton.Click += AddButton_Click_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ImageAlign = ContentAlignment.MiddleLeft;
            label8.Location = new Point(19, 243);
            label8.Name = "label8";
            label8.Size = new Size(154, 15);
            label8.TabIndex = 56;
            label8.Text = "Дата окончания страховки";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(18, 214);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 55;
            label7.Text = "Тип страхования";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ImageAlign = ContentAlignment.MiddleLeft;
            label6.Location = new Point(19, 185);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 54;
            label6.Text = "Дата рождения";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImageAlign = ContentAlignment.MiddleLeft;
            label5.Location = new Point(19, 156);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 53;
            label5.Text = "Пол";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImageAlign = ContentAlignment.MiddleLeft;
            label4.Location = new Point(18, 127);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 52;
            label4.Text = "Адрес";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(19, 98);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 51;
            label3.Text = "Имя";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(19, 69);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 50;
            label2.Text = "ID";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 10);
            label1.Name = "label1";
            label1.Size = new Size(170, 15);
            label1.TabIndex = 49;
            label1.Text = "Добавление нового пациента";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ImageAlign = ContentAlignment.MiddleLeft;
            label9.Location = new Point(20, 257);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 8;
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(20, 352);
            label17.Name = "label17";
            label17.Size = new Size(151, 15);
            label17.TabIndex = 134;
            label17.Text = "Добавление нового врача";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(OperationLabel);
            panelSearch.Controls.Add(checkBox1);
            panelSearch.Controls.Add(checkCondition);
            panelSearch.Controls.Add(checkTextBox);
            panelSearch.Controls.Add(labelTable);
            panelSearch.Controls.Add(button1);
            panelSearch.Controls.Add(ChooseTable);
            panelSearch.Controls.Add(dataGridView1);
            panelSearch.Dock = DockStyle.Fill;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(884, 561);
            panelSearch.TabIndex = 19;
            // 
            // OperationLabel
            // 
            OperationLabel.AutoSize = true;
            OperationLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            OperationLabel.Location = new Point(55, 40);
            OperationLabel.Name = "OperationLabel";
            OperationLabel.Size = new Size(127, 21);
            OperationLabel.TabIndex = 24;
            OperationLabel.Text = "Поиск таблицы";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(25, 130);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(193, 19);
            checkBox1.TabIndex = 23;
            checkBox1.Text = "Вывести таблицу с условиями";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // checkCondition
            // 
            checkCondition.AutoSize = true;
            checkCondition.Enabled = false;
            checkCondition.ImageAlign = ContentAlignment.MiddleLeft;
            checkCondition.Location = new Point(23, 152);
            checkCondition.Name = "checkCondition";
            checkCondition.Size = new Size(101, 15);
            checkCondition.TabIndex = 22;
            checkCondition.Text = "Введите условие:";
            // 
            // checkTextBox
            // 
            checkTextBox.Enabled = false;
            checkTextBox.Location = new Point(24, 170);
            checkTextBox.Name = "checkTextBox";
            checkTextBox.Size = new Size(194, 23);
            checkTextBox.TabIndex = 21;
            // 
            // labelTable
            // 
            labelTable.AutoSize = true;
            labelTable.ImageAlign = ContentAlignment.MiddleLeft;
            labelTable.Location = new Point(24, 72);
            labelTable.Name = "labelTable";
            labelTable.Size = new Size(112, 15);
            labelTable.TabIndex = 20;
            labelTable.Text = "Выберите таблицу:";
            // 
            // button1
            // 
            button1.Location = new Point(55, 199);
            button1.Name = "button1";
            button1.Size = new Size(127, 23);
            button1.TabIndex = 19;
            button1.Text = "Загрузить таблицу";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // ChooseTable
            // 
            ChooseTable.FormattingEnabled = true;
            ChooseTable.Location = new Point(25, 90);
            ChooseTable.Name = "ChooseTable";
            ChooseTable.Size = new Size(193, 23);
            ChooseTable.TabIndex = 18;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(224, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(648, 509);
            dataGridView1.TabIndex = 25;
            // 
            // panelSqlQuery
            // 
            panelSqlQuery.Controls.Add(label41);
            panelSqlQuery.Controls.Add(label40);
            panelSqlQuery.Controls.Add(ChooseTable_3);
            panelSqlQuery.Controls.Add(sqlButton);
            panelSqlQuery.Controls.Add(txtSqlOutput);
            panelSqlQuery.Controls.Add(txtSqlInput);
            panelSqlQuery.Controls.Add(label39);
            panelSqlQuery.Controls.Add(label38);
            panelSqlQuery.Controls.Add(label37);
            panelSqlQuery.Dock = DockStyle.Fill;
            panelSqlQuery.Location = new Point(0, 0);
            panelSqlQuery.Name = "panelSqlQuery";
            panelSqlQuery.Size = new Size(884, 561);
            panelSqlQuery.TabIndex = 26;
            panelSqlQuery.Visible = false;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label41.Location = new Point(21, 190);
            label41.Name = "label41";
            label41.Size = new Size(226, 12);
            label41.TabIndex = 21;
            label41.Text = "SELECT * FROM \"Doctors\" WHERE \"Sex\" LIKE 'Женщина'";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label40.Location = new Point(23, 174);
            label40.Name = "label40";
            label40.Size = new Size(115, 12);
            label40.TabIndex = 20;
            label40.Text = "Формат ввода Sql запроса:";
            // 
            // ChooseTable_3
            // 
            ChooseTable_3.FormattingEnabled = true;
            ChooseTable_3.Location = new Point(242, 79);
            ChooseTable_3.Name = "ChooseTable_3";
            ChooseTable_3.Size = new Size(100, 23);
            ChooseTable_3.TabIndex = 19;
            // 
            // sqlButton
            // 
            sqlButton.Location = new Point(267, 214);
            sqlButton.Name = "sqlButton";
            sqlButton.Size = new Size(75, 23);
            sqlButton.TabIndex = 6;
            sqlButton.Text = "Отправить";
            sqlButton.UseVisualStyleBackColor = true;
            sqlButton.Click += sqlButton_Click;
            // 
            // txtSqlOutput
            // 
            txtSqlOutput.Location = new Point(368, 47);
            txtSqlOutput.Name = "txtSqlOutput";
            txtSqlOutput.Size = new Size(504, 502);
            txtSqlOutput.TabIndex = 5;
            txtSqlOutput.Text = "";
            // 
            // txtSqlInput
            // 
            txtSqlInput.Location = new Point(24, 141);
            txtSqlInput.Name = "txtSqlInput";
            txtSqlInput.Size = new Size(318, 23);
            txtSqlInput.TabIndex = 4;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(21, 113);
            label39.Name = "label39";
            label39.Size = new Size(64, 15);
            label39.TabIndex = 2;
            label39.Text = "Sql запрос";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(21, 85);
            label38.Name = "label38";
            label38.Size = new Size(110, 15);
            label38.TabIndex = 1;
            label38.Text = "Название таблицы";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label37.Location = new Point(129, 40);
            label37.Name = "label37";
            label37.Size = new Size(89, 21);
            label37.TabIndex = 0;
            label37.Text = "Sql запрос";
            // 
            // panelDelete
            // 
            panelDelete.Controls.Add(deleteButton);
            panelDelete.Controls.Add(txtDeleteId);
            panelDelete.Controls.Add(label33);
            panelDelete.Controls.Add(label32);
            panelDelete.Controls.Add(label31);
            panelDelete.Controls.Add(ChooseTable_2);
            panelDelete.Dock = DockStyle.Fill;
            panelDelete.Location = new Point(0, 0);
            panelDelete.Name = "panelDelete";
            panelDelete.Size = new Size(884, 561);
            panelDelete.TabIndex = 20;
            panelDelete.Visible = false;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(172, 162);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 26;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += button2_Click;
            // 
            // txtDeleteId
            // 
            txtDeleteId.Location = new Point(147, 120);
            txtDeleteId.Name = "txtDeleteId";
            txtDeleteId.Size = new Size(100, 23);
            txtDeleteId.TabIndex = 25;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.ImageAlign = ContentAlignment.MiddleLeft;
            label33.Location = new Point(54, 123);
            label33.Name = "label33";
            label33.Size = new Size(67, 15);
            label33.TabIndex = 24;
            label33.Text = "Введите ID:";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label32.ImageAlign = ContentAlignment.MiddleLeft;
            label32.Location = new Point(53, 35);
            label32.Name = "label32";
            label32.Size = new Size(123, 21);
            label32.TabIndex = 23;
            label32.Text = "Удаление по ID";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.ImageAlign = ContentAlignment.MiddleLeft;
            label31.Location = new Point(53, 68);
            label31.Name = "label31";
            label31.Size = new Size(112, 15);
            label31.TabIndex = 22;
            label31.Text = "Выберите таблицу:";
            // 
            // ChooseTable_2
            // 
            ChooseTable_2.FormattingEnabled = true;
            ChooseTable_2.Location = new Point(54, 86);
            ChooseTable_2.Name = "ChooseTable_2";
            ChooseTable_2.Size = new Size(193, 23);
            ChooseTable_2.TabIndex = 21;
            // 
            // panelCreateUser
            // 
            panelCreateUser.Controls.Add(buttonCreateUser);
            panelCreateUser.Controls.Add(txtPasswordEnter);
            panelCreateUser.Controls.Add(label36);
            panelCreateUser.Controls.Add(txtUserEnter);
            panelCreateUser.Controls.Add(label35);
            panelCreateUser.Controls.Add(label34);
            panelCreateUser.Dock = DockStyle.Fill;
            panelCreateUser.Location = new Point(0, 0);
            panelCreateUser.Name = "panelCreateUser";
            panelCreateUser.Size = new Size(884, 561);
            panelCreateUser.TabIndex = 22;
            panelCreateUser.Visible = false;
            // 
            // buttonCreateUser
            // 
            buttonCreateUser.Location = new Point(83, 148);
            buttonCreateUser.Name = "buttonCreateUser";
            buttonCreateUser.Size = new Size(147, 23);
            buttonCreateUser.TabIndex = 5;
            buttonCreateUser.Text = "Создать пользователя";
            buttonCreateUser.UseVisualStyleBackColor = true;
            buttonCreateUser.Click += buttonCreateUser_Click_1;
            // 
            // txtPasswordEnter
            // 
            txtPasswordEnter.Location = new Point(224, 108);
            txtPasswordEnter.Name = "txtPasswordEnter";
            txtPasswordEnter.Size = new Size(100, 23);
            txtPasswordEnter.TabIndex = 4;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(26, 111);
            label36.Name = "label36";
            label36.Size = new Size(93, 15);
            label36.TabIndex = 3;
            label36.Text = "Введите пароль";
            // 
            // txtUserEnter
            // 
            txtUserEnter.Location = new Point(224, 79);
            txtUserEnter.Name = "txtUserEnter";
            txtUserEnter.Size = new Size(100, 23);
            txtUserEnter.TabIndex = 2;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(26, 82);
            label35.Name = "label35";
            label35.Size = new Size(153, 15);
            label35.TabIndex = 1;
            label35.Text = "Введите имя пользователя";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label34.Location = new Point(49, 40);
            label34.Name = "label34";
            label34.Size = new Size(248, 21);
            label34.TabIndex = 0;
            label34.Text = "Создание нового пользователя";
            // 
            // panelUpdate
            // 
            panelUpdate.Controls.Add(label45);
            panelUpdate.Controls.Add(txtEnterIdForTable);
            panelUpdate.Controls.Add(ChooseTable_4);
            panelUpdate.Controls.Add(label44);
            panelUpdate.Controls.Add(label42);
            panelUpdate.Controls.Add(label43);
            panelUpdate.Controls.Add(buttonUpdate);
            panelUpdate.Controls.Add(txtConditionForTable);
            panelUpdate.Dock = DockStyle.Fill;
            panelUpdate.Location = new Point(0, 0);
            panelUpdate.Name = "panelUpdate";
            panelUpdate.Size = new Size(884, 561);
            panelUpdate.TabIndex = 27;
            panelUpdate.Visible = false;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(41, 100);
            label45.Name = "label45";
            label45.Size = new Size(64, 15);
            label45.TabIndex = 34;
            label45.Text = "Введите ID";
            // 
            // txtEnterIdForTable
            // 
            txtEnterIdForTable.Location = new Point(568, 95);
            txtEnterIdForTable.Name = "txtEnterIdForTable";
            txtEnterIdForTable.Size = new Size(100, 23);
            txtEnterIdForTable.TabIndex = 35;
            // 
            // ChooseTable_4
            // 
            ChooseTable_4.FormattingEnabled = true;
            ChooseTable_4.Location = new Point(568, 66);
            ChooseTable_4.Name = "ChooseTable_4";
            ChooseTable_4.Size = new Size(100, 23);
            ChooseTable_4.TabIndex = 33;
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(41, 71);
            label44.Name = "label44";
            label44.Size = new Size(110, 15);
            label44.TabIndex = 32;
            label44.Text = "Название таблицы";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label42.Location = new Point(255, 29);
            label42.Name = "label42";
            label42.Size = new Size(161, 21);
            label42.TabIndex = 28;
            label42.Text = "Изменение записей";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new Point(41, 131);
            label43.Name = "label43";
            label43.Size = new Size(375, 15);
            label43.TabIndex = 29;
            label43.Text = "Введите изменения (\"Name\" = Павел, \"Address\"= 11 улица Ленина)";
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(302, 162);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 30;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // txtConditionForTable
            // 
            txtConditionForTable.Location = new Point(462, 124);
            txtConditionForTable.Name = "txtConditionForTable";
            txtConditionForTable.Size = new Size(206, 23);
            txtConditionForTable.TabIndex = 31;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(menuStrip1);
            Controls.Add(panelSqlQuery);
            Controls.Add(panelSearch);
            Controls.Add(panelCreateUser);
            Controls.Add(panelDelete);
            Controls.Add(panelAdd);
            Controls.Add(panelUpdate);
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(900, 600);
            MinimumSize = new Size(900, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelAdd.ResumeLayout(false);
            panelAdd.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelSqlQuery.ResumeLayout(false);
            panelSqlQuery.PerformLayout();
            panelDelete.ResumeLayout(false);
            panelDelete.PerformLayout();
            panelCreateUser.ResumeLayout(false);
            panelCreateUser.PerformLayout();
            panelUpdate.ResumeLayout(false);
            panelUpdate.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem поискТаблицыToolStripMenuItem;
        private ToolStripMenuItem добавлениеТаблицыToolStripMenuItem;
        private ToolStripMenuItem удалениеToolStripMenuItem;
        private ToolStripMenuItem обновлениеToolStripMenuItem;
        private ToolStripMenuItem sQLЗапросToolStripMenuItem;
        private ToolStripMenuItem созданиеНовогоПользователяToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private Panel panelSearch;
        private Panel panelAdd;
        private Label label9;
        private DataGridView dataGridView1;
        private Label OperationLabel;
        private CheckBox checkBox1;
        private Label checkCondition;
        private TextBox checkTextBox;
        private Label labelTable;
        private Button button1;
        private ComboBox ChooseTable;
        private TextBox txtPatientInsuranceExp;
        private TextBox txtPatientInsuranceType;
        private TextBox txtPatientBirthDate;
        private TextBox txtPatientSex;
        private TextBox txtPatientAddress;
        private TextBox txtPatientName;
        private TextBox txtPatientId;
        private Button AddPatientButton;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtMedHistoryIdWard;
        private TextBox txtMedHistoryIdDoctor;
        private TextBox txtMedHistoryStatus;
        private TextBox txtMedHistoryDeseases;
        private TextBox txtMedHistoryIdPatient;
        private TextBox txtMedHistoryId;
        private Button AddMedHistoryButton;
        private Label label14;
        private Label label18;
        private Label label19;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label30;
        private Label label29;
        private Label label28;
        private TextBox txtMedHistoryDischargeDate;
        private TextBox txtMedHistoryRecordDate;
        private TextBox txtMedHistoryTreatmentCost;
        private TextBox txtDoctorWorkExperience;
        private TextBox txtDoctorSpeciallity;
        private TextBox txtDoctorBirthday;
        private TextBox txtDoctorSex;
        private TextBox txtDoctorName;
        private TextBox txtDoctorId;
        private Button AddDoctorButton;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox txtWardType;
        private TextBox txtWardNumBeds;
        private TextBox txtWardId;
        private Button AddWardButton;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Panel panelUpdate;
        private Label label33;
        private Label label32;
        private Label label31;
        private ComboBox ChooseTable_2;
        private Button deleteButton;
        private TextBox txtDeleteId;
        private Panel panelDelete;
        private Panel panelCreateUser;
        private Button buttonCreateUser;
        private TextBox txtPasswordEnter;
        private Label label36;
        private TextBox txtUserEnter;
        private Label label35;
        private Label label34;
        private Panel panelSqlQuery;
        private Button sqlButton;
        private RichTextBox txtSqlOutput;
        private TextBox txtSqlInput;
        private Label label39;
        private Label label38;
        private Label label37;
        private ComboBox ChooseTable_3;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Button buttonUpdate;
        private ComboBox ChooseTable_4;
        private Label label44;
        private TextBox txtConditionForTable;
        private Label label45;
        private TextBox txtEnterIdForTable;
        private Label label46;
    }
}