using AutoMapper;
using CarService.Model.SparePartModel;
using DataAccessLayer;

namespace ControllerLayer;

public class SparePartTypeController(IUnitOfWork uof, IMapper mapper) : ControllerBase<SparePartType, SparePartTypeDTO>(uof, mapper)
{
}