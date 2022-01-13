using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.ResponseModel
{
    public class UserNotesResponse
    {
        public long Id { get; set; }

       
        public string Title { get; set; }

        
        public string Message { get; set; }

        public DateTime Remainder { get; set; }
        public string Color { get; set; }

        public string Image { get; set; }
        public string Image_Id { get; set; }

        public bool IsArchive { get; set; }
        public bool IsPin { get; set; }

        public bool IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
