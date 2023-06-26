

using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        [ForeignKey("Estimate")]
        public int? EstimateId { get; set; }
       


    }
}
