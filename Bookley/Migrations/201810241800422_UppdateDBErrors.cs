namespace Bookley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UppdateDBErrors : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "Name");
            DropColumn("dbo.Customers", "Birthdate");

        }
        
        public override void Down()
        {

        }
    }
}
