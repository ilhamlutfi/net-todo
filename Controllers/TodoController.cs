using Microsoft.AspNetCore.Mvc;
using todoApp.Data;
using todoApp.Models;

namespace todoApp.Controllers
{
    [Route("todo")]
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("get-list")]
        public IActionResult GetAll()
        {
            var data = _context.Todos.ToList();
            return Json(data);
        }

        [HttpPost("create")]
        public IActionResult Store(string title)
        {
            var todo = new Todo { Title = title, IsDone = false };
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost("delete")]
        public IActionResult Destroy(int id)
        {
            var todo = _context.Todos.Find(id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
