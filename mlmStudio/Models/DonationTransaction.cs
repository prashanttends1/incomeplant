using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class DonationTransaction
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Donation Request")] 
        public int? DonationRequestId { get; set; }
        public virtual DonationRequest DonationRequest_DonationRequestId { get; set; }
        [Required]
        [DisplayName("Transaction")] 
        public int? TransactionId { get; set; }
        public virtual Transaction Transaction_TransactionId { get; set; }

    }
}
