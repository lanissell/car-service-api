using System.ComponentModel.DataAnnotations;
using CarService.Model;
using CarService.Model.CarModel;
using System.Text.Json.Serialization;

namespace Model.CarSpace;

public class Car : EntityBase
{
    [MaxLength(12)]
    public string StatNumber { get; set; }

    public int Year { get; set; }

    public int HorsePower { get; set; }

    public int CarBrandId { get; set; }

    [JsonIgnore]
    public virtual CarBrand CarBrand { get; set; }

    [JsonIgnore]
    public virtual ICollection<Order>? Orders { get; set; }
}

public class CarDTO : DTOBase
{
    public string StatNumber { get; set; }

    public int Year { get; set; }

    public int HorsePower { get; set; }

    public int CarBrandId { get; set; }
}