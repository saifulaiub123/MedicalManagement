using SS.Domain.Model;

namespace SS.Domain.DBModel
{
    public class UserProfile : BaseModel<int>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public byte[]? Photo { get; set; }
        public string? Notes { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
