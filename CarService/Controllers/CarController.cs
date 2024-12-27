using AutoMapper;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Model.CarSpace;

namespace ControllerLayer;

[Route("/carserviceapi/[controller]")]
public class CarController(IUnitOfWork uof, IMapper mapper) : ControllerBase<Car, CarDTO>(uof, mapper)
{
}