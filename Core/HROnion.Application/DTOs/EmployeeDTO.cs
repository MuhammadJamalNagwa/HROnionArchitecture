namespace HROnion.Application.DTOs;
public sealed record EmployeeDTO
{
	public int EmployeeId { get; init; }
	public int DepartmentId { get; init; }
	public int PositionId { get; init; }
	public string FirstName { get; init; }
	public string LastName { get; init; }
	public DateTime DateOfBirth { get; init; }
	public string Email { get; init; }
	public string DepartmentName { get; init; }
	public string PositionName { get; init; }
}
