namespace HROnion.Application.DTOs;
public sealed record DepartmentDTO
{
	public int DepartmentId { get; init; }
	public string Name { get; init; }
	public List<string> Employees { get; init; }
}
