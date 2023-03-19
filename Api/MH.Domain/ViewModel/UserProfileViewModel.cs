
namespace MH.Domain.ViewModel
{
    public class UserProfileViewModel
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public string ProfileImage { get; set; }


        public DateTime DateCreated { get; set; }
    }
}
