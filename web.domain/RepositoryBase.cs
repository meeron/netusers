namespace web.domain
{
  public abstract class RepositoryBase<TDocument, TId> : IRepository<TDocument, TId>
      where TDocument : DocumentBase<TId>
  {
    public void Delete(TId id)
    {
      throw new System.NotImplementedException();
    }

    public TDocument Get(TId id)
    {
      throw new System.NotImplementedException();
    }

    public TDocument Insert(TDocument document)
    {
      throw new System.NotImplementedException();
    }
  }
}