using HROnion.Domain.Repositories;
using HROnion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HROnion.Persistence.Database;

namespace HROnion.Persistence.Repositories;
public class PositionRepository : IPositionRepository
{
	private readonly ApplicationDbContext _context;
	public PositionRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Position?> GetByIdAsync(int id)
	{
		return await _context.Positions.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task<IEnumerable<Position>> GetAllAsync()
	{
		return await _context.Positions.ToListAsync();
	}

	public async Task<int> AddAsync(Position position)
	{
		await _context.AddAsync(position);

		await _context.SaveChangesAsync();

		return position.Id;
	}

	public async Task UpdateAsync(Position position)
	{
		_context.Update(position);

		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		Position position = await GetByIdAsync(id);

		if (position is null)
		{
			throw new ArgumentNullException(nameof(Position));
		}

		_context.Positions.Remove(position);
	}
}
