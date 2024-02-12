using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using DAL.Interface;

namespace DAL.Data
{
    public class PostData : IPost
    {
        private readonly ProjectContext _projectContext;
        public PostData(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public async Task<List<Post>> GetAll()
        {
            List<Post> posts = await _projectContext.Posts.ToListAsync();
            return posts;

        }

        public async Task<bool> Add(Post post)
        {
            await _projectContext.Posts.AddAsync(post);
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
        }
        public async Task<bool> Update(int id, Post post)
        {
            var idPost = _projectContext.Posts.FirstOrDefault(x => x.Id == id);
            if (idPost == null)
            {
                return false;
            }
            idPost.Content = post.Content;
            idPost.IsLike = post.IsLike;
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
        }

        public async Task<bool> Delete(int id)
        {
            var idPost = _projectContext.Posts.FirstOrDefault(x => x.Id == id);
            if (idPost == null)
            {
                return false;
            }
            _projectContext.Posts.Remove(idPost);
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
            
        }
    }
}
