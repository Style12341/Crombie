using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkPractice.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public User Author { get; set; }
        [Required]
        public Guid AuthorId { get; set; }



    }
}
