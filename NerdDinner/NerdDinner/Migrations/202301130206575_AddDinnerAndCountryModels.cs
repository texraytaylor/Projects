namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDinnerAndCountryModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dinners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        EventDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Address = c.String(),
                        CountryId = c.Int(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dinners", "CountryId", "dbo.Countries");
            DropIndex("dbo.Dinners", new[] { "CountryId" });
            DropTable("dbo.Dinners");
            DropTable("dbo.Countries");
        }
    }
}
