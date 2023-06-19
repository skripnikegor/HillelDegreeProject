using System.ComponentModel;


namespace DegreeProject.DTO.Users
{
    public class RegisterUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        private PasswordPropertyTextAttribute Password { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
    }
}
