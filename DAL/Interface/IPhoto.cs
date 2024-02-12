using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace DAL.Interface
{
    public interface IPhoto
    {
        Task<List<Photo>> GetAll();
        Task<bool> Add(Photo photo);
        Task<bool> Delete(int id);

        //Task<bool> Update(int id ,Photo photo);
    }
}
