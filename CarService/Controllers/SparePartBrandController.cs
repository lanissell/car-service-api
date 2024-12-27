using AutoMapper;
using CarService.Model;
using CarService.Model.SparePartModel;
using DataAccessLayer;

namespace ControllerLayer;

public class SparePartBrandController(IUnitOfWork uof, IMapper mapper) : ControllerBase<SparePartBrand, SparePartBrandDTO>(uof, mapper)
{
}