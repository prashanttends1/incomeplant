using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class ContactType
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Type Name")] 
        public string TypeName { get; set; }
        public virtual ICollection<UserContactInfo> UserContactInfo_ContactTypeIds { get; set; }

    }
}
