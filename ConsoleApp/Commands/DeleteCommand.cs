using EternalPeace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Commands
{
    public class DeleteCommand : ICommand
    {
        private readonly string _table;
        private readonly int _id;

        public DeleteCommand(string table, int id)
        {
            _table = table;
            _id = id;
        }

        public string Execute(EternalPeaceDbContext context)
        {
            try
            {
                if (_table == "Patients")
                {
                    var patient = context.Patients.Find(_id);
                    if (patient == null)
                        return $"ERROR: Пациент с ID = {_id} не найден.";

                    context.Patients.Remove(patient);
                }
                else if (_table == "Doctors")
                {
                    var doctor = context.Doctors.Find(_id);
                    if (doctor == null)
                        return $"ERROR: Доктор с ID = {_id} не найден.";

                    context.Doctors.Remove(doctor);
                }
                else if (_table == "Wards")
                {
                    var ward = context.Wards.Find(_id);
                    if (ward == null)
                        return $"ERROR: Палата с ID = {_id} не найдена.";

                    context.Wards.Remove(ward);
                }
                else if (_table == "MedHistories")
                {
                    var history = context.MedHistories.Find(_id);
                    if (history == null)
                        return $"ERROR: История болезни с ID = {_id} не найдена.";

                    context.MedHistories.Remove(history);
                }
                else
                {
                    return "ERROR: Неизвестная таблица.";
                }

                context.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }
    }
}
