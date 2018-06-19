using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class InvoiceTransaction
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Transaction")] 
        public int TransactionId { get; set; }
        [Required]
        [DisplayName("Invoice")] 
        public int? InvoiceId { get; set; }
        public virtual Invoice Invoice_InvoiceId { get; set; }

    }
}
