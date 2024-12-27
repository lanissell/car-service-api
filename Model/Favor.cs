using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Text.Json.Serialization;

namespace CarService.Model;

[ApiExplorerSettings(IgnoreApi = true)]
public class Favor : EntityBase
{
    [MaxLength(100)]
    public string Name { get; set; }

    public double Cost { get; set; }

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; }
}

public class FavorDTO : DTOBase
{
    public string Name { get; set; }

    public double Cost { get; set; }
}