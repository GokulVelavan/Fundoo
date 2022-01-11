using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Entity
{
   public class Lables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Lable_Id { get; set; }


        public long Notes_Id { get; set; }
        [ForeignKey("Notes_Id")]
        public Notes Notes { get; set; }


        public long User_Id { get; set; }
        [ForeignKey("User_Id")]
        public Users Users { get; set; }


        [DataType(DataType.Text)]
        public string Lable { get; set; }
    }
}
