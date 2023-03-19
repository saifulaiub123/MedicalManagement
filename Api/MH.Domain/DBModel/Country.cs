using MH.Domain.Model;

namespace MH.Domain.DBModel
{
    public class Country : BaseModel<int>
    {
        public string ShortName { get; set; }
        public string Name { get; set; }
        public int PhoneCode { get; set; }

        public virtual ICollection<UserProfile> UserProfile { get; set; }

    }
}
