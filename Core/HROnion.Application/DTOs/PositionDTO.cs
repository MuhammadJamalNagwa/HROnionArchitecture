namespace HROnion.Application.DTOs;
public sealed record PositionDTO
{
	public int PositionId { get; init; }
	public string Title { get; init; }
	public decimal Salary { get; init; }
	public List<string> Employees { get; init; }
}
