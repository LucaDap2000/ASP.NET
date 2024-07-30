using System.ComponentModel.DataAnnotations;
namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        // [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title!")]
        // [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 characters!")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter some content!")]
        public string Content { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a date!")]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
