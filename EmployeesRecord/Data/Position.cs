using System.Text.Json.Serialization;

namespace EmployeesRecord.Data
{
	public class Position
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Employee> Employees { get; set; } = new List<Employee>();
	}
}
