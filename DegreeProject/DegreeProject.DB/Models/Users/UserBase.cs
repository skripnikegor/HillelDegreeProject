using DegreeProject.DB.Models.Roles;

namespace DegreeProject.DB.Models.Users
{
    internal class UserBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role UserRole { get; set; } 
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
