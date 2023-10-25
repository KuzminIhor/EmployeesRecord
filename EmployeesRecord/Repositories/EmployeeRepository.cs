using EmployeesRecord.Data;
using EmployeesRecord.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesRecord.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationContext _dbContext = ApplicationContext.GetInstance();

        public async Task<Employee> GetAsync(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> GetByNameSurnameAndBirthDateAsync(string name, string surname, DateOnly birthDate)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e =>
                e.Name.Equals(name) && e.Surname.Equals(surname) && e.BirthDate.Equals(birthDate));
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.Include(e => e.Position).ToListAsync();
        }

        public async Task InsertAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

            _dbContext.Remove(employee);

            await _dbContext.SaveChangesAsync();
        }
    }
}
