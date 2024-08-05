using EmployeeManagement.DB;
using EmployeeManagement.Models.Employee;
using EmployeeManagement.Models.EmployeeProduction;
using EmployeeManagement.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services
{
    public class EmployeeProductionServices
    {
        private readonly AppDbContext _context;

        public EmployeeProductionServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProduction(EmployeeProduction production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            _context.Production.Add(production);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeProduction>> GetAllEmployeeProductions()
        {
            return await _context.Production
                .Include(p => p.Employee)
                .Include(p => p.Product)
                .ToListAsync();
        }

        public async Task<EmployeeProduction> GetEmployeeProductionById(int id)
        {
            var production = await _context.Production
                .Include(p => p.Employee)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (production == null)
                throw new ArgumentNullException(nameof(production));

            return production;
        }
        public async Task UpdateEmployeeProduction(EmployeeProduction production)
        {
            if (production == null)
                throw new ArgumentNullException(nameof(production));

            _context.Production.Update(production);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeProduction(int id)
        {
            var production = await _context.Production.FindAsync(id);
            if (production == null)
                throw new ArgumentException("Production not found.");
            _context.Production.Remove(production);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> SearchEmployeeByWorkingStatus(bool isWorking)
        {
            return await _context.Employee
                .Where(e=>e.IsWorking == isWorking)
                .ToListAsync();
        }

        public async Task<List<Product>> SearchProductByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new List<Product>();
            }

            return await _context.Products
                .Where(p => p.ProductName!= null && p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        } 
    }
}
