namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set Name = 'Pay as You Go' Where Id = 1");
            Sql("UPDATE MembershipTypes set Name = 'Monthly' Where Id = 2");
            Sql("UPDATE MembershipTypes set Name = 'Quaterly' Where Id = 3");
            Sql("UPDATE MembershipTypes set Name = 'Annual' Where Id = 4");

        }
        
        public override void Down()
        {
        }
    }
}
