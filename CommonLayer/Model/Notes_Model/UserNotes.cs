using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CommonLayer.Model
{
    public class UserNotes
    {
        [Required(ErrorMessage = "Title is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Message:")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Remainder is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Remainder:")]
        public DateTime Remainder { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Color:")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image:")]
        public IFormFile Image { get; set; }


        public bool IsArchive { get; set; }

        
        public bool IsPin { get; set; }

       
        public bool IsTrash { get; set; }



    }
}
