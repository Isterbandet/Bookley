namespace Bookley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetErrors : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Books", "Id");
        }
    }
}
