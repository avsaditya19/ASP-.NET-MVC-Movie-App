namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seventh : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "producer_ID" });
            DropIndex("dbo.MovieActors", new[] { "Movie_ID" });
            DropIndex("dbo.MovieActors", new[] { "Actor_ID" });
            AddColumn("dbo.Actors", "TmdbId", c => c.Int());
            AddColumn("dbo.Movies", "TmdbId", c => c.Int());
            AddColumn("dbo.Producers", "TmdbId", c => c.Int());
            CreateIndex("dbo.Movies", "Producer_Id");
            CreateIndex("dbo.MovieActors", "Movie_Id");
            CreateIndex("dbo.MovieActors", "Actor_Id");
            DropColumn("dbo.Actors", "tmdb_id");
            DropColumn("dbo.Movies", "tmdb_id");
            DropColumn("dbo.Producers", "tmdb_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producers", "tmdb_id", c => c.Int());
            AddColumn("dbo.Movies", "tmdb_id", c => c.Int());
            AddColumn("dbo.Actors", "tmdb_id", c => c.Int());
            DropIndex("dbo.MovieActors", new[] { "Actor_Id" });
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "Producer_Id" });
            DropColumn("dbo.Producers", "TmdbId");
            DropColumn("dbo.Movies", "TmdbId");
            DropColumn("dbo.Actors", "TmdbId");
            CreateIndex("dbo.MovieActors", "Actor_ID");
            CreateIndex("dbo.MovieActors", "Movie_ID");
            CreateIndex("dbo.Movies", "producer_ID");
        }
    }
}
