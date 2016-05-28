namespace ModelDBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InfoDiscriptions", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Payments", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InfoDiscriptions", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
