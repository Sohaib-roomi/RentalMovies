namespace RentalMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        movieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.movieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
