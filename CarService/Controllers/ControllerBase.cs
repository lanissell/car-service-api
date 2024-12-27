using System.Diagnostics;
using AutoMapper;
using CarService.Model;
using CarService.Repository;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Plainquire.Filter;

namespace ControllerLayer;

[Route("/carserviceapi/[controller]")]
public abstract class ControllerBase<TE, TD>(IUnitOfWork uof, IMapper mapper) : Controller where TE : EntityBase where TD : DTOBase
{
    private IMapper mapper = mapper;
    private IUnitOfWork uof = uof;

    protected IUnitOfWork Uof => uof;

    private IRepository<TE> repository = uof.GetRepository<TE>();

    protected IRepository<TE> Repository => repository;

    [HttpGet]
    public IEnumerable<TD> Get([FromQuery] EntityFilter<TE> filter)
    {
        return repository.GetAll().Select(e => mapper.Map<TD>(e));
    }

    [HttpPost]
    public IActionResult Add([FromBody]TD entityDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            repository.Add(mapper.Map<TE>(entityDTO));
            uof.Commit();

            return Ok("Added");
        }
        catch (Exception e)
        {
            uof.Rollback();

            var message = e.Message;

            if (e.InnerException != null)
            {
                message += $"\n{e.InnerException.Message}";
            }

            return BadRequest(message);
        }
    }

    [HttpPost("/carserviceapi/[controller]/delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var obj = repository.GetById(id);

            if (obj == null)
            {
                return Ok($"{typeof(TE)} with {id} not found.");
            }

            repository.Delete(obj);
            uof.Commit();

            return Ok("Deleted");
        }
        catch (Exception e)
        {
            uof.Rollback();

            var message = e.Message;

            if (e.InnerException != null)
            {
                message += $"\n{e.InnerException.Message}";
            }

            return BadRequest(message);
        }
    }
}