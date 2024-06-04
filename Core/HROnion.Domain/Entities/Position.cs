namespace HROnion.Domain.Entities;

public class Position
{
	public int Id { get; set; }
    public string Title { get; set; }
    public decimal Salary { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
}
