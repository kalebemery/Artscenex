namespace Artsy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artist", "ArtistType", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artist", "ArtistType", c => c.Int(nullable: false));
        }
    }
}
