using System.Data.Entity;

namespace TicTacToe.Models
{
    public class Context :DbContext
    {
        public Context() :base("name=Context")
        {
            
        }

        public DbSet<GameModels> GameModelses { get; set; }
        public DbSet<GameStoryModels> GameStoryModelses { get; set; }
    }
}