

namespace DegreeProject.DB.Models.Projects
{
    internal class Diagram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Work> Works { get; set; }
        public Project Project { get; set; }
    }
}
