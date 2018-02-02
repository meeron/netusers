namespace web.domain.Models
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Email);
        }
    }
}