using HROnion.Domain.Entities;
using HROnion.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using HROnion.Persistence.Database;

namespace HROnion.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
	private readonly ApplicationDbContext _context;

	public EmployeeRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Employee?> GetByIdAsync(int id)
	{
		return await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task<IEnumerable<Employee>> GetAllAsync()
	{
		return await _context.Employees.ToListAsync();
	}

	public async Task<int> AddAsync(Employee employee)
	{
		await _context.AddAsync(employee);

		await _context.SaveChangesAsync();

		return employee.Id;
	}

	public async Task UpdateAsync(Employee employee)
	{
		_context.Update(employee);

		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		Employee employee = await GetByIdAsync(id);

		if (employee is null)
		{
			throw new ArgumentNullException(nameof(Employee));
		}

		_context.Employees.Remove(employee);
	}
}
