namespace TicTacToe.Models
{
    public class GameStoryModels
    {
        public int Id { get; set; }
        public GameModels GameId { get; set; }
        public int? GamesId { get; set; }
        public int Story { get; set; } 
    }
}