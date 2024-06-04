namespace HROnion.Domain.Entities;
public class Employee
{
	public int Id { get; set; }
	public int DepartmentId { get; set; }
	public int PositionId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string Email { get; set; }
	public virtual Department Department { get; set; }
	public virtual Position Position { get; set; }
}