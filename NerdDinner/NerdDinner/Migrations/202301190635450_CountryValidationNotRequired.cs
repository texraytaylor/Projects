namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryValidationNotRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dinners", "CountryId", "dbo.Countries");
            DropIndex("dbo.Dinners", new[] { "CountryId" });
            AlterColumn("dbo.Dinners", "CountryId", c => c.Int());
            CreateIndex("dbo.Dinners", "CountryId");
            AddForeignKey("dbo.Dinners", "CountryId", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dinners", "CountryId", "dbo.Countries");
            DropIndex("dbo.Dinners", new[] { "CountryId" });
            AlterColumn("dbo.Dinners", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Dinners", "CountryId");
            AddForeignKey("dbo.Dinners", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
