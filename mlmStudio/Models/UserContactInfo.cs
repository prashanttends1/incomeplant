using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class UserContactInfo
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Contact Type")] 
        public int? ContactTypeId { get; set; }
        public virtual ContactType ContactType_ContactTypeId { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Contact Detail")] 
        public string ContactDetail { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }

    }
}
