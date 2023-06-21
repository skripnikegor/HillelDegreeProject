
namespace DegreeProject.DB.Models.Projects
{
    internal class Estimate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Material> Material { get; set; }
        public IEnumerable<Work> Work { get; set; }
        public Project Project { get; set; }
    }
}
