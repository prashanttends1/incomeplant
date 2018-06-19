using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class RewardUserMap : EntityTypeConfiguration<RewardUser> 
    {
        public RewardUserMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.RewardUser_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(false);
             HasRequired(c => c.Reward_RewardId).WithMany(o => o.RewardUser_RewardIds).HasForeignKey(o => o.RewardId).WillCascadeOnDelete(false);
             ToTable("RewardUser");
 

        }
    }
}
