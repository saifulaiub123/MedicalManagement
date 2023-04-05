using MH.Domain.Model;

namespace MH.Domain.DBModel
{
    public class UserProfileImage : BaseModel<int>
    {
        public int UserId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; } 
        public byte[] Data { get; set; }
        public bool IsDeleted { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}
