using System.ComponentModel.DataAnnotations;

namespace ValidationExample.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Name field is required!")]
        [StringLength(50,ErrorMessage ="Name must be fewer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email field is required!")]
        [EmailAddress(ErrorMessage ="Please enter correct email address!")]
        public string EmailAddress { get; set; }
    }
}
