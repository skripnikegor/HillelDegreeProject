
using Microsoft.Identity.Client;

namespace DegreeProject.DB.Models.Projects
{
    internal class Work : Material
    {
        public double Duration { get; set; }    
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
