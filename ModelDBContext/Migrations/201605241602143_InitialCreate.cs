namespace ModelDBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbstractPlaces",
                c => new
                    {
                        DatabaseId = c.Long(nullable: false, identity: true),
                        id = c.Guid(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Info_DatabaseId = c.Long(),
                    })
                .PrimaryKey(t => t.DatabaseId)
                .ForeignKey("dbo.InfoDiscriptions", t => t.Info_DatabaseId)
                .Index(t => t.Info_DatabaseId);
            
            CreateTable(
                "dbo.InfoDiscriptions",
                c => new
                    {
                        DatabaseId = c.Long(nullable: false, identity: true),
                        Discription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonSize = c.Int(nullable: false),
                        id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DatabaseId);
            
            CreateTable(
                "dbo.AbstractUsers",
                c => new
                    {
                        DatabaseId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddledName = c.String(),
                        LastName = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        PasswordHash = c.Int(nullable: false),
                        id = c.Guid(nullable: false),
                        Access = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DatabaseId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        DatabaseId = c.Long(nullable: false, identity: true),
                        id = c.Guid(nullable: false),
                        Check_DatabaseId = c.Long(),
                        Client_DatabaseId = c.Long(),
                    })
                .PrimaryKey(t => t.DatabaseId)
                .ForeignKey("dbo.Payments", t => t.Check_DatabaseId)
                .ForeignKey("dbo.AbstractUsers", t => t.Client_DatabaseId)
                .Index(t => t.Check_DatabaseId)
                .Index(t => t.Client_DatabaseId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        DatabaseId = c.Long(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsCompleted = c.Boolean(nullable: false),
                        id = c.Guid(nullable: false),
                        Requisites_DatabaseId = c.Long(),
                    })
                .PrimaryKey(t => t.DatabaseId)
                .ForeignKey("dbo.Requisites", t => t.Requisites_DatabaseId)
                .Index(t => t.Requisites_DatabaseId);
            
            CreateTable(
                "dbo.Requisites",
                c => new
                    {
                        DatabaseId = c.Long(nullable: false, identity: true),
                        OrganizationName = c.String(nullable: false),
                        BeneficiaryBank = c.String(nullable: false),
                        AccountNumber = c.String(nullable: false),
                        Iin = c.String(),
                        BankIdentifierCode = c.String(nullable: false),
                        id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DatabaseId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ReservationPeriod = c.Int(nullable: false),
                        DatabaseId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AbstractPlaces", t => t.DatabaseId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.DatabaseId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.DatabaseId, cascadeDelete: true)
                .Index(t => t.DatabaseId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        DatabaseId = c.Long(nullable: false, identity: true),
                        id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DatabaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "DatabaseId", "dbo.Carts");
            DropForeignKey("dbo.Orders", "Client_DatabaseId", "dbo.AbstractUsers");
            DropForeignKey("dbo.Reservations", "DatabaseId", "dbo.Orders");
            DropForeignKey("dbo.Reservations", "DatabaseId", "dbo.AbstractPlaces");
            DropForeignKey("dbo.Orders", "Check_DatabaseId", "dbo.Payments");
            DropForeignKey("dbo.Payments", "Requisites_DatabaseId", "dbo.Requisites");
            DropForeignKey("dbo.AbstractPlaces", "Info_DatabaseId", "dbo.InfoDiscriptions");
            DropIndex("dbo.Reservations", new[] { "DatabaseId" });
            DropIndex("dbo.Payments", new[] { "Requisites_DatabaseId" });
            DropIndex("dbo.Orders", new[] { "Client_DatabaseId" });
            DropIndex("dbo.Orders", new[] { "Check_DatabaseId" });
            DropIndex("dbo.AbstractPlaces", new[] { "Info_DatabaseId" });
            DropTable("dbo.Carts");
            DropTable("dbo.Reservations");
            DropTable("dbo.Requisites");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.AbstractUsers");
            DropTable("dbo.InfoDiscriptions");
            DropTable("dbo.AbstractPlaces");
        }
    }
}
