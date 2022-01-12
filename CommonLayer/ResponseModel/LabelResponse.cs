using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.ResponseModel
{
    public class LabelResponse
    {
        public long Lable_Id { get; set; }
        public long Notes_Id { get; set; }
        public long User_Id { get; set; }
        public string Lable_Name { get; set; }
    }
}
