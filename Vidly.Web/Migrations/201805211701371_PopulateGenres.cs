namespace Vidly.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Id, Name) Values(1, 'Comedy')");
            Sql("Insert into Genres(Id, Name) Values(2, 'Action')");
            Sql("Insert into Genres(Id, Name) Values(3, 'Romance')");
            Sql("Insert into Genres(Id, Name) Values(4, 'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
