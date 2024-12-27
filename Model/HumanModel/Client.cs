using Model;
using System.Text.Json.Serialization;

namespace CarService.Model.HumanModel;

public class Client : Human
{
    public DateTime FirstVisitingDate { get; set; }

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; }
}

public class ClientDTO : HumanDTO
{
    public DateTime FirstVisitingDate { get; set; }
}