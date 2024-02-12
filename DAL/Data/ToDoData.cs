using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Interface;
using Models.Models;

namespace DAL.Data
{
    public class ToDoData : IToDo
    {
        private readonly ProjectContext _projectContext;
        public ToDoData(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public async Task<List<ToDo>> GetAll()
        {
            List<ToDo> todos = await _projectContext.ToDos.ToListAsync();
            return todos;
        }
        public async Task<bool> Add(ToDo todo)
        {
            await _projectContext.ToDos.AddAsync(todo);
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
        }
        public async Task<bool> Update(int id, ToDo todo)
        {
            var idTodo = _projectContext.ToDos.FirstOrDefault(x => x.Id == id);
            if (idTodo == null)
            {
                return false;
            }
            idTodo.Title = todo.Title;
            idTodo.Description = todo.Description;
            idTodo.CreateDate = todo.CreateDate;
            idTodo.IsComplete = todo.IsComplete;
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Delete(int id)
        {
            var idTodo = _projectContext.ToDos.FirstOrDefault(x => x.Id == id);
            _projectContext.ToDos.Remove(idTodo);
            var ifOk = _projectContext.SaveChanges() > 0;
            return ifOk;
        }
    }
}
