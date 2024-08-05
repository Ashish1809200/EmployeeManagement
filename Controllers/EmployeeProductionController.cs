using EmployeeManagement.Models.EmployeeProduction;
using EmployeeManagement.Services;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeProductionController : Controller
    {
        private readonly EmployeeProductionServices _employeeProductionServices;
        private readonly EmployeeService _employeeService;
        private readonly ProductServices _productServices;

        public EmployeeProductionController(EmployeeProductionServices employeeProductionServices,
                                            EmployeeService employeeService,
                                            ProductServices productServices)
        {
            _employeeProductionServices = employeeProductionServices;
            _employeeService = employeeService;
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var production = await _employeeProductionServices.GetAllEmployeeProductions();
            return View(production);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new EmployeeProductionViewModel
            {
                Employees = await _employeeService.GetEmployees(),
                Products = await _productServices.GetProduct()
            };

            viewModel.Productions.Add(new EmployeeProduction());

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeProductionViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var production in model.Productions)
                {
                    await _employeeProductionServices.AddProduction(production);
                }
                return RedirectToAction(nameof(Index));
            }

            model.Employees = await _employeeService.GetEmployees();
            model.Products = await _productServices.GetProduct();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var production = await _employeeProductionServices.GetEmployeeProductionById(id);
            if (production == null)
            {
                return NotFound();
            }
            return View(production);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeProduction production)
        {
            if (id != production.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeProductionServices.UpdateEmployeeProduction(production);
                }
                catch (Exception)
                {
                    if (await _employeeProductionServices.GetEmployeeProductionById(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(production);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeProductionServices.DeleteEmployeeProduction(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SearchEmployeeByWorkingStatus(bool isWorking)
        {
            var employees = await _employeeProductionServices.SearchEmployeeByWorkingStatus(isWorking);
            return View("EmployeeList", employees);
        }

        public async Task<IActionResult> SearchProductByName(string name)
        {
            var products = await _employeeProductionServices.SearchProductByName(name);
            return View("ProductList", products);
        }
    }
}
