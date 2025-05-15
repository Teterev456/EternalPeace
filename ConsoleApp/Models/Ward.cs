using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Models
{
    public class Ward
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumBeds { get; set; }
        [Required]
        public string WardType { get; set; }

        public virtual ICollection<MedHistory> MedHistories { get; set; }
    }
}
