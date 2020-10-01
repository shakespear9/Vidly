namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d892731-f89b-4256-bbae-0683671420af', N'admin@vidly.com', 0, N'AE8AsRnoVJr6mlFAXW2ujrLsS9pwP+A4Qv35i/ew4CkZ/OUMqleWMJYPDytp/V1f6g==', N'f897883d-64ec-4b83-b8fa-56202a814853', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d892731-f89b-4256-bbae-0683671420af', N'admin@vidly.com', 0, N'AE8AsRnoVJr6mlFAXW2ujrLsS9pwP+A4Qv35i/ew4CkZ/OUMqleWMJYPDytp/V1f6g==', N'f897883d-64ec-4b83-b8fa-56202a814853', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9910606a-0b9b-46b8-9616-328630808401', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d892731-f89b-4256-bbae-0683671420af', N'9910606a-0b9b-46b8-9616-328630808401')
                    
"


        );
        }
        
        public override void Down()
        {
        }
    }
}
