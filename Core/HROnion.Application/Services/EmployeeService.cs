using HROnion.Application.DTOs;
using HROnion.Application.Mapper;
using HROnion.Domain.Entities;
using HROnion.Domain.Repositories;

namespace HROnion.Application.Services;
public sealed class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

	public EmployeeService(IEmployeeRepository employeeRepository)
	{
		_employeeRepository = employeeRepository;
	}
	
	public async Task<int> CreateEmployeeAsync(CreateEmployeeDTO employee)
	{
		Employee newEmployee = employee.ToEntity();

		return await _employeeRepository.AddAsync(newEmployee);
	}

	public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
	{
		IEnumerable<Employee> employees = await _employeeRepository.GetAllAsync();
		return employees.Select(d => d.ToDTO()).ToList();
	}

	public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
	{
		Employee employee = await _employeeRepository.GetByIdAsync(id);
		return employee.ToDTO();
	}
}
