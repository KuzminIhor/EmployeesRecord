using EmployeesRecord.Data;

namespace EmployeesRecord.Repositories.Interfaces
{
	public interface IEmployeeRepository
	{
		public Task<Employee> GetAsync(int id);
        public Task<Employee> GetByNameSurnameAndBirthDateAsync(string name, string surname, DateOnly birthDate);
		public Task<List<Employee>> GetAllAsync();
		public Task InsertAsync(Employee employee);
		public Task UpdateAsync(Employee employee);
		public Task DeleteAsync(int id);
	}
}
