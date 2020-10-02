namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminAndUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54a04413-9888-4221-8c1d-0aa8739dceb4', N'user@vidly.com', 0, N'AF3R7fN44WWOoXp4QoZG2itgdNuCpr8YDop9aFKSGEU/+ckVzuenoymmWqJ/hDpRmQ==', N'a9eb6b1f-e166-4af9-9b44-83914d2bb264', NULL, 0, 0, NULL, 1, 0, N'user@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'723c0d41-3e28-4cf9-bfc7-dba497c6f876', N'admin@vidly.com', 0, N'AGDWk/pq9wqfSVuowxa1ic3NNCSAUefkrLdnbbbPS9Rc6FBKLrB/i0haBzkDoF5Jrw==', N'f6a9787a-d212-483d-944d-e8eee6090b76', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ffa0e019-28aa-48ad-ac4d-274c7c56542b', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'723c0d41-3e28-4cf9-bfc7-dba497c6f876', N'ffa0e019-28aa-48ad-ac4d-274c7c56542b')


");
        }
        
        public override void Down()
        {
        }
    }
}
