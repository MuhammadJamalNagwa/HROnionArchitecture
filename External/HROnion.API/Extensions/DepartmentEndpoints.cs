using HROnion.Application.DTOs;
using HROnion.Application.Services;

namespace API.Extensions;

public static class DepartmentEndpoints
{
	public static void MapDepartmentEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost("/api/departments", async (CreateDepartmentDTO newDepartment, DepartmentService departmentService) =>
		{
			int departmentId = await departmentService.CreateDepartmentAsync(newDepartment);

			return Results.Ok(departmentId);
		});

		app.MapGet("/api/departments/{id}", async (int id, DepartmentService departmentService) =>
		{
			DepartmentDTO department = await departmentService.GetDepartmentByIdAsync(id);

			return Results.Ok(department);
		});

		app.MapGet("/api/departments", async (DepartmentService departmentService) =>
		{
			IEnumerable<DepartmentDTO> departments = await departmentService.GetAllDepartments();

			return Results.Ok(departments);
		});
	}
}
