using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class Lable_Model
    {
        [DataType(DataType.Text)]
        public string Lable { get; set; }
        public long Notes_Id { get; set; }

    }
}
