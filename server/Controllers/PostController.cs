using Microsoft.AspNetCore.Mvc;
using DAL.Interface;
using Models.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _post;
        public PostController(IPost post)
        {
            _post = post;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPost()
        {
            List<Post> res = await _post.GetAll();
            if (res.Count == 0)
                return BadRequest(new List<Post>());
            return Ok(res);
        }

        [HttpPost]

        public async Task<ActionResult> PostPost([FromBody] Post post)
        {
            bool res = await _post.Add(post);
            if (!res)
                return BadRequest();
            return Ok();

        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutPost(int id, [FromBody] Post post)
        {
            bool res = await _post.Update(id, post);
            if (!res)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            bool res = await _post.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();

        }










    }
}
