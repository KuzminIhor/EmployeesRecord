using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace EmployeesRecord.Data
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public string IpAddress { get; set; }
		public string IpCountryCode { get; set; }
		public int PositionId { get; set; }
		public Position Position { get; set; }
	}
}
