using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace DAL.Interface
{
    public interface IUser
    {
        Task<List<Users>> GetAll();
        Task<bool> Add(Users user);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, Users user);
    }
}
