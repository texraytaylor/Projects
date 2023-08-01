namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDinnerValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dinners", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Dinners", "Phone", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dinners", "Phone", c => c.String());
            AlterColumn("dbo.Dinners", "Description", c => c.String());
        }
    }
}
