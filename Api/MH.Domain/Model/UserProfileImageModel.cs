using Microsoft.AspNetCore.Http;

namespace MH.Domain.Model
{
    public class UserProfileImageModel
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
