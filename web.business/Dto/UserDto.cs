namespace web.business.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }        
    }
}