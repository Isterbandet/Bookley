namespace Bookley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genres : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Computer')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Science Fiction')");

          
            
                
                
          
        }
    }
}
