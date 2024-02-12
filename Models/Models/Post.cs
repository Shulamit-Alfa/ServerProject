using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsLike { get; set; }
    }
}
