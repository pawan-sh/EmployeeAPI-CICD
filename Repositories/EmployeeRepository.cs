using EmployeeAPI.Data;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _db;

        public EmployeeRepository(EmployeeDbContext db)
        {
            _db = db;
        }

        public async Task<List<Employee>> GetAllAsync() =>
            await _db.Employees.ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) =>
            await _db.Employees.FindAsync(id);

        public async Task<Employee> AddAsync(Employee employee)
        {
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateAsync(int id, Employee updated)
        {
            var existing = await _db.Employees.FindAsync(id);
            if (existing == null) return null;

            existing.Name = updated.Name;
            existing.Department = updated.Department;
            existing.Salary = updated.Salary;

            await _db.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null) return false;

            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
