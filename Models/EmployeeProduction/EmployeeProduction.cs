using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models.EmployeeProduction
{
    public class EmployeeProduction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime ProductionDate { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Qty { get; set; }

        public EmployeeManagement.Models.Employee.Employee Employee { get; set; } = new EmployeeManagement.Models.Employee.Employee();
        public EmployeeManagement.Models.Product.Product Product { get; set; } = new EmployeeManagement.Models.Product.Product();

    }
}
