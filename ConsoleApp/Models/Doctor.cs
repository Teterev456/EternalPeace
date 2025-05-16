using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sex { get; set; }

        public DateOnly BirthDate { get; set; }

        [Required]
        public string Speciallity { get; set; }
        [Required]
        public int WorkExperience { get; set; }

        public virtual ICollection<MedHistory> MedHistories { get; set; } = new List<MedHistory>();
    }
}
