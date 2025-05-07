using BattleshipGame.Models;

namespace BattleshipGame.Services
{
    public class GameService : IGameService
    {
        private readonly Random _random = new Random();

        public bool PlaceShip(Board board, int x, int y)
        {
            if (board.Grid[x, y] == '~')
            {
                board.Grid[x, y] = 'S'; // 'S' represents a ship
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool Attack(Board board, int x, int y)
        {
            if (board.Grid[x, y] == 'S')
            {
                board.Grid[x, y] = 'X'; // 'X' represents a hit
                return true;
            }
            else if (board.Grid[x, y] == '~')
            {
                board.Grid[x, y] = 'O'; // 'O' represents a miss
                return false;
            }
            return false;
        }

        public (int, int) GetRandomAttack()
        {
            return (_random.Next(0, 5), _random.Next(0, 5));
        }

        public bool IsGameOver(Board board)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board.Grid[i, j] == 'S')
                        return false;
                }
            }
            return true;
        }
    }
}
