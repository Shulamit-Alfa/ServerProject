using Microsoft.AspNetCore.Mvc;
using DAL.Interface;
using Models.Models;
namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController: ControllerBase
    {
        private readonly IPhoto _photo;
        public PhotoController(IPhoto photo)
        {
            _photo = photo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Photo>>> GetPhoto()
        {
            List<Photo> res = await _photo.GetAll();
            if (res.Count == 0)
                return BadRequest(new List<Photo>());
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> PostPhoto([FromBody] Photo photo)
        {
            bool res = await _photo.Add(photo);
            if (!res)
                return BadRequest();
            return Ok();
        }
        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutPhoto(int id, [FromBody] Photo photo)
        //{
        //    bool res = await _photo.Update(id,photo);
        //    if (!res)
        //        return BadRequest();
        //    return Ok();
        //}
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePhoto(int id)
        {
            bool res = await _photo.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();
        }

    }
}
