using System.Text.Json.Serialization;
using CarService.Model;
using CarService.Model.HumanModel;
using CarService.Model.SparePartModel;
using Model.CarSpace;

namespace Model;

public class Order : EntityBase
{
    public DateTime CreateDate { get; set; }

    public DateTime? FinishDate { get; set; }


    public int ClientId { get; set; }

    [JsonIgnore]
    public virtual Client Client { get; set; }


    public int CarId { get; set; }

    [JsonIgnore]
    public virtual Car Car { get; set; }

    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; }
    [JsonIgnore]
    public virtual ICollection<Favor> Favors { get; set; }
    [JsonIgnore]
    public virtual ICollection<SparePart> SpareParts { get; set; }
}

public class OrderDTO : DTOBase
{
    public DateTime CreateDate { get; set; }

    public DateTime? FinishDate { get; set; }


    public int ClientId { get; set; }

    public int CarId { get; set; }
}