using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class UserMap : EntityTypeConfiguration<User> 
    {
        public UserMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Username).HasMaxLength(100);
             Property(o => o.Password).HasMaxLength(100);
             HasOptional(c => c.User2).WithMany(o => o.User_ParentIds).HasForeignKey(o => o.ParentId);
             HasOptional(c => c.Leg_LegId).WithMany(o => o.User_LegIds).HasForeignKey(o => o.LegId);
             HasRequired(c => c.MemberShipLevel_MemberShipLevelId).WithMany(o => o.User_MemberShipLevelIds).HasForeignKey(o => o.MemberShipLevelId).WillCascadeOnDelete(false);
             Property(o => o.RegisterPin).HasMaxLength(35);
             ToTable("User");
 

        }
    }
}
