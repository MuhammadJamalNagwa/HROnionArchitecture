using HROnion.Application.DTOs;
using HROnion.Application.Mapper;
using HROnion.Domain.Entities;
using HROnion.Domain.Repositories;

namespace HROnion.Application.Services;

public sealed class PositionService
{
	private readonly IPositionRepository _positionRepository;
	public PositionService(IPositionRepository positionRepository)
	{
		_positionRepository = positionRepository;
	}

	public async Task<int> CreatePositionAsync(CreatePositionDTO position)
	{
		Position newPosition = position.ToEntity();

		return await _positionRepository.AddAsync(newPosition);
	}

	public async Task<IEnumerable<PositionDTO>> GetAllPositions()
	{
		IEnumerable<Position> positions = await _positionRepository.GetAllAsync();
		return positions.Select(d => d.ToDTO()).ToList();
	}

	public async Task<PositionDTO> GetPositionByIdAsync(int id)
	{
		Position position = await _positionRepository.GetByIdAsync(id);
		return position.ToDTO();
	}
}