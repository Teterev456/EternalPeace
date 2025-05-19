using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Models
{
    public class MedHistory
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Diseases { get; set; }
        public string Status { get; set; }
        public int DoctorId { get; set; }
        public int WardId { get; set; }
        public decimal TreatmentCost { get; set; }

        public DateOnly RecordDate { get; set; }
        public DateOnly? DischargeDate { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; } = null!;

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; } = null!;

        [ForeignKey("WardId")]
        public virtual Ward Ward { get; set; } = null!;

    }
}
