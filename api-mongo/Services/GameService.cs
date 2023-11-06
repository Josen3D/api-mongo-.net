using api_mongo.Models;
using MongoDB.Driver;

namespace api_mongo.Services
{
    public class GameService
    {
        // create Game collection object
        private IMongoCollection<Game> _games;

        // inject mongo settings in constructor
        public GameService(IMongoSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);
            _games = database.GetCollection<Game>(settings.Collection);
        }

        public List<Game> Get()
        {
            return _games.Find(g => true).ToList();
        }

        public Game Get(string id)
        {
            return _games.Find(g => g.Id == id).FirstOrDefault();
        }

        public Game Create(Game game)
        {
            _games.InsertOne(game);

            return game;
        }

        public void Update(string id, Game game)
        {
            _games.ReplaceOne(g => g.Id == id, game);
        }

        public void Delete(string id)
        {
            _games.DeleteOne(g => g.Id == id);
        }

    }
}
