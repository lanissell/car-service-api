using System.ComponentModel.DataAnnotations;

namespace CarService.Model.HumanModel;

public abstract class Human: EntityBase
{
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Surname { get; set; }

    [MaxLength(100)]
    public string Patronymic { get; set; }

    [MaxLength(12)]
    public string PhoneNumber { get; set; }

    [EmailAddress]
    public string EMail { get; set; }
}

public abstract class HumanDTO: DTOBase
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public string PhoneNumber { get; set; }

    public string EMail { get; set; }
}