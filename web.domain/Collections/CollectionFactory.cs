using MongoDB.Driver;
using web.core.Configuration;

namespace web.domain.Collections
{
    public class CollectionFactory : ICollectionFactory
    {
        private readonly IMongoClient _client;

        private readonly IMongoDatabase _database;

        public CollectionFactory(IConnectionStrings connectionStrings)
        {
            var mongoUrl = new MongoUrl(connectionStrings.MongoDb);

            _client = new MongoClient(mongoUrl);
            _database = _client.GetDatabase(mongoUrl.DatabaseName);           
        }

        public IMongoCollection<TDocument> Get<TDocument>(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                name = typeof(TDocument).Name.ToLower();

            return _database.GetCollection<TDocument>(name);
        }
    }
}