namespace MH.Domain.Model
{
    public class RegisterModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PictureUrl { get; set; }
        public string? Provider { get; set; }
        public string Password { get; set; }
    }
}
