using MH.Domain.Model;

namespace MH.Domain.DBModel
{
    public class UserProfileImage : BaseModel<int>
    {
        public int UserProfileId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; } 
        public byte[] Data { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser UpdateByUser { get; set; }
    }
}
