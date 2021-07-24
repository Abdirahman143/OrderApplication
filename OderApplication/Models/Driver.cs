using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OderApplication.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name{ get; set; }
    }
}
