namespace HROnion.Application.DTOs;
public sealed record CreateEmployeeDTO
{
	public int DepartmentId { get; set; }
	public int PositionId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string Email { get; set; }
}
