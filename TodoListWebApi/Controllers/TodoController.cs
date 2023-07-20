using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListWebApi.Data;
using TodoListWebApi.Models;

namespace TodoListWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        [Authorize]
        [HttpGet("todos")]
        public IActionResult GetAllTodos()
        {
            List<Todo> allTodos = MockDb.Todos.Values.ToList();
            return Ok(allTodos);
        }

        [Authorize]
        [HttpGet("todo/{id}")]
        public IActionResult GetTodo(int id)
        {
            MockDb.Todos.TryGetValue(id, out var todo);
            return todo == null ? NotFound() : Ok(todo);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("create-todo")]
        public IActionResult CreateTodo(Todo todo)
        {
            MockDb.Todos.Add(todo.Id, todo);
            return Ok(todo);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("update-todo")]
        public IActionResult UpdateTodo(int id, Todo todo)
        {
            MockDb.Todos.TryGetValue(id, out var updatedTodo);
            if(updatedTodo == null) return NotFound();

            updatedTodo.Title = todo.Title;
            updatedTodo.Description = todo.Description;
            updatedTodo.Completed = todo.Completed;
            return Ok(updatedTodo);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-todo")]
        public IActionResult DeleteTodo(int id)
        {
            if(!MockDb.Todos.ContainsKey(id)) return NotFound();
            MockDb.Todos.Remove(id);
            return Ok();
        }
    }
}   
