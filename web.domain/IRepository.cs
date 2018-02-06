namespace web.domain
{
    public interface IRepository<TDocument, TId>
        where TDocument: DocumentBase<TId>
    {
         TDocument Get(TId id);

         void Insert(TDocument document);

         void Delete(TId id);
    }
}