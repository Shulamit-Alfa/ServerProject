using Microsoft.AspNetCore.Mvc;
using DAL.Interface;
using Models.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDo _todo;
        public ToDoController(IToDo todo)
        {
            _todo = todo;
        }
        [HttpGet]
        public async Task<ActionResult<List<ToDo>>> GetToDo()
        {
            List<ToDo> res = await _todo.GetAll();
            if (res.Count == 0)
                return BadRequest(new List<ToDo>());
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> PostToDo([FromBody] ToDo toDo)
        {
            bool res = await _todo.Add(toDo);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutToDo(int id, [FromBody] ToDo toDo)
        {
            bool res = await _todo.Update(id, toDo);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteToDo(int id)
        {
            bool res = await _todo.Delete(id);
            if(!res)
                return BadRequest();
            return Ok();
        }
    }
}
