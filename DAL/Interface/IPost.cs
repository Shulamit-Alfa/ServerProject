﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace DAL.Interface
{
    public interface IPost
    {
        Task<List<Post>> GetAll();
        Task<bool> Add(Post post);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, Post post);

    }
}
