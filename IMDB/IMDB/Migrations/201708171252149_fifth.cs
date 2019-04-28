using System.Data.Entity.Migrations;

namespace IMDB.Migrations
{
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Actors", "Sex", c => c.String(maxLength: 1));
            AlterColumn("dbo.Actors", "Dob", c => c.String(maxLength: 20));
            AlterColumn("dbo.Actors", "Bio", c => c.String(maxLength: 1500));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Movies", "Plot", c => c.String(maxLength: 1500));
            AlterColumn("dbo.Producers", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Producers", "Sex", c => c.String(maxLength: 1));
            AlterColumn("dbo.Producers", "Dob", c => c.String(maxLength: 20));
            AlterColumn("dbo.Producers", "Bio", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producers", "Bio", c => c.String());
            AlterColumn("dbo.Producers", "Dob", c => c.String());
            AlterColumn("dbo.Producers", "Sex", c => c.String());
            AlterColumn("dbo.Producers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Plot", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.Actors", "Bio", c => c.String());
            AlterColumn("dbo.Actors", "Dob", c => c.String());
            AlterColumn("dbo.Actors", "Sex", c => c.String());
            AlterColumn("dbo.Actors", "Name", c => c.String());
        }
    }
}
