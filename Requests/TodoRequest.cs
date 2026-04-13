using System.ComponentModel.DataAnnotations;

namespace todoApp.Requests
{
    public class TodoRequest
    {
        [Required]
        [MinLength(3)]
        public required string Title { get; set; }
    }
}
