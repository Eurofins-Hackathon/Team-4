using BattleshipGame.Services;
using Xunit;

namespace BattleshipGame.Tests;

public class GameServiceTests
{
    [Fact]
    public void StartGame_ShouldInitializeGameState()
    {
        // Arrange
        var gameService = new GameService();

        // Act
        gameService.StartGame();

        // Assert
        Assert.NotNull(gameService.GameState);
    }
}