using Model;
using System.Text.Json.Serialization;

namespace CarService.Model.SparePartModel;

public class SparePart : EntityBase
{
    public string Name { get; set; }

    public int Count { get; set; }

    public bool IsOrderAvailable { get; set; }

    public DateTime ManufactureDate { get; set; }

    public double Cost { get; set; }

    public int SparePartBrandId { get; set; }

    [JsonIgnore]
    public virtual SparePartBrand SparePartBran { get; set; }

    public int SparePartTypeId { get; set; }

    [JsonIgnore]
    public virtual SparePartType SparePartType { get; set; }

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; }
}

public class SparePartDTO : DTOBase
{
    public string Name { get; set; }

    public int Count { get; set; }

    public bool IsOrderAvailable { get; set; }

    public DateTime ManufactureDate { get; set; }

    public double Cost { get; set; }

    public int SparePartBrandId { get; set; }

    public int SparePartTypeId { get; set; }
}