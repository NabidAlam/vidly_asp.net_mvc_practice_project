namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'11c49c8f-95e0-4ec3-8dd1-4781c43f1b4b', N'guest@vidly.com', 0, N'AIkErhxXPUzR+pwwYekKI1J1S94Z2wLNFZu+0znoqvuTzj53CyMvhoVHNXQarcY88Q==', N'c8c0061a-5acd-444c-aed7-25948fe35f78', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'39bbd31a-7077-4cb2-a61e-0bdcfcaf807c', N'email@addr.ess', 0, N'ACXqEEnaXUcfgZV925bPdDduA5Q3QB45NosZRsgBEQdBLinENgohDJGXImyFKyJ1ug==', N'7fb51e9d-ea5c-4834-a1e6-9b66311b98cf', NULL, 0, 0, NULL, 1, 0, N'email@addr.ess')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'765ee9c6-f595-4096-a2be-074f29343fc2', N'admin@vidly.com', 0, N'AAF24IpNPdqlv1CZ26GCQMqPIRHTTEWKBOw/BUQmCYbqL62AgIkviD7zM4bsP0DsQg==', N'9ac4d98c-9140-46d0-a184-21074aef5953', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3cdf4018-9f1c-4f13-9cb5-2f2731319401', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'765ee9c6-f595-4096-a2be-074f29343fc2', N'3cdf4018-9f1c-4f13-9cb5-2f2731319401')

");
        }
        
        public override void Down()
        {
        }
    }
}
