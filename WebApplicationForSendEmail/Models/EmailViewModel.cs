using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationForSendEmail.Models
{
    public class EmailViewModel
    {

        [Required(ErrorMessage ="Please email address for send email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string ToEmailId { get; set; }

        [Required(ErrorMessage ="Please enter subject")]
        [StringLength(150)] 
        public string Subject { get; set; }

        [Required(ErrorMessage ="Please enter email text")]
        [StringLength(5000)] 
        public string BodyText { get; set; }
    }
}