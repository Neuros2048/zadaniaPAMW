namespace Biblioteka.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public Rols Role { get; set; } = Rols.USER;

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
