namespace mlmStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Latitude = c.String(maxLength: 15),
                        Longitude = c.String(maxLength: 15),
                        IsActive = c.Boolean(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(maxLength: 5),
                        IsActive = c.Boolean(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(maxLength: 3),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPersonalInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        GenderId = c.Int(nullable: false),
                        About = c.String(),
                        ProfileImage = c.String(maxLength: 200),
                        DateJoin = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        MiddleName = c.String(maxLength: 200),
                        Email = c.String(maxLength: 33),
                        FatherAndSpouseName = c.String(maxLength: 100),
                        DOB = c.DateTime(),
                        MotherName = c.String(maxLength: 100),
                        NomineName = c.String(maxLength: 100),
                        CityId = c.Int(nullable: false),
                        ZipCode = c.String(maxLength: 10),
                        PanNumber = c.String(maxLength: 50),
                        EducationDetail = c.String(maxLength: 500),
                        LastEmployeeFirm = c.String(maxLength: 100),
                        LastEmployeeYear = c.String(maxLength: 10),
                        LastEmployeeAnualIncome = c.String(maxLength: 100),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.GenderId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(),
                        LegId = c.Int(),
                        MemberShipLevelId = c.Int(nullable: false),
                        RegisterPin = c.String(maxLength: 35),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leg", t => t.LegId)
                .ForeignKey("dbo.MemberShipLevel", t => t.MemberShipLevelId)
                .ForeignKey("dbo.User", t => t.ParentId)
                .Index(t => t.LegId)
                .Index(t => t.MemberShipLevelId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.DonationRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        DateAdded = c.DateTime(),
                        RequiredTill = c.DateTime(),
                        IsActive = c.Boolean(),
                        RequestNote = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DonationTransaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonationRequestId = c.Int(nullable: false),
                        TransactionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonationRequest", t => t.DonationRequestId)
                .ForeignKey("dbo.Transaction", t => t.TransactionId)
                .Index(t => t.DonationRequestId)
                .Index(t => t.TransactionId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(nullable: false),
                        CompanyOfficeId = c.Int(nullable: false),
                        DebitLedgerAccountId = c.Int(),
                        DebitAmount = c.Double(),
                        CreditLedgerAccountId = c.Int(),
                        CreditAmount = c.Double(),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LedgerAccount", t => t.CreditLedgerAccountId)
                .ForeignKey("dbo.LedgerAccount", t => t.DebitLedgerAccountId)
                .Index(t => t.CreditLedgerAccountId)
                .Index(t => t.DebitLedgerAccountId);
            
            CreateTable(
                "dbo.LedgerAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        LedgerAccountTypeId = c.Int(nullable: false),
                        Currency = c.String(nullable: false, maxLength: 10),
                        AccountCode = c.String(maxLength: 50),
                        AccountColor = c.String(maxLength: 10),
                        ParentId = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LedgerAccount", t => t.ParentId)
                .ForeignKey("dbo.LedgerAccountType", t => t.LedgerAccountTypeId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.LedgerAccountTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LedgerAccountType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LedgerAccountType", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ePinRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Qty = c.Int(nullable: false),
                        FromUserId = c.Int(nullable: false),
                        DateAdded = c.DateTime(),
                        IsApproved = c.Boolean(),
                        ApprovedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.FromUserId)
                .Index(t => t.FromUserId);
            
            CreateTable(
                "dbo.ePinCode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ePinRequestId = c.Int(nullable: false),
                        PCode = c.String(maxLength: 35),
                        DateAdded = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ePinRequest", t => t.ePinRequestId)
                .Index(t => t.ePinRequestId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        LastEmailed = c.DateTime(),
                        OtherInvoiceCode = c.String(maxLength: 50),
                        ClientId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentStatus", t => t.Status)
                .ForeignKey("dbo.User", t => t.ClientId)
                .Index(t => t.Status)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.InvoiceItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        Description = c.String(maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitName = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.InvoiceTransaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leg",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberShipLevel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(),
                        SortOrder = c.Int(),
                        IsNavBar = c.Boolean(nullable: false),
                        IsCreate = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsUpdate = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.MenuId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.MenuId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuText = c.String(nullable: false, maxLength: 100),
                        MenuURL = c.String(nullable: false, maxLength: 400),
                        ParentId = c.Int(),
                        SortOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RewardUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RewardId = c.Int(nullable: false),
                        Qty = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reward", t => t.RewardId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.RewardId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reward",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Detail = c.String(maxLength: 1000),
                        RewardTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RewardType", t => t.RewardTypeId)
                .Index(t => t.RewardTypeId);
            
            CreateTable(
                "dbo.RewardType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBankInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountHolderName = c.String(maxLength: 100),
                        UserId = c.Int(nullable: false),
                        BankName = c.String(maxLength: 100),
                        AccountNumber = c.String(maxLength: 100),
                        Branch = c.String(maxLength: 200),
                        IFCI_Code = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserContactInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactTypeId = c.Int(nullable: false),
                        ContactDetail = c.String(nullable: false, maxLength: 200),
                        UserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactType", t => t.ContactTypeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ContactTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ContactType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentModeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        PurchaseCost = c.Double(nullable: false),
                        SalePrice = c.Double(),
                        IsActive = c.Boolean(nullable: false),
                        ProductImage = c.String(maxLength: 200),
                        BareCode = c.String(maxLength: 50),
                        Description = c.String(),
                        Manufacturer = c.String(maxLength: 200),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId)
                .Index(t => t.ProductCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategory", "ParentId", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.UserPersonalInfo", "UserId", "dbo.User");
            DropForeignKey("dbo.UserContactInfo", "UserId", "dbo.User");
            DropForeignKey("dbo.UserContactInfo", "ContactTypeId", "dbo.ContactType");
            DropForeignKey("dbo.UserBankInfo", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "ParentId", "dbo.User");
            DropForeignKey("dbo.RewardUser", "UserId", "dbo.User");
            DropForeignKey("dbo.RewardUser", "RewardId", "dbo.Reward");
            DropForeignKey("dbo.Reward", "RewardTypeId", "dbo.RewardType");
            DropForeignKey("dbo.MenuPermission", "UserId", "dbo.User");
            DropForeignKey("dbo.MenuPermission", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleUser", "UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.MenuPermission", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropForeignKey("dbo.User", "MemberShipLevelId", "dbo.MemberShipLevel");
            DropForeignKey("dbo.User", "LegId", "dbo.Leg");
            DropForeignKey("dbo.Invoice", "ClientId", "dbo.User");
            DropForeignKey("dbo.Invoice", "Status", "dbo.PaymentStatus");
            DropForeignKey("dbo.InvoiceTransaction", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.InvoiceItem", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.ePinRequest", "FromUserId", "dbo.User");
            DropForeignKey("dbo.ePinCode", "ePinRequestId", "dbo.ePinRequest");
            DropForeignKey("dbo.DonationRequest", "UserId", "dbo.User");
            DropForeignKey("dbo.DonationTransaction", "TransactionId", "dbo.Transaction");
            DropForeignKey("dbo.Transaction", "DebitLedgerAccountId", "dbo.LedgerAccount");
            DropForeignKey("dbo.Transaction", "CreditLedgerAccountId", "dbo.LedgerAccount");
            DropForeignKey("dbo.LedgerAccount", "UserId", "dbo.User");
            DropForeignKey("dbo.LedgerAccount", "LedgerAccountTypeId", "dbo.LedgerAccountType");
            DropForeignKey("dbo.LedgerAccountType", "ParentId", "dbo.LedgerAccountType");
            DropForeignKey("dbo.LedgerAccount", "ParentId", "dbo.LedgerAccount");
            DropForeignKey("dbo.DonationTransaction", "DonationRequestId", "dbo.DonationRequest");
            DropForeignKey("dbo.UserPersonalInfo", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.UserPersonalInfo", "CityId", "dbo.City");
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropForeignKey("dbo.State", "CountryId", "dbo.Country");
            DropIndex("dbo.ProductCategory", new[] { "ParentId" });
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            DropIndex("dbo.UserPersonalInfo", new[] { "UserId" });
            DropIndex("dbo.UserContactInfo", new[] { "UserId" });
            DropIndex("dbo.UserContactInfo", new[] { "ContactTypeId" });
            DropIndex("dbo.UserBankInfo", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "ParentId" });
            DropIndex("dbo.RewardUser", new[] { "UserId" });
            DropIndex("dbo.RewardUser", new[] { "RewardId" });
            DropIndex("dbo.Reward", new[] { "RewardTypeId" });
            DropIndex("dbo.MenuPermission", new[] { "UserId" });
            DropIndex("dbo.MenuPermission", new[] { "RoleId" });
            DropIndex("dbo.RoleUser", new[] { "UserId" });
            DropIndex("dbo.RoleUser", new[] { "RoleId" });
            DropIndex("dbo.MenuPermission", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropIndex("dbo.User", new[] { "MemberShipLevelId" });
            DropIndex("dbo.User", new[] { "LegId" });
            DropIndex("dbo.Invoice", new[] { "ClientId" });
            DropIndex("dbo.Invoice", new[] { "Status" });
            DropIndex("dbo.InvoiceTransaction", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceItem", new[] { "InvoiceId" });
            DropIndex("dbo.ePinRequest", new[] { "FromUserId" });
            DropIndex("dbo.ePinCode", new[] { "ePinRequestId" });
            DropIndex("dbo.DonationRequest", new[] { "UserId" });
            DropIndex("dbo.DonationTransaction", new[] { "TransactionId" });
            DropIndex("dbo.Transaction", new[] { "DebitLedgerAccountId" });
            DropIndex("dbo.Transaction", new[] { "CreditLedgerAccountId" });
            DropIndex("dbo.LedgerAccount", new[] { "UserId" });
            DropIndex("dbo.LedgerAccount", new[] { "LedgerAccountTypeId" });
            DropIndex("dbo.LedgerAccountType", new[] { "ParentId" });
            DropIndex("dbo.LedgerAccount", new[] { "ParentId" });
            DropIndex("dbo.DonationTransaction", new[] { "DonationRequestId" });
            DropIndex("dbo.UserPersonalInfo", new[] { "GenderId" });
            DropIndex("dbo.UserPersonalInfo", new[] { "CityId" });
            DropIndex("dbo.City", new[] { "StateId" });
            DropIndex("dbo.State", new[] { "CountryId" });
            DropTable("dbo.Product");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.PaymentModeType");
            DropTable("dbo.ContactType");
            DropTable("dbo.UserContactInfo");
            DropTable("dbo.UserBankInfo");
            DropTable("dbo.RewardType");
            DropTable("dbo.Reward");
            DropTable("dbo.RewardUser");
            DropTable("dbo.RoleUser");
            DropTable("dbo.Role");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuPermission");
            DropTable("dbo.MemberShipLevel");
            DropTable("dbo.Leg");
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.InvoiceTransaction");
            DropTable("dbo.InvoiceItem");
            DropTable("dbo.Invoice");
            DropTable("dbo.ePinCode");
            DropTable("dbo.ePinRequest");
            DropTable("dbo.LedgerAccountType");
            DropTable("dbo.LedgerAccount");
            DropTable("dbo.Transaction");
            DropTable("dbo.DonationTransaction");
            DropTable("dbo.DonationRequest");
            DropTable("dbo.User");
            DropTable("dbo.Gender");
            DropTable("dbo.UserPersonalInfo");
            DropTable("dbo.Country");
            DropTable("dbo.State");
            DropTable("dbo.City");
        }
    }
}
