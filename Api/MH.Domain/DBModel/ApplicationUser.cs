using Microsoft.AspNetCore.Identity;
using System.Security;

namespace MH.Domain.DBModel
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int Status { get; set; }
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }


        public virtual Permission CreatedByPermission { get; set; }
        public virtual Permission? UpdatedByPermission { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual UserProfile CreatedByUserProfile { get; set; }
        public virtual UserProfile? UpdatedByUserProfile { get; set; }
        
        public virtual UserProfileImage CreatedByUserProfileImage { get; set; }
        public virtual UserProfileImage? UpdatedByUserProfileImage { get; set; }
    }
}
