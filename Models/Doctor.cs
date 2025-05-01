using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string sex { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Speciallity { get; set; }
        public int WorkExperience { get; set; }
    }
}
