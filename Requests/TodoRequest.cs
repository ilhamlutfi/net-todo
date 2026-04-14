using System.ComponentModel.DataAnnotations;

namespace todoApp.Requests
{
    public class TodoRequest
    {
        [Required(ErrorMessage = "Title wajib diisi")]
        [MinLength(3, ErrorMessage = "Title minimal 3 karakter")]
        public required string Title { get; set; }
    }
}
