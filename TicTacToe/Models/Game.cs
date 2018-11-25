using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Models
{
    public class Game
    {
        public List<char> GameBoard { get; set; }

        public Game()
        {
            GameBoard = new List<char> {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
        }

        public char Winner()
        {
            const char result = ' ';
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[i*3] == GameBoard[i*3 + 1] && GameBoard[i*3 + 1] == GameBoard[i*3 + 2] &&
                    GameBoard[i*3] != ' ')
                {
                    return GameBoard[i*3];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[i] == GameBoard[i + 3] && GameBoard[i + 3] == GameBoard[i + 6] && GameBoard[i] != ' ')
                {
                    return GameBoard[i];
                }
            }

            if (GameBoard[0] == GameBoard[4] && GameBoard[4] == GameBoard[8] && GameBoard[0] != ' ')
            {
                return GameBoard[0];
            }

            if (GameBoard[2] == GameBoard[4] && GameBoard[4] == GameBoard[6] && GameBoard[2] != ' ')
            {
                return GameBoard[2];
            }
            return result;
        }

        public bool IsGameOver()
        {
            if (Winner() != ' ' || !GameBoard.Contains(' '))
            {
                return true;
            }
            return false;
        }

        public bool CanPlay(char c, int index)
        {
            var gameList = GameBoard.ToList();

            if (gameList[index] == ' ')
            {
                gameList[index] = c;
            }
            else
            {
                return false;
            }

            var game = new Game {GameBoard = gameList};

            return game.IsGameOver();
        }

        public int ComputerPlay()
        {
            var index = 4;

            for (int i = 0; i < 9; i++)
            {
                if (GameBoard[i] == ' ' && CanPlay('O', i))
                {
                    return i;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (GameBoard[i] == ' ' && CanPlay('X', i))
                {
                    return i;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (GameBoard[(i + 4)%9] == ' ')
                {
                    return (i + 4)%9;
                }
            }

            return index;
        }

        public void Play(Game game, int square)
        {
            if (square == -1) return;
            if (game.GameBoard[square] == ' ')
            {
                game.GameBoard[square] = 'X';
                if (!game.IsGameOver())
                {
                    game.GameBoard[ComputerPlay()] = 'O';
                }
            }

        }
    }
}