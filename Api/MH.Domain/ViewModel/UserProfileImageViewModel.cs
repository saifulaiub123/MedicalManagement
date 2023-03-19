
namespace MH.Domain.ViewModel
{
    public class UserProfileImageViewModel
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }

    }
}
