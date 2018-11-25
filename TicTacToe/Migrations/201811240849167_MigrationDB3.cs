namespace TicTacToe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameModels", "Winner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameModels", "Winner");
        }
    }
}
