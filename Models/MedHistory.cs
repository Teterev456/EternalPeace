using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Models
{
    public class MedHistory
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Diseases { get; set; }
        public string DiseasesStatus { get; set; }
        public int DoctorId { get; set; }
        public int WardId { get; set; }
        public int TreatmentCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RecordDate { get; set; }
        public string DischargeDate { get; set; }
    }
}
