
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OderApplication.Models
{
    public class Ambulance
    {
        [Key]
        public  int Id { get; set; }
           //[Required]
        public String Model { get; set; }
        [DisplayName("Number Plate")]
               //[Required]
        public String NumberPlate { get; set; }

         [DisplayName("Driver Name")]
        public int DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }


    }
}
