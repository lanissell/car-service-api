using System.ComponentModel.DataAnnotations;
using Model.CarSpace;
using System.Text.Json.Serialization;

namespace CarService.Model.CarModel;

public class CarBrand: EntityBase
{
    [MaxLength(20)]
    public string Name { get; set; }

    public string Country { get; set; }

    [JsonIgnore]
    public virtual ICollection<Car> Cars { get; set; }
}

public class CarBrandDTO: DTOBase
{
    public string Name { get; set; }

    public string Country { get; set; }
}