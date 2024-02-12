using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace DAL.Data
{
    public class UsersData:IUser
    {
        private readonly ProjectContext _projectContext;

        public UsersData(ProjectContext projectContext)
        {
                _projectContext = projectContext;
        }
        public async Task<List<Users>> GetAll()
        {
            List<Users> users = await _projectContext.Users.ToListAsync();
            return users;
        }
        public async Task <bool> Add(Users user)
        {
            await _projectContext.Users.AddAsync(user);
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
        }
        public async Task<bool> Update(int id,Users user)
        {
            var idUser = _projectContext.Users.FirstOrDefault(x => x.Id == id);
            if (idUser == null)
            {
                return false;
            }
            idUser.Name=user.Name;
            idUser.Email=user.Email;
            idUser.Address=user.Address;
            idUser.Phone=user.Phone;

            var ifOk=_projectContext.SaveChanges() > 0; 
            return ifOk;

        }

        public async Task<bool> Delete(int id)
        {
            var idUser = _projectContext.Users.FirstOrDefault(x => x.Id == id);
            if (idUser == null)
            {
                return false;
            }
            _projectContext.Users.Remove(idUser);
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
        }
    }
}
