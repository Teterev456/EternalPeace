using EternalPeace.Commands;
using EternalPeace.Data;
using EternalPeace.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Text;

namespace EternalPeace.Command
{
    public class SearchCommand : ICommand
    {
        private readonly string _table;
        private readonly string _type;
        private readonly string? _condition;

        public SearchCommand(string table, string type, string? condition = null)
        {
            _table = table;
            _type = type;
            _condition = condition;
        }

        public string Execute(EternalPeaceDbContext context)
        {
            if (_table == "Patients") return SearchPatients(context);
            if (_table == "Doctors") return SearchDoctors(context);
            if (_table == "Wards") return SearchWards(context);
            if (_table == "MedHistories") return SearchMedHistories(context);

            return "Такой таблицы нет.";
        }

        private string SearchPatients(EternalPeaceDbContext context)
        {
            if (_type == "1")
            {
                var patients = context.Patients.ToList();
                var sb = new StringBuilder();
                foreach (var patient in patients)
                {
                    string expDate = patient.InsuranceExpDate?.ToString("yyyy-MM-dd") ?? "-";
                    sb.AppendLine($"{patient.Id}\t{patient.Name}\t{patient.Address}\t{patient.Sex}\t{patient.BirthDate:yyyy-MM-dd}\t{patient.InsuranceType}\t{expDate}");
                }
                return sb.ToString();
            }

            if (_type == "2")
            {
                var (whereClause, parameters, error) = SearchUtils.BuildFilter(_condition);
                if (!string.IsNullOrEmpty(error)) return error;

                try
                {
                    var result = context.Patients.Where(whereClause, parameters).ToList();
                    if (result.Count == 0) return "Пациенты не найдены по заданному условию.";

                    var sb = new StringBuilder();
                    foreach (var patient in result)
                    {
                        string expDate = patient.InsuranceExpDate?.ToString("yyyy-MM-dd") ?? "-";
                        sb.AppendLine($"{patient.Id}\t{patient.Name}\t{patient.Address}\t{patient.Sex}\t{patient.BirthDate:yyyy-MM-dd}\t{patient.InsuranceType}\t{expDate}");
                    }

                    return sb.ToString();
                }
                catch
                {
                    return "Ошибка: неверный формат фильтра.";
                }
            }

            return "Неверный тип запроса.";
        }

        private string SearchDoctors(EternalPeaceDbContext context)
        {
            if (_type == "1")
            {
                var doctors = context.Doctors.ToList();
                var sb = new StringBuilder();
                foreach (var doctor in doctors)
                {
                    sb.AppendLine($"{doctor.Id}\t{doctor.Name}\t{doctor.Sex}\t{doctor.BirthDate:yyyy-MM-dd}\t{doctor.Speciallity}\t{doctor.WorkExperience}");
                }
                return sb.ToString();
            }

            if (_type == "2")
            {
                var (whereClause, parameters, error) = SearchUtils.BuildFilter(_condition);
                if (!string.IsNullOrEmpty(error)) return error;

                try
                {
                    var result = context.Doctors.Where(whereClause, parameters).ToList();
                    if (result.Count == 0) return "Доктора не найдены.";
                    var sb = new StringBuilder();
                    foreach (var doctor in result)
                    {
                        sb.AppendLine($"{doctor.Id}\t{doctor.Name}\t{doctor.Sex}\t{doctor.BirthDate:yyyy-MM-dd}\t{doctor.Speciallity}\t{doctor.WorkExperience}");
                    }
                    return sb.ToString();
                }
                catch
                {
                    return "Ошибка фильтрации.";
                }
            }

            return "Неверный тип запроса.";
        }

        private string SearchWards(EternalPeaceDbContext context)
        {
            if (_type == "1")
            {
                var wards = context.Wards.ToList();
                var sb = new StringBuilder();
                foreach (var ward in wards)
                {
                    sb.AppendLine($"{ward.Id}\t{ward.NumBeds}\t{ward.WardType}");
                }
                return sb.ToString();
            }

            if (_type == "2")
            {
                var (whereClause, parameters, error) = SearchUtils.BuildFilter(_condition);
                if (!string.IsNullOrEmpty(error)) return error;

                try
                {
                    var result = context.Wards.Where(whereClause, parameters).ToList();
                    if (result.Count == 0) return "Палаты не найдены.";
                    var sb = new StringBuilder();
                    foreach (var ward in result)
                    {
                        sb.AppendLine($"{ward.Id}\t{ward.NumBeds}\t{ward.WardType}");
                    }
                    return sb.ToString();
                }
                catch
                {
                    return "Ошибка фильтрации.";
                }
            }

            return "Неверный тип запроса.";
        }

        private string SearchMedHistories(EternalPeaceDbContext context)
        {
            if (_type == "1")
            {
                var histories = context.MedHistories.ToList();
                var sb = new StringBuilder();
                foreach (var h in histories)
                {
                    string discharge = h.DischargeDate?.ToString("yyyy-MM-dd") ?? "-";
                    sb.AppendLine($"{h.Id}\t{h.PatientId}\t{h.Diseases}\t{h.Status}\t{h.DoctorId}\t{h.WardId}\t{h.TreatmentCost}\t{h.RecordDate:yyyy-MM-dd}\t{discharge}");
                }
                return sb.ToString();
            }

            if (_type == "2")
            {
                var (whereClause, parameters, error) = SearchUtils.BuildFilter(_condition);
                if (!string.IsNullOrEmpty(error)) return error;

                try
                {
                    var result = context.MedHistories.Where(whereClause, parameters).ToList();
                    if (result.Count == 0) return "Истории болезни не найдены.";
                    var sb = new StringBuilder();
                    foreach (var h in result)
                    {
                        string discharge = h.DischargeDate?.ToString("yyyy-MM-dd") ?? "-";
                        sb.AppendLine($"{h.Id}\t{h.PatientId}\t{h.Diseases}\t{h.Status}\t{h.DoctorId}\t{h.WardId}\t{h.TreatmentCost}\t{h.RecordDate:yyyy-MM-dd}\t{discharge}");
                    }
                    return sb.ToString();
                }
                catch
                {
                    return "Ошибка фильтрации.";
                }
            }

            return "Неверный тип запроса.";
        }
    }
}