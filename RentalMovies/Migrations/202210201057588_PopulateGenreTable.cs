namespace RentalMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Fiction')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Family')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (5, 'Thriller')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (6, 'Mystery')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (7, 'Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
