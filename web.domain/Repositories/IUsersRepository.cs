using MongoDB.Bson;
using web.domain.Models;

namespace web.domain.Repositories
{
    public interface IUsersRepository : IRepository<User, ObjectId>
    {       
    }
}