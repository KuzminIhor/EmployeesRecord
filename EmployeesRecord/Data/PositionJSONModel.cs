using System.Text.Json.Serialization;

namespace EmployeesRecord.Data;

public class PositionJSONModel
{
    [JsonPropertyName("positions")]
    public List<string> Positions { get; set; }
}