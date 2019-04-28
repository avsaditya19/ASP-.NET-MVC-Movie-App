using System.Data.Entity.Migrations;

namespace IMDB.Migrations
{
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "tmdb_id", c => c.Int());
            AddColumn("dbo.Producers", "tmdb_id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producers", "tmdb_id");
            DropColumn("dbo.Actors", "tmdb_id");
        }
    }
}
