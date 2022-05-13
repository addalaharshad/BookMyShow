namespace BookMyShow_BE.Data_Models
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Mobile { get; set; }
    }
}
