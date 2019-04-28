using System.Data.Entity.Migrations;

namespace IMDB.Migrations
{
    public partial class Sixth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "Bio", c => c.String());
            AlterColumn("dbo.Movies", "Plot", c => c.String());
            AlterColumn("dbo.Producers", "Bio", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producers", "Bio", c => c.String(maxLength: 1500));
            AlterColumn("dbo.Movies", "Plot", c => c.String(maxLength: 1500));
            AlterColumn("dbo.Actors", "Bio", c => c.String(maxLength: 1500));
        }
    }
}
