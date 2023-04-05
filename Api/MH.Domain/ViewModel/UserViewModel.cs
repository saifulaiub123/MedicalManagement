
namespace MH.Domain.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PositionName { get; set; }
        public string PositionDesc { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
