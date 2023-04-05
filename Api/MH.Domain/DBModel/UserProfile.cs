using MH.Domain.Model;

namespace MH.Domain.DBModel
{
    public class UserProfile : BaseModel<int>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public int? CountryId { get; set; }
        public string? Email { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string? ZipCode { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public int? LanguageId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual UserProfileImage? UserProfileImage { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser UpdateByUser { get; set; }

    }
}
