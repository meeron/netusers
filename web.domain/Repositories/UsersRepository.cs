using MongoDB.Bson;
using web.domain.Collections;
using web.domain.Models;

namespace web.domain.Repositories
{
    public class UsersRepository : RepositoryBase<User, ObjectId>, IUsersRepository
    {
        public UsersRepository(ICollectionFactory collectionFactory)
            : base(collectionFactory)
        {            
        }        
    }
}