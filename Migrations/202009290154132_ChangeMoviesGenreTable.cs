namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMoviesGenreTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "GenreId_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId_Id", newName: "IX_GenreId");
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_GenreId_Id");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "GenreId_Id");
        }
    }
}
