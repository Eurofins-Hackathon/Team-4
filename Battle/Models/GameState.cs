namespace BattleshipGame.Models
{
    public class GameState
    {
        public Board PlayerBoard { get; set; } = new Board();
        public Board ComputerBoard { get; set; } = new Board();
        public bool IsPlayerTurn { get; set; } = true;
    }
}
