using HROnion.Application.DTOs;
using HROnion.Domain.Entities;

namespace HROnion.Application.Mapper;
public static class PositionMapper
{
	public static Position ToEntity(this CreatePositionDTO source)
	{
		return new Position()
		{
			Title = source.Title,
			Salary = source.Salary
		};
	}
	public static PositionDTO ToDTO(this Position source)
	{
		return new PositionDTO()
		{
			PositionId = source.Id,
			Salary = source.Salary,
			Employees = source.Employees.Select(e => string.Format("{0} {1}", e.FirstName, e.LastName)).ToList(),
			Title = source.Title,
		};
	}
}
