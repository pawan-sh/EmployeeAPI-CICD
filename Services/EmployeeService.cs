using EmployeeAPI.Models;
using EmployeeAPI.Repositories;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Employee>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Employee?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<Employee> AddAsync(Employee employee) => _repo.AddAsync(employee);

        public Task<Employee?> UpdateAsync(int id, Employee updated) => _repo.UpdateAsync(id, updated);

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
