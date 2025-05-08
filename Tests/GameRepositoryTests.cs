using BattleshipGame.Models;
using BattleshipGame.Repositories;
using Xunit;

namespace BattleshipGame.Tests;

public class GameRepositoryTests
{
    [Fact]
    public void SaveGameState_ShouldStoreGameState()
    {
        // Arrange
        var repository = new GameRepository();
        var gameState = new GameState();

        // Act
        repository.SaveGameState(gameState);

        // Assert
        Assert.Equal(gameState, repository.LoadGameState());
    }

    [Fact]
    public void LoadGameState_WithoutSaving_ShouldThrowException()
    {
        // Arrange
        var repository = new GameRepository();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => repository.LoadGameState());
    }
}