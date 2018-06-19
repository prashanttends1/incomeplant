using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class RewardUser
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [DisplayName("Reward")] 
        public int? RewardId { get; set; }
        public virtual Reward Reward_RewardId { get; set; }
        [DisplayName("Qty")] 
        public Nullable<int> Qty { get; set; }

    }
}
