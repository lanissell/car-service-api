using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarService.Model.SparePartModel;

public class SparePartBrand: EntityBase
{
    [MaxLength(30)]
    public string Name { get; set; }

    [MaxLength(30)]
    public string Country { get; set; }

    [JsonIgnore]
    public virtual ICollection<SparePart> SpareParts { get; set; }
}

public class SparePartBrandDTO: DTOBase
{
    public string Name { get; set; }

    public string Country { get; set; }
}