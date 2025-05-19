using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
    }
}
