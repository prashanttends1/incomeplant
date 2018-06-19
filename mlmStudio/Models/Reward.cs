using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class Reward
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [DisplayName("Detail")] 
        public string Detail { get; set; }
        [Required]
        [DisplayName("Reward Type")] 
        public int? RewardTypeId { get; set; }
        public virtual RewardType RewardType_RewardTypeId { get; set; }
        [DisplayName("Is Active")] 
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<RewardUser> RewardUser_RewardIds { get; set; }

    }
}
