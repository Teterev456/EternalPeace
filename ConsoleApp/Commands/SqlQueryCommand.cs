using EternalPeace.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Commands
{
    public class SqlQueryCommand : ICommand
    {
        private readonly string _table;
        private readonly string _sqlQuery;

        public SqlQueryCommand(string table, string sqlQuery)
        {
            _table = table;
            _sqlQuery = sqlQuery;
        }

        public string Execute(EternalPeaceDbContext context)
        {
            var entityTypes = context.Model.GetEntityTypes();

            bool tableExists = entityTypes.Any(e => e.GetTableName() == _table);
            if (!tableExists)
                return "Такой таблицы нет.";

            var sb = new StringBuilder();

            try
            {
                if (_table == "Patients")
                {
                    var result = context.Patients.FromSqlRaw(_sqlQuery).ToList();
                    foreach (var patient in result)
                    {
                        sb.AppendLine($"{patient.Id}\t{patient.Name}\t{patient.Address}\t{patient.Sex}\t{patient.BirthDate:yyyy-MM-dd}\t{patient.InsuranceType}\t{(patient.InsuranceExpDate.HasValue ? patient.InsuranceExpDate.Value.ToString("yyyy-MM-dd") : "")}");
                    }
                }
                else if (_table == "Doctors")
                {
                    var result = context.Doctors.FromSqlRaw(_sqlQuery).ToList();
                    foreach (var doctor in result)
                    {
                        sb.AppendLine($"{doctor.Id}\t{doctor.Name}\t{doctor.Sex}\t{doctor.BirthDate:yyyy-MM-dd}\t{doctor.Speciallity}\t{doctor.WorkExperience}");
                    }
                }
                else if (_table == "Wards")
                {
                    var result = context.Wards.FromSqlRaw(_sqlQuery).ToList();
                    foreach (var ward in result)
                    {
                        sb.AppendLine($"{ward.Id}\t{ward.NumBeds}\t{ward.WardType}");
                    }
                }
                else if (_table == "MedHistories")
                {
                    var result = context.MedHistories.FromSqlRaw(_sqlQuery).ToList();
                    foreach (var medhistory in result)
                    {
                        sb.AppendLine($"{medhistory.Id}\t{medhistory.PatientId}\t{medhistory.Diseases}\t{medhistory.Status}\t{medhistory.DoctorId}\t{medhistory.WardId}\t{medhistory.TreatmentCost}\t{medhistory.RecordDate:yyyy-MM-dd}\t{(medhistory.DischargeDate.HasValue ? medhistory.DischargeDate.Value.ToString("yyyy-MM-dd") : "")}");
                    }
                }
                else
                {
                    return "Такой таблицы нет.";
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка выполнения SQL-запроса:\n{ex.Message}";
            }

            return sb.ToString();
        }
    }
}