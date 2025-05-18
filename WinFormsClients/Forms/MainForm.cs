using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsClients
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ChooseTable.Items.Add("Doctors");
            ChooseTable.Items.Add("Patients");
            ChooseTable.Items.Add("Wards");
            ChooseTable.Items.Add("MedHistories");
            ChooseTable.SelectedIndex = 0;
            ChooseTable_2.Items.Add("Doctors");
            ChooseTable_2.Items.Add("Patients");
            ChooseTable_2.Items.Add("Wards");
            ChooseTable_2.Items.Add("MedHistories");
            ChooseTable_2.SelectedIndex = 0;
            ChooseTable_3.Items.Add("Doctors");
            ChooseTable_3.Items.Add("Patients");
            ChooseTable_3.Items.Add("Wards");
            ChooseTable_3.Items.Add("MedHistories");
            ChooseTable_3.SelectedIndex = 0;
            ChooseTable_4.Items.Add("Doctors");
            ChooseTable_4.Items.Add("Patients");
            ChooseTable_4.Items.Add("Wards");
            ChooseTable_4.Items.Add("MedHistories");
            ChooseTable_4.SelectedIndex = 0;
        }


        private string SendCommand(string command)
        {
            try
            {
                using var client = new TcpClient("127.0.0.1", 5000);
                using var stream = client.GetStream();

                byte[] data = Encoding.UTF8.GetBytes(command);
                stream.Write(data, 0, data.Length);

                var buffer = new byte[8192];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) return "ERROR: no response";

                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return response.Trim();
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }

        private void ShowSearchPanel()
        {
            panelSearch.Visible = true;
            panelAdd.Visible = false;
            panelDelete.Visible = false;
            panelCreateUser.Visible = false;
            panelSqlQuery.Visible = false;
            panelUpdate.Visible = false;
        }

        private void ShowAddPanel()
        {
            panelSearch.Visible = false;
            panelAdd.Visible = true;
            panelDelete.Visible = false;
            panelCreateUser.Visible = false;
            panelSqlQuery.Visible = false;
            panelUpdate.Visible = false;
        }

        private void ShowDeletePanel()
        {
            panelSearch.Visible = false;
            panelAdd.Visible = false;
            panelDelete.Visible = true;
            panelCreateUser.Visible = false;
            panelSqlQuery.Visible = false;
            panelUpdate.Visible = false;
        }

        private void ShowUpdatePanel()
        {
            panelSearch.Visible = false;
            panelAdd.Visible = false;
            panelDelete.Visible = false;
            panelCreateUser.Visible = false;
            panelSqlQuery.Visible = false;
            panelUpdate.Visible = true;
        }

        private void ShowSqlQueryPanel()
        {
            panelSearch.Visible = false;
            panelAdd.Visible = false;
            panelDelete.Visible = false;
            panelCreateUser.Visible = false;
            panelSqlQuery.Visible = true;
            panelUpdate.Visible = false;
        }

        private void ShowCreateUserPanel()
        {
            panelSearch.Visible = false;
            panelAdd.Visible = false;
            panelDelete.Visible = false;
            panelCreateUser.Visible = true;
            panelSqlQuery.Visible = false;
            panelUpdate.Visible = false;
        }

        private void добавлениеТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddPanel();
        }

        private void поискТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSearchPanel();
        }

        private void обновлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUpdatePanel();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDeletePanel();
        }

        private void sQLЗапросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSqlQueryPanel();
        }

        private void созданиеНовогоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCreateUserPanel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowSearchPanel();
            this.Controls.Add(this.panelAdd);
            this.Controls.Add(this.panelCreateUser);
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkTextBox.Enabled = false;
                checkCondition.Enabled = false;
                checkCondition.Text = "";
            }
            else
            {
                checkTextBox.Enabled = true;
                checkCondition.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string tableName = ChooseTable.SelectedItem.ToString();
                string type = checkBox1.Checked ? "2" : "1";
                string condition = checkTextBox.Text.Trim();

                string command = type == "2"
                    ? $"SEARCH {tableName} {type} {condition}"
                    : $"SEARCH {tableName} {type}";

                string response = SendCommand(command);

                var dt = new DataTable();

                var lines = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);


                if (tableName == "Patients")
                {
                    dt.Columns.AddRange(new[]
                    {
                    new DataColumn("Id"),
                    new DataColumn("Name"),
                    new DataColumn("Address"),
                    new DataColumn("Sex"),
                    new DataColumn("BirthDate"),
                    new DataColumn("InsuranceType"),
                    new DataColumn("InsuranceExpDate")
                });

                    foreach (string line in lines)
                    {
                        string[] values = line.Split('\t');
                        if (values.Length == 7)
                            dt.Rows.Add(values);
                    }
                }
                else if (tableName == "Doctors")
                {
                    dt.Columns.AddRange(new[]
                    {
                    new DataColumn("Id"),
                    new DataColumn("Name"),
                    new DataColumn("Sex"),
                    new DataColumn("BirthDate"),
                    new DataColumn("Speciality"),
                    new DataColumn("WorkExperience")
                });

                    foreach (string line in lines)
                    {
                        string[] values = line.Split('\t');
                        if (values.Length == 6)
                            dt.Rows.Add(values);
                    }
                }
                else if (tableName == "Wards")
                {
                    dt.Columns.AddRange(new[]
                    {
                    new DataColumn("Id"),
                    new DataColumn("NumBeds"),
                    new DataColumn("WardType")
                });

                    foreach (string line in lines)
                    {
                        string[] values = line.Split('\t');
                        if (values.Length == 3)
                            dt.Rows.Add(values);
                    }
                }
                else if (tableName == "MedHistories")
                {
                    dt.Columns.AddRange(new[]
                    {
                    new DataColumn("Id"),
                    new DataColumn("PatientId"),
                    new DataColumn("Diseases"),
                    new DataColumn("Status"),
                    new DataColumn("DoctorId"),
                    new DataColumn("WardId"),
                    new DataColumn("TreatmentCost"),
                    new DataColumn("RecordDate"),
                    new DataColumn("DischargeDate")
                });

                    foreach (string line in lines)
                    {
                        string[] values = line.Split('\t');
                        if (values.Length == 9)
                            dt.Rows.Add(values);
                    }
                }

                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, выберите существующую таблицу");
            }
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            string id = txtPatientId.Text.Trim();
            string name = txtPatientName.Text.Trim();
            string address = txtPatientAddress.Text.Trim();
            string sex = txtPatientSex.Text.Trim();
            string birthDate = txtPatientBirthDate.Text.Trim();
            string insuranceType = txtPatientInsuranceType.Text.Trim();
            string insuranceExp = txtPatientInsuranceExp.Text.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("ID и Name обязательны.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string data = $"{id}|{name}|{address}|{sex}|{birthDate}|{insuranceType}|{insuranceExp}";

            string command = $"ADD Patients {data}";

            string response = SendCommand(command);

            if (response == "OK")
            {
                MessageBox.Show($"Пациент добавлен: {data}", "ОК", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"Ошибка добавления: {response}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddDoctorButton_Click(object sender, EventArgs e)
        {
            string id = txtDoctorId.Text.Trim();
            string name = txtDoctorName.Text.Trim();
            string sex = txtDoctorSex.Text.Trim();
            string birthDate = txtDoctorBirthday.Text.Trim();
            string speciallity = txtDoctorSpeciallity.Text.Trim();
            string workExperience = txtDoctorWorkExperience.Text.Trim();

            string data = $"{id}|{name}|{sex}|{birthDate}|{speciallity}|{workExperience}";

            string command = $"ADD Doctors {data}";

            string response = SendCommand(command);
            MessageBox.Show(response == "OK" ? $"Запись добавлена успешно - {data}" : $"Ошибка добавления: {response}");
        }

        private void AddWardButton_Click(object sender, EventArgs e)
        {
            string id = txtWardId.Text.Trim();
            string numBeds = txtWardNumBeds.Text.Trim();
            string wardType = txtWardType.Text.Trim();

            string data = $"{id}|{numBeds}|{wardType}";

            string command = $"ADD Wards {data}";

            string response = SendCommand(command);
            MessageBox.Show(response == "OK" ? $"Запись добавлена успешно - {data}" : $"Ошибка добавления: {response}");
        }

        private void AddMedHistoryButton_Click(object sender, EventArgs e)
        {
            string id = txtMedHistoryId.Text.Trim();
            string patienttID = txtMedHistoryIdPatient.Text.Trim();
            string diseases = txtMedHistoryDeseases.Text.Trim();
            string status = txtMedHistoryStatus.Text.Trim();
            string doctorId = txtMedHistoryIdDoctor.Text.Trim();
            string wardId = txtMedHistoryIdWard.Text.Trim();
            string treatmentCost = txtMedHistoryTreatmentCost.Text.Trim();
            string recordDate = txtMedHistoryRecordDate.Text.Trim();
            string dischargeDate = txtMedHistoryDischargeDate.Text.Trim();

            string data = $"{id}|{patienttID}|{diseases}|{status}|{doctorId}|{wardId}|{treatmentCost}|{recordDate}|{dischargeDate}";

            string command = $"ADD MedHistories {data}";

            string response = SendCommand(command);
            MessageBox.Show(response == "OK" ? $"Запись добавлена успешно - {data}" : $"Ошибка добавления: {response}");
        }

        private async void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string command = "EXIT";
            string response = SendCommand(command);

            if (response.Trim() == "EXIT")
            {
                await Task.Delay(1000);

                IsLogoutRequested = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при выходе: " + response);
            }
        }

        public bool IsLogoutRequested { get; private set; } = false;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string delete_id = txtDeleteId.Text.Trim();
                string table = ChooseTable_2.Text.Trim();

                string command = $"DELETE {table} {delete_id}";
                string response = SendCommand(command);
                MessageBox.Show(response == "OK" ? $"Запись с ID = {delete_id} в таблице {table} успешно удалена" : $"Ошибка удаления: {response}");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, выберите существующую таблицу");
            }
        }

        private void buttonCreateUser_Click_1(object sender, EventArgs e)
        {
            string username = txtUserEnter.Text.Trim();
            string password = txtPasswordEnter.Text.Trim();

            string command = $"CREATE_USER {username} {password}";
            string response = SendCommand(command);
            MessageBox.Show($"{response}");
        }

        private void sqlButton_Click(object sender, EventArgs e)
        {
            try
            {
                string table = ChooseTable_3.Text.Trim();
                string query = txtSqlInput.Text.Trim();

                if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(query))
                {
                    MessageBox.Show("Введите таблицу и SQL-запрос.");
                    return;
                }

                string command = $"SQL_QUERY {table} {query}";
                string response = SendCommand(command);

                txtSqlOutput.Text = response;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, выберите существующую таблицу");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string table = ChooseTable_4.Text.Trim();
                string idText = txtEnterIdForTable.Text.Trim();
                string condition = txtConditionForTable.Text.Trim();

                if (!int.TryParse(idText, out int id))
                {
                    MessageBox.Show("Неверный формат ID.");
                    return;
                }

                string command = $"UPDATE {table} {id} {condition}";
                string response = SendCommand(command);

                MessageBox.Show(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
