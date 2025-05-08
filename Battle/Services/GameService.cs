using BattleshipGame.Models;

namespace BattleshipGame.Services
{
    /// <summary>
    /// Service class for managing game logic in the Battleship game.
    /// </summary>
    public class GameService : IGameService
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Places a ship on the board at the specified coordinates.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <returns>True if the ship was successfully placed, false otherwise.</returns>
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

        /// <summary>
        /// Attacks a specific cell on the board.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <returns>True if the attack was a hit, false otherwise.</returns>
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

        /// <summary>
        /// Generates random coordinates for an attack.
        /// </summary>
        /// <returns>A tuple containing the x and y coordinates of the attack.</returns>
        public (int, int) GetRandomAttack()
        {
            return (_random.Next(0, 5), _random.Next(0, 5));
        }

        /// <summary>
        /// Checks if the game is over by verifying if any ships remain on the board.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <returns>True if all ships are destroyed, false otherwise.</returns>
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
