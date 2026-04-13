using Microsoft.AspNetCore.Mvc;
using todoApp.Data;
using todoApp.Models;
using todoApp.Requests;

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
        public IActionResult Store(TodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        k => k.Key.ToLower(),
                        v => v.Value.Errors.Select(e => e.ErrorMessage)
                    );
                    
                return Json(new { success = false, errors = errors });
            }

            var todo = new Todo
            {
                Title = request.Title,
                IsDone = false
            };

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
