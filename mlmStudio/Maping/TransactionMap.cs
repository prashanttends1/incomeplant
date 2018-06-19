using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class TransactionMap : EntityTypeConfiguration<Transaction> 
    {
        public TransactionMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(50);
             HasOptional(c => c.LedgerAccount_DebitLedgerAccountId).WithMany(o => o.Transaction_DebitLedgerAccountIds).HasForeignKey(o => o.DebitLedgerAccountId);
             HasOptional(c => c.LedgerAccount_CreditLedgerAccountId).WithMany(o => o.Transaction_CreditLedgerAccountIds).HasForeignKey(o => o.CreditLedgerAccountId);
             ToTable("Transaction");
 

        }
    }
}
