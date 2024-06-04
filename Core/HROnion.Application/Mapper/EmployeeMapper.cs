using HROnion.Application.DTOs;
using HROnion.Domain.Entities;

namespace HROnion.Application.Mapper;

public static class EmployeeMapper
{
	public static Employee ToEntity(this CreateEmployeeDTO source)
	{
		return new Employee()
		{
			FirstName = source.FirstName,
			LastName = source.LastName,
			DateOfBirth = source.DateOfBirth,
			PositionId = source.PositionId,
			DepartmentId = source.DepartmentId,
			Email = source.Email
		};
	}

	public static EmployeeDTO ToDTO(this Employee source)
	{
		return new EmployeeDTO()
		{
			EmployeeId = source.Id,
			DepartmentId = source.DepartmentId,
			PositionId = source.PositionId,
			DepartmentName = source.Department.Name,
			PositionName = source.Position.Title,
			DateOfBirth = source.DateOfBirth,
			FirstName = source.FirstName,
			LastName = source.LastName,
			Email = source.Email
		};
	}
}