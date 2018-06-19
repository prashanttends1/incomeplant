using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class ePinRequest
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Qty")] 
        public int Qty { get; set; }
        [Required]
        [DisplayName("From User")] 
        public int? FromUserId { get; set; }
        public virtual User User_FromUserId { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Is Approved")] 
        public Nullable<bool> IsApproved { get; set; }
        [DisplayName("Approved By")] 
        public Nullable<int> ApprovedBy { get; set; }
        public virtual ICollection<ePinCode> ePinCode_ePinRequestIds { get; set; }

    }
}
