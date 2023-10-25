using EmployeesRecord.Data;

namespace EmployeesRecord.Services.Interfaces
{
	public interface IPositionService
	{
        public Task<List<Position>> GetPositionsAsync();
        public Task<Position> GetPositionAsync(int positionId);
        public Task DeletePositionAsync(int positionId);
        public Task InsertPositionAsync(Position position);
        public Task UpdatePositionAsync(Position position);
    }
}
