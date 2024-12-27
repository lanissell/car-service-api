using AutoMapper;
using CarService.Model.CarModel;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace ControllerLayer;

[Route("/carserviceapi/[controller]")]
public class CarBrandController(IUnitOfWork uof, IMapper mapper) : ControllerBase<CarBrand, CarBrandDTO>(uof, mapper)
{

}