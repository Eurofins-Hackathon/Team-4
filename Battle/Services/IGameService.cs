using BattleshipGame.Models;

/// <summary>
/// Interface defining the game logic for the Battleship game.
/// </summary>
namespace BattleshipGame.Services
{
    public interface IGameService
    {
        /// <summary>
        /// Places a ship on the specified board at the given coordinates.
        /// </summary>
        /// <param name="board">The game board where the ship will be placed.</param>
        /// <param name="x">The x-coordinate for the ship placement.</param>
        /// <param name="y">The y-coordinate for the ship placement.</param>
        /// <returns>True if the ship was successfully placed; otherwise, false.</returns>
        bool PlaceShip(Board board, int x, int y);

        /// <summary>
        /// Attacks a specific coordinate on the given board.
        /// </summary>
        /// <param name="board">The game board to attack.</param>
        /// <param name="x">The x-coordinate of the attack.</param>
        /// <param name="y">The y-coordinate of the attack.</param>
        /// <returns>True if the attack was a hit; otherwise, false.</returns>
        bool Attack(Board board, int x, int y);

        /// <summary>
        /// Generates a random attack coordinate.
        /// </summary>
        /// <returns>A tuple containing the x and y coordinates of the random attack.</returns>
        (int, int) GetRandomAttack();

        /// <summary>
        /// Checks if the game is over by determining if all ships on the board are destroyed.
        /// </summary>
        /// <param name="board">The game board to check.</param>
        /// <returns>True if the game is over; otherwise, false.</returns>
        bool IsGameOver(Board board);
    }
}
