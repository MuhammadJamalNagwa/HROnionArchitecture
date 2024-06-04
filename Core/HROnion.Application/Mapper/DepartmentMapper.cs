using HROnion.Application.DTOs;
using HROnion.Domain.Entities;

namespace HROnion.Application.Mapper;

public static class DepartmentMapper
{
	public static Department ToEntity(this CreateDepartmentDTO source)
	{
		return new Department()
		{
			Name = source.Name
		};
	}

	public static DepartmentDTO ToDTO(this Department source)
	{
		return new DepartmentDTO()
		{
			DepartmentId = source.Id,
			Name = source.Name,
			Employees = source.Employees.Select(e => string.Format("{0} {1}", e.FirstName, e.LastName)).ToList(),
		};
	}
}
