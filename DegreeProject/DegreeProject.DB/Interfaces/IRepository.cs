using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces
{
    public interface IRepository <T>
    {
        T GetItemById(int Id);
        void AddItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int Id);
    }
}
