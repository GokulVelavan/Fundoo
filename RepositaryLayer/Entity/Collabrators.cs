using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Entity
{
    public class Collabrators
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Collaborator_Id { get; set; }


        public long Notes_Id { get; set; }
        [ForeignKey("Notes_Id")]

        public Notes Notes { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Collaborated_Email { get; set; }
    }
}
