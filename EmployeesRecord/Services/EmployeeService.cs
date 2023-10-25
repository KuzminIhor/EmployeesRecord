using EmployeesRecord.Data;
using EmployeesRecord.Repositories;
using EmployeesRecord.Repositories.Interfaces;
using EmployeesRecord.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace EmployeesRecord.Services
{
	public class EmployeeService: IEmployeeService
    {
        private IEmployeeRepository _employeeRepository = new EmployeeRepository();

        private const string checkIpAddressAPIUrl =
            "https://api.ipbase.com/v2/info?apikey=ipb_live_VVDrJbsBMl1MpihsajDAqmMoeFN2Ug23ZqgcBUcg&language=en";

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            return await _employeeRepository.GetAsync(employeeId);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            await _employeeRepository.DeleteAsync(employeeId);
        }

        public async Task InsertEmployeeAsync(Employee employee)
        {
            await ValidateFields(employee);

            await _employeeRepository.InsertAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await ValidateFields(employee);

            await _employeeRepository.UpdateAsync(employee);
        }

        private async Task ValidateFields(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                throw new ArgumentException("First Name can't be empty");
            }

            if (string.IsNullOrEmpty(employee.Surname))
            {
                throw new ArgumentException("Last Name can't be empty");
            }

            if (employee.Position == null)
            {
                throw new ArgumentException("You have to add at least 1 position");
            }

            if (string.IsNullOrEmpty(employee.IpAddress))
            {
                throw new ArgumentException("Ip Address can't be empty");
            }

            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var yt = checkIpAddressAPIUrl + "&ip=" + employee.IpAddress;
                    string jsonResponse = await client.GetStringAsync(yt);

                    JObject response = JObject.Parse(jsonResponse);

                    JToken alpha3Token = response.SelectToken("data.location.country.alpha3");

                    employee.IpCountryCode = alpha3Token.Value<string>();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ip Address you've provided is invalid");
            }

            bool is18YearsApart = (DateTime.Now - new DateTime(employee.BirthDate.Year, employee.BirthDate.Month, employee.BirthDate.Day)).TotalDays >= 18 * 365.25;

            if (!is18YearsApart)
            {
                throw new ArgumentException("Employee must be 18 years old or older");
            }

            if (await _employeeRepository.GetByNameSurnameAndBirthDateAsync(employee.Name, employee.Surname,
                    employee.BirthDate) != null && employee.Id == 0)
            {
                throw new ArgumentException("Employee with that data does already exist");
            }
        } 
    }
}
