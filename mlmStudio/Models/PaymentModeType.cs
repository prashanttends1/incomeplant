using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class PaymentModeType
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }

    }
}
