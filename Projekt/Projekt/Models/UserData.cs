using Projekt.Validation;

namespace Projekt.Models
{
    public class UserData
    {
        [UserNameValidation]
        public string Name { get; set; }
        [UserLastNameValidation]
        public string LastName { get; set; }
        [UserEmailValidation]
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HomeFlatNumber { get; set; }

        public string ZipCode { get; set; }
        public string TelNumber { get; set; }
    }
}