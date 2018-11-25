namespace TicTacToe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Winner = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameStoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Story = c.Int(nullable: false),
                        GameId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameModels", t => t.GameId_Id)
                .Index(t => t.GameId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameStoryModels", "GameId_Id", "dbo.GameModels");
            DropIndex("dbo.GameStoryModels", new[] { "GameId_Id" });
            DropTable("dbo.GameStoryModels");
            DropTable("dbo.GameModels");
        }
    }
}
