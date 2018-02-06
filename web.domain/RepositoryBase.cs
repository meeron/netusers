using MongoDB.Driver;
using web.domain.Collections;

namespace web.domain
{
    public abstract class RepositoryBase<TDocument, TId> : IRepository<TDocument, TId>
        where TDocument : DocumentBase<TId>
    {
        protected readonly IMongoCollection<TDocument> _collection;

        protected RepositoryBase(ICollectionFactory collectionFactory)
        {
            _collection = collectionFactory.Get<TDocument>();
        }

        public virtual void Delete(TId id)
        {
            _collection.DeleteOne(d => d.Id.Equals(id));
        }

        public virtual TDocument Get(TId id)
        {
            return _collection.Find(d => d.Id.Equals(id)).FirstOrDefault();
        }

        public virtual void Insert(TDocument document)
        {
            _collection.InsertOne(document);
        }
    }
}