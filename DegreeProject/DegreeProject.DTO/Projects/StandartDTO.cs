using System.ComponentModel.DataAnnotations;


namespace DegreeProject.DTO.Projects
{
    public class StandartDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string CodeResourse { get; set; }
        [Required]
        public string NameResourse { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public int UnitAmount { get; set; }
        [Required]
        public decimal LaborCostHour { get; set; }
        [Required]
        public decimal LaborCostMachine { get; set; }
    }
}
