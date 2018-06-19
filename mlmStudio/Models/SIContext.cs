using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Models
{
    public class SIContext : DbContext
    {
        public SIContext()
            : base("name=SIConnectionString")
        {
        }

         
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<RoleUser> RoleUsers { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
		public virtual DbSet<UserPersonalInfo> UserPersonalInfos { get; set; }
		public virtual DbSet<Gender> Genders { get; set; }
		public virtual DbSet<UserContactInfo> UserContactInfos { get; set; }
		public virtual DbSet<ContactType> ContactTypes { get; set; }
		public virtual DbSet<Country> Countrys { get; set; }
		public virtual DbSet<State> States { get; set; }
		public virtual DbSet<City> Citys { get; set; }
		public virtual DbSet<UserBankInfo> UserBankInfos { get; set; }
		public virtual DbSet<PaymentModeType> PaymentModeTypes { get; set; }
		public virtual DbSet<ProductCategory> ProductCategorys { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Invoice> Invoices { get; set; }
		public virtual DbSet<PaymentStatus> PaymentStatuss { get; set; }
		public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
		public virtual DbSet<InvoiceTransaction> InvoiceTransactions { get; set; }
		public virtual DbSet<RewardType> RewardTypes { get; set; }
		public virtual DbSet<Reward> Rewards { get; set; }
		public virtual DbSet<RewardUser> RewardUsers { get; set; }
		public virtual DbSet<MemberShipLevel> MemberShipLevels { get; set; }
		public virtual DbSet<Leg> Legs { get; set; }
		public virtual DbSet<ePinRequest> ePinRequests { get; set; }
		public virtual DbSet<ePinCode> ePinCodes { get; set; }
		public virtual DbSet<DonationRequest> DonationRequests { get; set; }
		public virtual DbSet<DonationTransaction> DonationTransactions { get; set; }
		public virtual DbSet<LedgerAccountType> LedgerAccountTypes { get; set; }
		public virtual DbSet<LedgerAccount> LedgerAccounts { get; set; }
		public virtual DbSet<Transaction> Transactions { get; set; }

        

        //
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             
			modelBuilder.Configurations.Add(new mlmStudio.Maping.RoleMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.UserMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.RoleUserMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.MenuMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.MenuPermissionMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.UserPersonalInfoMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.GenderMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.UserContactInfoMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.ContactTypeMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.CountryMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.StateMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.CityMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.UserBankInfoMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.PaymentModeTypeMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.ProductCategoryMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.ProductMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.InvoiceMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.PaymentStatusMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.InvoiceItemMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.InvoiceTransactionMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.RewardTypeMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.RewardMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.RewardUserMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.MemberShipLevelMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.LegMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.ePinRequestMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.ePinCodeMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.DonationRequestMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.DonationTransactionMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.LedgerAccountTypeMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.LedgerAccountMap());
			modelBuilder.Configurations.Add(new mlmStudio.Maping.TransactionMap());


            base.OnModelCreating(modelBuilder);
        }
        //
    }
}
 
