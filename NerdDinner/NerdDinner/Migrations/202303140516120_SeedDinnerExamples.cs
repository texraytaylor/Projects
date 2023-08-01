namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDinnerExamples : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Dinners (Title, EventDate, Description, Address, CountryId, Phone, Host, Guests) VALUES ('Birthday Party', '20230503 10:30 PM', 'Come join us while we have a party for Jane!', '123 Oak Street', '231', '123-456-7890', 'ttaylor', 'jzhang, staylor, testuser55')");
            Sql("INSERT INTO Dinners (Title, EventDate, Description, Address, CountryId, Phone, Host, Guests) VALUES ('Movie Night', '20230410 8:00 PM', 'Let us all get together and watch some movies!', '222 Movie Blvd', '81', '121-232-3434', 'anguyen', 'ttaylor, jzhang')");
            Sql("INSERT INTO Dinners (Title, EventDate, Description, Host, Guests) VALUES ('Online Zoom Meeting', '20230623 11:00 AM', 'Join us online from anywhere in the world!', 'jzhang', 'ttaylor')");
        }
        
        public override void Down()
        {
        }
    }
}
