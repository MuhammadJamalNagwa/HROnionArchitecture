using HROnion.Application.DTOs;
using HROnion.Application.Mapper;
using HROnion.Domain.Entities;
using HROnion.Domain.Repositories;

namespace HROnion.Application.Services;

public sealed class DepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

	public DepartmentService(IDepartmentRepository departmentRepository)
	{
		_departmentRepository = departmentRepository;
	}
	
	public async Task<int> CreateDepartmentAsync(CreateDepartmentDTO department)
	{
		Department newDepartment = department.ToEntity();

		return await _departmentRepository.AddAsync(newDepartment);
	}
	public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
	{
		Department department = await _departmentRepository.GetByIdAsync(id);
		return department.ToDTO();
	}

	public async Task<IEnumerable<DepartmentDTO>> GetAllDepartments()
	{
		IEnumerable<Department> departments = await _departmentRepository.GetAllAsync();
		return departments.Select(d => d.ToDTO()).ToList();
	}

}
