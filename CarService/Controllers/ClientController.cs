using AutoMapper;
using CarService.Model.HumanModel;
using DataAccessLayer;
using Microsoft.AspNetCore.Components;

namespace ControllerLayer;

[Route("/carserviceapi/[controller]")]
public class ClientController(IUnitOfWork uof, IMapper mapper) : ControllerBase<Client, ClientDTO>(uof, mapper)
{
}