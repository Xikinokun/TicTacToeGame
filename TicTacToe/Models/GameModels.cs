using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class GameModels
    {
        public int Id { get; set; }
        public string Winner { get; set; } 
        public virtual ICollection<GameStoryModels> GameStory{ get; set; }

        public GameModels()
        {
            GameStory = new List<GameStoryModels>();
        }
    }
}