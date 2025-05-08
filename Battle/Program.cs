
using Microsoft.Extensions.Hosting;
using BattleshipGame.Controllers;
using BattleshipGame.Services;
using Microsoft.Extensions.DependencyInjection;
using BattleshipGame.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Register services
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<IGameRepository, GameRepository>();
        services.AddSingleton<GameController>();
    })
    .Build();

// Resolve the GameController and start the game
var gameController = host.Services.GetRequiredService<GameController>();
gameController.StartGame();
