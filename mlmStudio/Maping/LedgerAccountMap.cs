using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class LedgerAccountMap : EntityTypeConfiguration<LedgerAccount> 
    {
        public LedgerAccountMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(50);
             HasRequired(c => c.LedgerAccountType_LedgerAccountTypeId).WithMany(o => o.LedgerAccount_LedgerAccountTypeIds).HasForeignKey(o => o.LedgerAccountTypeId).WillCascadeOnDelete(false);
             Property(o => o.Currency).HasMaxLength(10);
             Property(o => o.AccountCode).HasMaxLength(50);
             Property(o => o.AccountColor).HasMaxLength(10);
             HasOptional(c => c.LedgerAccount2).WithMany(o => o.LedgerAccount_ParentIds).HasForeignKey(o => o.ParentId);
             HasRequired(c => c.User_UserId).WithMany(o => o.LedgerAccount_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             ToTable("LedgerAccount");
 

        }
    }
}
