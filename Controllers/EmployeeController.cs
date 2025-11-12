using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // In-memory list for demo purpose
        private static readonly List<Employee> _employees = new();

        [HttpGet]
        public IActionResult GetAll() => Ok(_employees);

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Employee updated)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing is null) return NotFound();

            existing.Name = updated.Name;
            existing.Department = updated.Department;
            existing.Salary = updated.Salary;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return NotFound();

            _employees.Remove(employee);
            return NoContent();
        }
    }
}
