namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyGuests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dinners", "Guests", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dinners", "Guests");
        }
    }
}
