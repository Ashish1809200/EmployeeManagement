using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Employee
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name {  get; set; } = string.Empty;

        [StringLength(10,MinimumLength =10, ErrorMessage = "Contact number must be 10 digits.")]
        public string? ContactNo { get; set; }
        public bool IsWorking { get; set; }

    }
}
