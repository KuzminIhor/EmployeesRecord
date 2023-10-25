using EmployeesRecord.Data;

namespace EmployeesRecord.Services.Interfaces
{
	public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployeesAsync();
        public Task<Employee> GetEmployeeAsync(int employeeId);
        public Task DeleteEmployeeAsync(int employeeId);
        public Task InsertEmployeeAsync(Employee employee);
        public Task UpdateEmployeeAsync(Employee employee);
    }
}
