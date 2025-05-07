namespace BattleshipGame.Models
{
    public class Board
    {
        public char[,] Grid { get; set; } = new char[5, 5];

        public Board()
        {
            InitializeBoard();
        }

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
