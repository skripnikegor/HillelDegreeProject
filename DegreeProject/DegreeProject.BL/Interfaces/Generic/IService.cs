
namespace DegreeProject.BL.Interfaces.Generic
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
        Task<bool> Exist(int id);
    }
}
