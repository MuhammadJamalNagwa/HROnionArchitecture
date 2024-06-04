namespace HROnion.Application.DTOs;
public sealed record CreatePositionDTO
{
	public string Title { get; init; }
	public decimal Salary { get; init; }
}
