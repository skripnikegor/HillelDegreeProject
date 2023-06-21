using DegreeProject.DTO.Projects;

namespace DegreeProject.DB.Interfaces.Repository
{
    internal interface ICaculable
    {
         double Duration(WorkDTO work);
    }
}
