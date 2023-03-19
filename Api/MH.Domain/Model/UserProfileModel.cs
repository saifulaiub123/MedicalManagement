
namespace MH.Domain.Model
{
    public class UserProfileModel
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string ZipCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int LanguageId { get; set; }


    }
}
