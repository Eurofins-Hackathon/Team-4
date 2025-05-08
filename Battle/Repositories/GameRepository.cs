using BattleshipGame.Models;

namespace BattleshipGame.Repositories;

public class GameRepository : IGameRepository
{
    private GameState? _gameState;

    public void SaveGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public GameState LoadGameState()
    {
        if (_gameState == null)
        {
            throw new InvalidOperationException("No game state has been saved.");
        }

        return _gameState;
    }
}