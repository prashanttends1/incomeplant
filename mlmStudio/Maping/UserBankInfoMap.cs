using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class UserBankInfoMap : EntityTypeConfiguration<UserBankInfo> 
    {
        public UserBankInfoMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.AccountHolderName).HasMaxLength(100);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserBankInfo_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(false);
             Property(o => o.BankName).HasMaxLength(100);
             Property(o => o.AccountNumber).HasMaxLength(100);
             Property(o => o.Branch).HasMaxLength(200);
             Property(o => o.IFCI_Code).HasMaxLength(100);
             ToTable("UserBankInfo");
 

        }
    }
}
