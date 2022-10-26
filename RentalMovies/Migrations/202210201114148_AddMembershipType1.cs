namespace RentalMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        Discount = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipTypes");
        }
    }
}
