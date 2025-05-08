using BattleshipGame.Controllers;
using BattleshipGame.Services;
using Moq;
using Xunit;

namespace BattleshipGame.Tests;

public class GameControllerTests
{
    [Fact]
    public void StartGame_ShouldInvokeGameService()
    {
        // Arrange
        var mockGameService = new Mock<IGameService>();
        var gameController = new GameController(mockGameService.Object);

        // Act
        gameController.StartGame();

        // Assert
        mockGameService.Verify(service => service.StartGame(), Times.Once);
    }
}