using AutoMapper;
using CarService.Model.SparePartModel;
using DataAccessLayer;

namespace ControllerLayer;

public class SparePartController(IUnitOfWork uof, IMapper mapper) : ControllerBase<SparePart, SparePartDTO>(uof, mapper)
{
}