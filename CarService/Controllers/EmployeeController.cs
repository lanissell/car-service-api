using AutoMapper;
using CarService.Model.HumanModel;
using DataAccessLayer;
using Microsoft.AspNetCore.Components;

namespace ControllerLayer;

[Route("/carserviceapi/[controller]")]
public class EmployeeController(IUnitOfWork uof, IMapper mapper) : ControllerBase<Employee, EmployeeDTO>(uof, mapper)
{
}