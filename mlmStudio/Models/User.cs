using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class User
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Username")] 
        [Index(IsUnique=true)]
        public string Username { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Password")] 
        public string Password { get; set; }
        [DisplayName("Parent")] 

        public Nullable<int> ParentId { get; set; }
        public virtual User User2 { get; set; }

        [DisplayName("Sponser")]
        public Nullable<int> SponserId { get; set; }
        public virtual User User3 { get; set; }

        [DisplayName("Leg")] 
        public int? LegId { get; set; }
        public virtual Leg Leg_LegId { get; set; }
        [Required]
        [DisplayName("Member Ship Level")] 
        public int? MemberShipLevelId { get; set; }
        public virtual MemberShipLevel MemberShipLevel_MemberShipLevelId { get; set; }
        [StringLength(35)] 
        [DisplayName("Register Pin")] 
        public string RegisterPin { get; set; }
        public string pan { get; set; }
        public string bank { get; set; }
        public string photo { get; set; }
        public string address { get; set; }
        public Nullable<int> ProductId { get; set; }
        public virtual ICollection<RoleUser> RoleUser_UserIds { get; set; }
        public virtual ICollection<MenuPermission> MenuPermission_UserIds { get; set; }
        public virtual ICollection<UserPersonalInfo> UserPersonalInfo_UserIds { get; set; }
        public virtual ICollection<UserContactInfo> UserContactInfo_UserIds { get; set; }
        public virtual ICollection<User> User_ParentIds { get; set; }
        public virtual ICollection<UserBankInfo> UserBankInfo_UserIds { get; set; }
        public virtual ICollection<Invoice> Invoice_ClientIds { get; set; }
        public virtual ICollection<RewardUser> RewardUser_UserIds { get; set; }
        public virtual ICollection<ePinRequest> ePinRequest_FromUserIds { get; set; }
        public virtual ICollection<DonationRequest> DonationRequest_UserIds { get; set; }
        public virtual ICollection<LedgerAccount> LedgerAccount_UserIds { get; set; }

    }
}
