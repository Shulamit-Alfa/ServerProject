using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using DAL.Interface;
namespace DAL.Data
{
    public class PhotoData:IPhoto
    {
        private readonly ProjectContext _projectContext;

        public PhotoData(ProjectContext projectContext)
        {
                _projectContext = projectContext;
        }
        public async Task<List<Photo>> GetAll()
        {
            List<Photo> photos = await _projectContext.Photos.ToListAsync();
            return photos;
        }
        public async Task <bool> Add(Photo photo)
        {
            await _projectContext.Photos.AddAsync(photo);
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
        }
        
        public async Task<bool> Delete(int id)
        {
            var idPhoto = _projectContext.Photos.FirstOrDefault(x => x.Id == id);
            if (idPhoto == null)
            {
                return false;
            }
            _projectContext.Photos.Remove(idPhoto);
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
        }
    }
}
