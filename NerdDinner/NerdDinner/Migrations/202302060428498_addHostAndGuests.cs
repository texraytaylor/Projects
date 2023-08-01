namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHostAndGuests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dinners", "Host", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dinners", "Host");
        }
    }
}
