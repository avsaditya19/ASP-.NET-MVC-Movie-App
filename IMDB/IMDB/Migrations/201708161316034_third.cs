using System.Data.Entity.Migrations;

namespace IMDB.Migrations
{
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "tmdb_id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "tmdb_id");
        }
    }
}
