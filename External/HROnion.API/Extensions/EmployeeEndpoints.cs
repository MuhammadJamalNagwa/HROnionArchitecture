using HROnion.Application.DTOs;
using HROnion.Application.Services;

namespace API.Extensions;

public static class EmployeeEndpoints
{
	public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost("/api/employees", async (CreateEmployeeDTO newEmployee, EmployeeService employeeService) =>
		{
			int employeeId = await employeeService.CreateEmployeeAsync(newEmployee);

			return Results.Ok(employeeId);
		});

		app.MapGet("/api/employees/{id}", async (int id, EmployeeService employeeService) =>
		{
			EmployeeDTO employee = await employeeService.GetEmployeeByIdAsync(id);

			return Results.Ok(employee);
		});

		app.MapGet("/api/employees", async (EmployeeService employeeService) =>
		{
			IEnumerable<EmployeeDTO> employees = await employeeService.GetAllEmployees();

			return Results.Ok(employees);
		});
	}
}