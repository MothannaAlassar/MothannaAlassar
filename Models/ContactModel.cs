using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MothannaCV.Models
{
    public class ContactModel
    {
        public string txtFirstname { get; set; }
        [Required(ErrorMessage = "Phone Number Required!")]
        public string txtPhone { get; set; }
        [Required]

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string txtEmail { get; set; }
        [Required]
        public string txtSubject { get; set; }
        [Required]
        public string txtMessage { get; set; }

        //  public Showpopup Showpopupmodel { get; set; }
        public Uri strUrl { get; set; }
        public string theme_title { get; set; }
        public string CompanyTitleEn { get; set; }
        public string CompanyTitleAr { get; set; }
        public string Logo { get; set; }
        // public DocumentViewModel docmodel { get; set; }

        public string googlemap_key { get; set; }
        public string page_name { get; set; }
        public string title { get; set; }
        public string Message { get; set; }
    }
}
