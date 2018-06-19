using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class RewardMap : EntityTypeConfiguration<Reward> 
    {
        public RewardMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(200);
             Property(o => o.Detail).HasMaxLength(1000);
             HasRequired(c => c.RewardType_RewardTypeId).WithMany(o => o.Reward_RewardTypeIds).HasForeignKey(o => o.RewardTypeId).WillCascadeOnDelete(false);
             ToTable("Reward");
 

        }
    }
}
