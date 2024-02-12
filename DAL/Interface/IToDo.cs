using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace DAL.Interface
{
    public interface IToDo
    {
        Task<List<ToDo>> GetAll();
        Task<bool> Add(ToDo toDo);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, ToDo toDo);
    }
}
