using System.ComponentModel.DataAnnotations.Schema;
using Plainquire.Filter.Abstractions;

namespace CarService.Model;

[EntityFilter(Prefix = "")]
public abstract class EntityBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}

public abstract class DTOBase
{
    public int Id { get; set; }
}