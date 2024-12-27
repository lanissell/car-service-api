using AutoMapper;
using CarService.Model;
using CarService.Model.HumanModel;
using CarService.Model.SparePartModel;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ControllerLayer;

public class OrderController(IUnitOfWork uof, IMapper mapper) : ControllerBase<Order, OrderDTO>(uof, mapper)
{
    [HttpGet("/carserviceapi/[controller]/{orderId}/getSparePart")]
    public List<SparePartDTO>? GetSpareParts(int orderId)
    {
        try
        {
            TryGetOrder(orderId, out var order);

            return order?.SpareParts.Select(mapper.Map<SparePartDTO>).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Uof.Rollback();
            return null;
        }
    }

    [HttpPost("/carserviceapi/[controller]/{orderId}/addSparePart")]
    public IActionResult AddSparePart([FromBody] List<int> sparePartIds, int orderId)
    {
        try
        {
            var result = TryGetOrder(orderId, out var order);

            if (order == null)
            {
                return result;
            }

            var spareParts = order.SpareParts;

            if (!TryGetMany(sparePartIds, ref spareParts))
            {
                return BadRequest("Spare parts not found.");
            }

            Repository.Update(order);
            uof.Commit();

            return Ok("Added");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Uof.Rollback();
            return BadRequest(e.ToString());
        }
    }

    [HttpGet("/carserviceapi/[controller]/{orderId}/getEmployee")]
    public List<EmployeeDTO>? GetEmployee(int orderId)
    {
        try
        {
            TryGetOrder(orderId, out var order);

            return order?.Employees.Select(mapper.Map<EmployeeDTO>).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Uof.Rollback();
            return null;
        }
    }

    [HttpPost("/carserviceapi/[controller]/{orderId}/addEmployees")]
    public IActionResult AddEmployee([FromBody] List<int> employeeIds, int orderId)
    {
        try
        {
            var result = TryGetOrder(orderId, out var order);

            if (order == null)
            {
                return result;
            }

            var employees = order.Employees;

            if (!TryGetMany(employeeIds, ref employees))
            {
                return BadRequest("Employees not found.");
            }
    
            Repository.Update(order);
            uof.Commit();

            return Ok("Added");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Uof.Rollback();
            return BadRequest(e.ToString());
        }
    }

    [HttpPost("/carserviceapi/[controller]/{orderId}/deleteSparePart")]
    public IActionResult DeleteSparePart([FromBody] List<int> sparePartIds, int orderId)
    {
        try
        {
            var result = TryGetOrder(orderId, out var order);

            if (order == null)
            {
                return result;
            }

            var spareParts = order.SpareParts;

            if (!TryDeleteMany(sparePartIds, ref spareParts))
            {
                return BadRequest("Spare parts not found.");
            }

            Repository.Update(order);
            uof.Commit();

            return Ok("Deleted");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Uof.Rollback();
            return BadRequest(e.ToString());
        }
    }

    [HttpPost("/carserviceapi/[controller]/{orderId}/deleteEmployees")]
    public IActionResult DeleteEmployee([FromBody] List<int> employeeIds, int orderId)
    {
        try
        {
            var result = TryGetOrder(orderId, out var order);

            if (order == null)
            {
                return result;
            }

            var employees = order.Employees;

            if (!TryDeleteMany(employeeIds, ref employees))
            {
                return BadRequest("Employees not found.");
            }

            Repository.Update(order);
            uof.Commit();

            return Ok("Deleted");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Uof.Rollback();
            return BadRequest(e.ToString());
        }
    }

    private bool TryGetMany<T>(List<int> ids, ref ICollection<T> list) where T : EntityBase
    {
        var repository = Uof.GetRepository<T>();
        var objects = repository.GetAll(s => ids.Contains(s.Id));

        if (objects.Count == 0)
        {
            return false;
        }

        foreach (var obj in objects)
        {
            list.Add(obj);
        }

        return true;
    }

    private bool TryDeleteMany<T>(List<int> ids, ref ICollection<T>? list) where T : EntityBase
    {
        var repository = Uof.GetRepository<T>();
        var objects = repository.GetAll(s => ids.Contains(s.Id));

        if (objects.Count == 0)
        {
            return false;
        }

        list ??= new List<T>();
        foreach (var obj in objects)
        {
            list.Remove(obj);
        }

        return true;
    }

    private IActionResult TryGetOrder(int orderId, out Order? order)
    {
        order = Repository.GetById(orderId);

        if (order == null)
        {
            return BadRequest($"No order with id: {orderId}");
        }

        return Ok(order);
    }
}