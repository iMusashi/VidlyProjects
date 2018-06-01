namespace Vidly.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0a956e5f-10cb-4287-8728-7aaabc9d08da', N'admin@vidly.com', 0, N'AMjdtsoDBcusLmHwpcFHHcylkCIXtHdkI38G32MjI9NZCf/m0+rVTqAoS35e5XLNNw==', N'91a62c1f-35b4-4033-bc4e-54d52b3cdeef', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a95443ba-6076-4849-aec7-c3279be58be6', N'keshav@vidly.com', 0, N'AKAT95g2A3HKRJkUOmkWBheiP2ieQsTa2B7pJHadpA5GEhA2twcTxconKvn3xPt40w==', N'78f0ed19-77a7-47c5-b840-8dd1db70dbf9', NULL, 0, 0, NULL, 1, 0, N'keshav@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e671c1f8-5331-4dee-9968-ba1ffcd9f55f', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0a956e5f-10cb-4287-8728-7aaabc9d08da', N'e671c1f8-5331-4dee-9968-ba1ffcd9f55f')

");
        }
        
        public override void Down()
        {
        }
    }
}
