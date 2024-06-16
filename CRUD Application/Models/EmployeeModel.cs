using System.ComponentModel.DataAnnotations;

namespace CRUD_Application.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Enterr a valid Email")]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter a valid phone number")]
        public long? PhoneNo { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
