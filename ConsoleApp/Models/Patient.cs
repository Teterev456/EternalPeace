using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Sex { get; set; }
        public DateOnly BirthDate { get; set; }

        public string InsuranceType { get; set; }
        public DateOnly? InsuranceExpDate { get; set; }

        public virtual ICollection<MedHistory> MedHistories { get; set; } = new List<MedHistory>();
    }
}
