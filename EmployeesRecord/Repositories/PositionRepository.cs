using EmployeesRecord.Data;
using EmployeesRecord.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesRecord.Repositories
{
	public class PositionRepository : IPositionRepository
	{
		private readonly ApplicationContext _dbContext = ApplicationContext.GetInstance();

        public async Task DeleteAsync(int id)
        {
            var position = await _dbContext.Positions.Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == id);

            _dbContext.Positions.Remove(position);

			await _dbContext.SaveChangesAsync();
        }

        public async Task<Position> GetAsync(int id)
        {
            return await _dbContext.Positions.Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Position> GetAsync(string name)
        {
            return await _dbContext.Positions.FirstOrDefaultAsync(p => p.Name.Equals(name));
        }

        public async Task<List<Position>> GetAllAsync()
        {
            return await _dbContext.Positions.ToListAsync();
        }

        public async Task InsertAsync(Position position)
        {
            _dbContext.Positions.Add(position);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Position position)
        {
            _dbContext.Positions.Update(position);

            await _dbContext.SaveChangesAsync();
        }
	}
}
