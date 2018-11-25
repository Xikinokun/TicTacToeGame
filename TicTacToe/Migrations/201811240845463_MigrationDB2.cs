namespace TicTacToe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameModels", "Winner", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            
        }
    }
}
