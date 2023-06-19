using DegreeProject.DB.Models.Users;

namespace DegreeProject.DB.Models.Projects
{
    internal class ProjectOwner
    {
        public int Id { get; set; }
        public IEnumerable<UserBase> Participants { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
