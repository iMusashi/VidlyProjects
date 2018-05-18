namespace Vidly.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres( Name) Values( 'Comedy')");
            Sql("Insert into Genres( Name) Values( 'Action')");
            Sql("Insert into Genres( Name) Values( 'Family')");
            Sql("Insert into Genres( Name) Values( 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
