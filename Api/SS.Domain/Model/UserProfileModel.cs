
using Microsoft.AspNetCore.Http;

namespace SS.Domain.Model
{
    public class UserProfileModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public IFormFile File { get; set; }
        public string? Notes { get; set; }


    }
}
