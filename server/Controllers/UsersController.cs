using Microsoft.AspNetCore.Mvc;
using DAL.Interface;
using Models.Models;
namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetUsers()
        {
            List<Users> res = await _user.GetAll();
            if (res.Count == 0)
                return BadRequest(new List<Photo>());
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] Users user)
        {
            bool res = await _user.Add(user);
            if(!res)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id,[FromBody]Users user)
        {
            bool res = await _user.Update(id, user);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            bool res = await _user.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();
        }
    }
}
