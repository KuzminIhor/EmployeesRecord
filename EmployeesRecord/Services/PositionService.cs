using EmployeesRecord.Data;
using EmployeesRecord.Repositories;
using EmployeesRecord.Repositories.Interfaces;
using EmployeesRecord.Services.Interfaces;

namespace EmployeesRecord.Services
{
	public class PositionService: IPositionService
	{
        private readonly IPositionRepository _positionRepository = new PositionRepository();

        public async Task<List<Position>> GetPositionsAsync()
        {
            return await _positionRepository.GetAllAsync();
        }

        public async Task<Position> GetPositionAsync(int positionId)
        {
            return await _positionRepository.GetAsync(positionId);
        }

        public async Task DeletePositionAsync(int positionId)
        {
            await _positionRepository.DeleteAsync(positionId);
        }

        public async Task InsertPositionAsync(Position position)
        {
            await ValidateFields(position);

            await _positionRepository.InsertAsync(position);
        }

        public async Task UpdatePositionAsync(Position position)
        {
            await ValidateFields(position);

            await _positionRepository.UpdateAsync(position);
        }

        private async Task ValidateFields(Position position)
        {
            if (string.IsNullOrEmpty(position.Name))
            {
                throw new ArgumentException("Position Name can't be empty");
            }

            if (await _positionRepository.GetAsync(position.Name) != null)
            {
                throw new ArgumentException("Position with that name does already exist");
            }
        }
    }
}
