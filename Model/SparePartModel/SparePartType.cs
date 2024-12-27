using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarService.Model.SparePartModel;

public class SparePartType : EntityBase
{
    [MaxLength(30)]
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<SparePart> SpareParts { get; set; }
}

public class SparePartTypeDTO: DTOBase
{
    public string Name { get; set; }
}