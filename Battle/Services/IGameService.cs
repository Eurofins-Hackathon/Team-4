using BattleshipGame.Models;

namespace BattleshipGame.Services
{
    public interface IGameService
    {
        bool PlaceShip(Board board, int x, int y);
        bool Attack(Board board, int x, int y);
        (int, int) GetRandomAttack();
        bool IsGameOver(Board board);
    }
}
