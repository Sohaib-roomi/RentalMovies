namespace RentalMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMovieAttribute_and_addGenreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "ImageURL", c => c.String());
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            CreateIndex("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Movies", "ImageURL");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "DateAdded");
            DropTable("dbo.Genres");
        }
    }
}
