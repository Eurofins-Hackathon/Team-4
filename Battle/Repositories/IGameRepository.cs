using BattleshipGame.Models;

namespace BattleshipGame.Repositories;

public interface IGameRepository
{
    void SaveGameState(GameState gameState);
    GameState LoadGameState();
}