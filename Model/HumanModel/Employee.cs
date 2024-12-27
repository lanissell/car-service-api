using Model;
using System.Text.Json.Serialization;

namespace CarService.Model.HumanModel;

public class Employee : Human
{
    public DateTime EmploymentDate { get; set; }

    public double Salary { get; set; }

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; }
}

public class EmployeeDTO : HumanDTO
{
    public DateTime EmploymentDate { get; set; }

    public double Salary { get; set; }
}