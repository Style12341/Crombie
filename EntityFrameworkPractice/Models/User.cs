using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkPractice.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        [Required]
        [MaxLength(100)]
        public String Email { get; set; }
        
        public Boolean IsEmailVerified { get; set; } = false;
    }
}
