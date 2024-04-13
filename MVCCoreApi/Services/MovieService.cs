using MVCCoreApiMovie.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace MVCCoreApiMovie.Services
{
    public class MovieService
    {
        
        private readonly IMongoCollection<Movie> _movieCollection;

        public MovieService(IOptions<MovieDBSettings> MovieDBSettings)
        {
            var mongoClient = new MongoClient(
            MovieDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                MovieDBSettings.Value.DatabaseName);

            _movieCollection = mongoDatabase.GetCollection<Movie>(
                MovieDBSettings.Value.DBCollectionName);
        }

        public async Task<List<Movie>> GetAsync() =>
        await _movieCollection.Find(_ => true).ToListAsync();

        public async Task<Movie?> GetAsync(string id) =>
            await _movieCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Movie newMovie) =>
            await _movieCollection.InsertOneAsync(newMovie);

        public async Task UpdateAsync(string id, Movie updatedMovie) =>
            await _movieCollection.ReplaceOneAsync(x => x.Id == id, updatedMovie);

        public async Task RemoveAsync(string id) =>
            await _movieCollection.DeleteOneAsync(x => x.Id == id);

    }
}
