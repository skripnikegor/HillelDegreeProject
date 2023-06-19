

namespace DegreeProject.DB.Models.Projects
{
    internal class Material
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public string ElementCode { get; set; }
        public int WorkCode { get; set; }
        public string StandartCode { get; set; }
        public string Unit { get; set; }
    }
}
