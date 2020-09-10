namespace Artsy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Piece", "Id", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Piece", "Id");
        }
    }
}
