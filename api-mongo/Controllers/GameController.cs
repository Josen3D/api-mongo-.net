using api_mongo.Models;
using api_mongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // inject service
        private GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var games = _gameService.Get();

            return Ok(games);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var game = _gameService.Get(id);

            if (game == null) return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public IActionResult Post(Game game)
        {
            _gameService.Create(game);

            return Ok(game);
        }

        [HttpPut]
        public IActionResult Put(Game game)
        {
            if (game.Id == null) return NotFound();

            _gameService.Update(game.Id, game);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            _gameService.Delete(id);

            return Ok();
        }
    }
}
