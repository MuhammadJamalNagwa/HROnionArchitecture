using HROnion.Domain.Repositories;
using HROnion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HROnion.Persistence.Database;

namespace HROnion.Persistence.Repositories;
public class DepartmentRepository : IDepartmentRepository
{
	private readonly ApplicationDbContext _context;
	public DepartmentRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Department?> GetByIdAsync(int id)
	{
		return await _context.Departments.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task<IEnumerable<Department>> GetAllAsync()
	{
		return await _context.Departments.ToListAsync();
	}

	public async Task<int> AddAsync(Department department)
	{
		try
		{
			await _context.AddAsync(department);

			await _context.SaveChangesAsync();

			return department.Id;
		}
		catch (Exception ex) 
		{
			return 0;
		}
		
	}

	public async Task UpdateAsync(Department department)
	{
		_context.Update(department);

		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		Department department = await GetByIdAsync(id);

		if(department is null)
		{
			throw new ArgumentNullException(nameof(Department));
		}

		_context.Departments.Remove(department);
	}
}
