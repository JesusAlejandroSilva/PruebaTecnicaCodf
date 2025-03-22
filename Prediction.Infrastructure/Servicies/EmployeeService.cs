using Prediction.Domain.Entities;
using Prediction.Infrastructure.Adapters.Interfaces;

namespace Prediction.Infrastructure.Servicies
{
    public class EmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }
    }
}
