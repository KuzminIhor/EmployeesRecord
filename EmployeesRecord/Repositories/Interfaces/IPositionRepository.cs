using EmployeesRecord.Data;

namespace EmployeesRecord.Repositories.Interfaces
{
	public interface IPositionRepository
	{
		public Task<Position> GetAsync(int id);
        public Task<Position> GetAsync(string name);
        public Task<List<Position>> GetAllAsync();
		public Task InsertAsync(Position position);
		public Task UpdateAsync(Position position);
		public Task DeleteAsync(int id);
	}
}