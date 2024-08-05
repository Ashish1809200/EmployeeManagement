using EmployeeManagement.Models.Employee;
using EmployeeManagement.Models.EmployeeProduction;
using EmployeeManagement.Models.Product;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeProductionViewModel
    {
        public List<EmployeeProduction> Productions { get; set; } = new List<EmployeeProduction>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
