using MongoDB.Driver;

namespace web.domain.Collections
{
    public interface ICollectionFactory
    {
         IMongoCollection<TDocument> Get<TDocument>(string name = null);
    }
}