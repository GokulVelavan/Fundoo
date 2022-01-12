using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.ResponseModel
{
    public class ColorResponse
    {
        [Display(Name = "Color")]
        public string Color { get; set; }
    }
}
