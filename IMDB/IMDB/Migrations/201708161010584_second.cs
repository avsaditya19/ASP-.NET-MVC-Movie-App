using System.Data.Entity.Migrations;

namespace IMDB.Migrations
{
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producers", "Name", c => c.String());
        }
    }
}
