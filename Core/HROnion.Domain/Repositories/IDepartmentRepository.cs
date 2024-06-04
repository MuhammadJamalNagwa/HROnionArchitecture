using HROnion.Domain.Entities;

namespace HROnion.Domain.Repositories;

public interface IDepartmentRepository
{
	Task<Department?> GetByIdAsync(int id);
	Task<IEnumerable<Department>> GetAllAsync();
	Task<int> AddAsync(Department department);
	Task UpdateAsync(Department department);
	Task DeleteAsync(int id);
}