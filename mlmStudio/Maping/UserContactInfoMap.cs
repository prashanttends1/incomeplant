using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class UserContactInfoMap : EntityTypeConfiguration<UserContactInfo> 
    {
        public UserContactInfoMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.ContactType_ContactTypeId).WithMany(o => o.UserContactInfo_ContactTypeIds).HasForeignKey(o => o.ContactTypeId).WillCascadeOnDelete(false);
             Property(o => o.ContactDetail).HasMaxLength(200);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserContactInfo_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(false);
             ToTable("UserContactInfo");
 

        }
    }
}
