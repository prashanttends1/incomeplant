using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class LedgerAccount
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Ledger Account Type")] 
        public int? LedgerAccountTypeId { get; set; }
        public virtual LedgerAccountType LedgerAccountType_LedgerAccountTypeId { get; set; }
        [Required]
        [StringLength(10)] 
        [DisplayName("Currency")] 
        public string Currency { get; set; }
        [StringLength(50)] 
        [DisplayName("Account Code")] 
        public string AccountCode { get; set; }
        [StringLength(10)] 
        [DisplayName("Account Color")] 
        public string AccountColor { get; set; }
        [DisplayName("Parent")] 
        public Nullable<int> ParentId { get; set; }
        public virtual LedgerAccount LedgerAccount2 { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        public virtual ICollection<LedgerAccount> LedgerAccount_ParentIds { get; set; }
        public virtual ICollection<Transaction> Transaction_DebitLedgerAccountIds { get; set; }
        public virtual ICollection<Transaction> Transaction_CreditLedgerAccountIds { get; set; }

    }
}
