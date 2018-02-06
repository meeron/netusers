using MongoDB.Bson;
using web.domain.Models;

namespace web.domain.Repositories
{
    public class UsersRepository : RepositoryBase<User, ObjectId>, IUsersRepository
    {        
    }
}