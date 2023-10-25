using System.Text.Json.Serialization;

namespace EmployeesRecord.Data;

public class EmployeeJSONModel
{
    [JsonPropertyName("employes")]
    public List<DeserializedEmployee> Employees { get; set; }
}