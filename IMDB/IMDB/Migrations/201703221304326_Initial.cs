using System.Data.Entity.Migrations;

namespace IMDB.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sex = c.String(),
                        Dob = c.String(),
                        Bio = c.String()
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Plot = c.String(),
                        Image = c.String(),
                        producer_ID = c.Int()
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Producers", t => t.producer_ID)
                .Index(t => t.producer_ID);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sex = c.String(),
                        Dob = c.String(),
                        Bio = c.String()
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_ID = c.Int(nullable: false),
                        Actor_ID = c.Int(nullable: false)
                    })
                .PrimaryKey(t => new { t.Movie_ID, t.Actor_ID })
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_ID, cascadeDelete: true)
                .Index(t => t.Movie_ID)
                .Index(t => t.Actor_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "producer_ID", "dbo.Producers");
            DropForeignKey("dbo.MovieActors", "Actor_ID", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.MovieActors", new[] { "Actor_ID" });
            DropIndex("dbo.MovieActors", new[] { "Movie_ID" });
            DropIndex("dbo.Movies", new[] { "producer_ID" });
            DropTable("dbo.MovieActors");
            DropTable("dbo.Producers");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
