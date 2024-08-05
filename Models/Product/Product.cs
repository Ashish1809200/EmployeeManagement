using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string? ProductName { get; set; }

        [Required]
        public string Unit { get; set; } = "pcs";

    }
}
