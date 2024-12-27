using AutoMapper;
using CarService.Model;
using DataAccessLayer;

namespace ControllerLayer;

public class FavourController(IUnitOfWork uof, IMapper mapper) : ControllerBase<Favor, FavorDTO>(uof, mapper)
{
}