
using BattleshipGame.Controllers;
using BattleshipGame.Services;

var gameService = new GameService();
var gameController = new GameController(gameService);
gameController.StartGame();
