using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OderApplication.Models.ModelViews
{
    public class DriverVM
    {
        public Ambulance Ambulance { get; set; }
        public IEnumerable<SelectListItem>TypeDropDown { get; set; }

    }
}
