using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OderApplication.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Category Name ")]
                    [Required]
        public String CategoryName { get; set; }
        [DisplayName("Display Order")]
                   [Required]
        public String DisplayOrder { get; set; }
    }
}
