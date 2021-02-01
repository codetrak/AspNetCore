namespace AspNetCore.API.Dto
{
    public class LoginDto
    {
        public int EntityID { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int RoleStatusID { get; set; }
        public string Username { get; set; } = null;

    }
}