using System.ComponentModel;

namespace DegreeProject.DTO.Users
{
    public class UserProfileDTO
    {
        public string Email { get; set; }
        private PasswordPropertyTextAttribute Password { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
    }
}