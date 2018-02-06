using MongoDB.Bson;

namespace web.domain.Models
{
    public class User : DocumentBase<ObjectId>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }
    }
}