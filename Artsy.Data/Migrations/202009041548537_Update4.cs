namespace Artsy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "CreatedUTC", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "PiecePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Transaction", "Id", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "Id");
            DropColumn("dbo.Transaction", "PiecePrice");
            DropColumn("dbo.Transaction", "CreatedUTC");
        }
    }
}
