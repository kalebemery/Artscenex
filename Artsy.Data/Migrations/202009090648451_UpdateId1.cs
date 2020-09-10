namespace Artsy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateId1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Piece", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Piece", "Id", c => c.Guid(nullable: false));
        }
    }
}
