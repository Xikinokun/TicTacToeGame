namespace TicTacToe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameStoryModels", "GamesId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameStoryModels", "GamesId");
        }
    }
}
