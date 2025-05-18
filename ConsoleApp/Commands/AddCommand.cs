using EternalPeace.Commands;
using EternalPeace.Data;
using EternalPeace.Models;
using System;

namespace EternalPeace.Command
{
    public class AddCommand : ICommand
    {
        private readonly string _table;
        private readonly string[] _fields;

        public AddCommand(string table, string[] fields)
        {
            _table = table;
            _fields = string.Join(' ', fields).Split('|', StringSplitOptions.None);
        }

        public string Execute(EternalPeaceDbContext context)
        {
            try
            {
                if (_table == "Patients")
                {
                    if (_fields.Length != 7)
                        return "ERROR: Expected 7 fields for Patients.";

                    if (!int.TryParse(_fields[0], out int id))
                        return "ERROR: Invalid Id for Patients.";

                    string name = _fields[1];
                    string address = _fields[2];
                    string sex = _fields[3];

                    if (!DateOnly.TryParse(_fields[4], out DateOnly birthDate))
                        return "ERROR: Invalid BirthDate for Patients.";

                    string insuranceType = _fields[5];

                    DateOnly? insuranceExpDate = null;
                    if (!string.IsNullOrWhiteSpace(_fields[6]))
                    {
                        if (!DateOnly.TryParse(_fields[6], out DateOnly tempDate))
                            return "ERROR: Invalid InsuranceExpDate for Patients.";
                        insuranceExpDate = tempDate;
                    }

                    if (context.Patients.Any(p => p.Id == id))
                        return "ERROR: Patient already exists";

                    var patient = new Patient
                    {
                        Id = id,
                        Name = name,
                        Address = address,
                        Sex = sex,
                        BirthDate = birthDate,
                        InsuranceType = insuranceType,
                        InsuranceExpDate = insuranceExpDate
                    };

                    context.Patients.Add(patient);
                }
                else if (_table == "Doctors")
                {
                    if (_fields.Length != 6)
                        return "ERROR: Expected 6 fields for Doctors.";

                    if (!int.TryParse(_fields[0], out int id))
                        return "ERROR: Invalid Id for Doctors.";

                    string name = _fields[1];
                    string sex = _fields[2];

                    if (!DateOnly.TryParse(_fields[3], out DateOnly birthDate))
                        return "ERROR: Invalid BirthDate for Doctors.";

                    string speciality = _fields[4];

                    if (!int.TryParse(_fields[5], out int workExperience))
                        return "ERROR: Invalid WorkExperience for Doctors.";

                    if (context.Doctors.Any(d => d.Id == id))
                        return "ERROR: Doctor already exists";

                    var doctor = new Doctor
                    {
                        Id = id,
                        Name = name,
                        Sex = sex,
                        BirthDate = birthDate,
                        Speciallity = speciality,
                        WorkExperience = workExperience
                    };

                    context.Doctors.Add(doctor);
                }
                else if (_table == "Wards")
                {
                    if (_fields.Length != 3)
                        return "ERROR: Expected 3 fields for Wards.";

                    if (!int.TryParse(_fields[0], out int id))
                        return "ERROR: Invalid Id for Wards.";

                    if (!int.TryParse(_fields[1], out int numBeds))
                        return "ERROR: Invalid NumBeds for Wards.";

                    string wardType = _fields[2];

                    if (context.Wards.Any(w => w.Id == id))
                        return "ERROR: Ward already exists";

                    var ward = new Ward
                    {
                        Id = id,
                        NumBeds = numBeds,
                        WardType = wardType
                    };

                    context.Wards.Add(ward);
                }
                else if (_table == "MedHistories")
                {
                    if (_fields.Length != 9)
                        return "ERROR: Expected 9 fields for MedHistories.";

                    if (!int.TryParse(_fields[0], out int id))
                        return "ERROR: Invalid Id for MedHistories.";

                    if (!int.TryParse(_fields[1], out int patientId))
                        return "ERROR: Invalid PatientId for MedHistories.";

                    string diseases = _fields[2];
                    string status = _fields[3];

                    if (!int.TryParse(_fields[4], out int doctorId))
                        return "ERROR: Invalid DoctorId for MedHistories.";

                    if (!int.TryParse(_fields[5], out int wardId))
                        return "ERROR: Invalid WardId for MedHistories.";

                    if (!decimal.TryParse(_fields[6], out decimal treatmentCost))
                        return "ERROR: Invalid TreatmentCost for MedHistories.";

                    if (!DateOnly.TryParse(_fields[7], out DateOnly recordDate))
                        return "ERROR: Invalid RecordDate for MedHistories.";

                    DateOnly? dischargeDate = null;
                    if (!string.IsNullOrWhiteSpace(_fields[8]))
                    {
                        if (!DateOnly.TryParse(_fields[8], out DateOnly tempDate))
                            return "ERROR: Invalid DischargeDate for MedHistories.";
                        dischargeDate = tempDate;
                    }

                    if (context.MedHistories.Any(m => m.Id == id))
                        return "ERROR: MedHistory already exists";

                    var medHistory = new MedHistory
                    {
                        Id = id,
                        PatientId = patientId,
                        Diseases = diseases,
                        Status = status,
                        DoctorId = doctorId,
                        WardId = wardId,
                        TreatmentCost = treatmentCost,
                        RecordDate = recordDate,
                        DischargeDate = dischargeDate
                    };

                    context.MedHistories.Add(medHistory);
                }
                else
                {
                    return "ERROR: Unknown table";
                }

                context.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return $"ERROR: Invalid data for {_table}. {ex.Message}";
            }
        }
    }
}