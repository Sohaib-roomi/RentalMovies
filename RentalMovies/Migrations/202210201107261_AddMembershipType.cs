namespace RentalMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
    }
}
