using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class Transaction
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Date Added")] 
        public DateTime DateAdded { get; set; }
        [Required]
        [DisplayName("Added By")] 
        public int AddedBy { get; set; }
        [Required]
        [DisplayName("Company Office")] 
        public int CompanyOfficeId { get; set; }
        [DisplayName("Debit Ledger Account")] 
        public int? DebitLedgerAccountId { get; set; }
        public virtual LedgerAccount LedgerAccount_DebitLedgerAccountId { get; set; }
        [DisplayName("Debit Amount")] 
        public Nullable<double> DebitAmount { get; set; }
        [DisplayName("Credit Ledger Account")] 
        public int? CreditLedgerAccountId { get; set; }
        public virtual LedgerAccount LedgerAccount_CreditLedgerAccountId { get; set; }
        [DisplayName("Credit Amount")] 
        public Nullable<double> CreditAmount { get; set; }
        [Required]
        [DisplayName("Transaction Date")] 
        public DateTime TransactionDate { get; set; }
        public virtual ICollection<DonationTransaction> DonationTransaction_TransactionIds { get; set; }

    }
}
