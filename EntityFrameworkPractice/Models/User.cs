using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkPractice.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public String Name { get; set; } = String.Empty;
        [MaxLength(100)]
        public String Email { get; set; } = String.Empty;
        public Boolean IsEmailVerified { get; set; } = false;
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
