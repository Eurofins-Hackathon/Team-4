using BattleshipGame.Models;
using BattleshipGame.Services;

namespace BattleshipGame.Controllers
{
    /// <summary>
    /// The GameController class manages the flow of the Battleship game, including player and computer turns, ship placement, and game state updates.
    /// </summary>
    public class GameController
    {
        /// <summary>
        /// Service for handling game logic such as ship placement and attacks.
        /// </summary>
        private readonly IGameService _gameService;

        /// <summary>
        /// Represents the current state of the game, including player and computer boards.
        /// </summary>
        private readonly GameState _gameState;

        /// <summary>
        /// Initializes a new instance of the GameController class.
        /// </summary>
        /// <param name="gameService">The game service to handle game logic.</param>
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
            _gameState = new GameState();
        }

        /// <summary>
        /// Starts the Battleship game, managing the game loop and player interactions.
        /// </summary>
        public void StartGame()
        {
            Console.WriteLine("Welcome to Battleship!");

            // Place ships
            Console.WriteLine("Place your ships on the board:");
            for (int i = 0; i < 2; i++) // Example: Allow the player to place 3 ships
            {
                Console.WriteLine($"Placing ship {i + 1}:");
                int x = GetCoordinate("X");
                int y = GetCoordinate("Y");
                _gameService.PlaceShip(_gameState.PlayerBoard, x, y);
            }

            Console.WriteLine("Randomly placing ships for the computer...");
            Random random = new Random();
            for (int i = 0; i < 2; i++) // Example: Place 3 ships for the computer
            {
                int x, y;
                do
                {
                    x = random.Next(0, 5); // Assuming a 5x5 board
                    y = random.Next(0, 5);
                } while (!_gameService.PlaceShip(_gameState.ComputerBoard, x, y));
            }

            while (true)
            {
                Console.WriteLine("Your Board:");
                _gameState.PlayerBoard.Display();

                Console.WriteLine("\nComputer's Board:");
                _gameState.ComputerBoard.Display(hideShips: true);

                if (_gameState.IsPlayerTurn)
                {
                    Console.WriteLine("\nYour turn! Enter coordinates to attack:");
                    int x = GetCoordinate("X");
                    int y = GetCoordinate("Y");

                    if (_gameService.Attack(_gameState.ComputerBoard, x, y))
                        Console.WriteLine("Hit!");
                    else
                        Console.WriteLine("Miss!");

                    if (_gameService.IsGameOver(_gameState.ComputerBoard))
                    {
                        Console.WriteLine("You win!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nComputer's turn...");
                    var (x, y) = _gameService.GetRandomAttack();

                    if (_gameService.Attack(_gameState.PlayerBoard, x, y))
                        Console.WriteLine($"Computer hit at ({x}, {y})!");
                    else
                        Console.WriteLine($"Computer missed at ({x}, {y})!");

                    if (_gameService.IsGameOver(_gameState.PlayerBoard))
                    {
                        Console.WriteLine("Computer wins!");
                        break;
                    }
                }

                _gameState.IsPlayerTurn = !_gameState.IsPlayerTurn;
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Prompts the user to enter a coordinate for a given axis.
        /// </summary>
        /// <param name="axis">The axis for which the coordinate is being requested (e.g., "X" or "Y").</param>
        /// <returns>The coordinate entered by the user.</returns>
        private int GetCoordinate(string axis)
        {
            Console.Write($"Enter {axis} coordinate (0-4): ");
            return int.Parse(Console.ReadLine() ?? "0");
        }
    }
}
