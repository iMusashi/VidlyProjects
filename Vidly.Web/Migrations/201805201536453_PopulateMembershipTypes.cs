namespace Vidly.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) Values( 1, 0, 0, 0)");
            Sql("Insert Into MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) Values( 2, 15, 1, 10)");
            Sql("Insert Into MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) Values( 3, 90, 3, 15)");
            Sql("Insert Into MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) Values( 4, 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
