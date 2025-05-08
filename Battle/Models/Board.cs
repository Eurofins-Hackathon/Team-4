namespace BattleshipGame.Models
{
    /// <summary>
    /// Represents the game board for the Battleship game.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// A 2D grid representing the board. '~' represents water, and 'S' represents a ship.
        /// </summary>
        public char[,] Grid { get; set; } = new char[5, 5];

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class and sets up the board.
        /// </summary>
        public Board()
        {
            InitializeBoard();
        }

        /// <summary>
        /// Initializes the board by filling it with water ('~').
        /// </summary>
        private void InitializeBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Grid[i, j] = '~'; // '~' represents water
                }
            }
        }

        /// <summary>
        /// Displays the board in the console.
        /// </summary>
        /// <param name="hideShips">If true, hides the ships ('S') on the board by displaying water ('~') instead.</param>
        public void Display(bool hideShips = false)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (hideShips && Grid[i, j] == 'S')
                        Console.Write("~ ");
                    else
                        Console.Write(Grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
