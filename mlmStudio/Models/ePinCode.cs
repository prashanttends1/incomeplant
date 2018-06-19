using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class ePinCode
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("e Pin Request")] 
        public int? ePinRequestId { get; set; }
        public virtual ePinRequest ePinRequest_ePinRequestId { get; set; }
        [StringLength(35)] 
        [DisplayName("P Code")] 
        public string PCode { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }

    }
}
