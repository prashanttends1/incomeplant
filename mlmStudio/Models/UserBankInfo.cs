using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class UserBankInfo
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [StringLength(100)] 
        [DisplayName("Account Holder Name")] 
        public string AccountHolderName { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [StringLength(100)] 
        [DisplayName("Bank Name")] 
        public string BankName { get; set; }
        [StringLength(100)] 
        [DisplayName("Account Number")] 
        public string AccountNumber { get; set; }
        [StringLength(200)] 
        [DisplayName("Branch")] 
        public string Branch { get; set; }
        [StringLength(100)] 
        [DisplayName("I F C I_ Code")] 
        public string IFCI_Code { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }

    }
}
