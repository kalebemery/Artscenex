namespace Artsy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddiMigatio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Piece", "PieceType", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Piece", "PieceType", c => c.Int(nullable: false));
        }
    }
}
