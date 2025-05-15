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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tableName = ChooseTable.SelectedItem.ToString();
            string type = checkBox1.Checked ? "2" : "1";

            string condition = checkTextBox.Text.Trim();

            string command = type == "2"
                ? $"SEARCH {tableName} {type} {condition}"
                : $"SEARCH {tableName} {type}";

            string response = SendCommand($"SEARCH {tableName}||{type}||{condition}");

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

        private string SendCommand(string command)
        {
            try
            {
                using var client = new TcpClient("127.0.0.1", 5000);
                using var stream = client.GetStream();

                byte[] data = Encoding.UTF8.GetBytes(command);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[4096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
            catch
            {
                return "ERROR";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
    }
}
