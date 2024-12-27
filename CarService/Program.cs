using AutoMapper;
using CarService.Model;
using CarService.Model.CarModel;
using CarService.Model.HumanModel;
using CarService.Model.SparePartModel;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.CarSpace;
using Plainquire.Filter.Mvc;
using Plainquire.Filter.Swashbuckle;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    options =>
        options.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123;")
    );


builder.Services.AddScoped<DbContext, DataContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<CarBrand, CarBrandDTO>().ReverseMap();
    cfg.CreateMap<Car, CarDTO>().ReverseMap();
    cfg.CreateMap<Client, ClientDTO>().ReverseMap();
    cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
    cfg.CreateMap<SparePart, SparePartDTO>().ReverseMap();
    cfg.CreateMap<SparePartBrand, SparePartBrandDTO>().ReverseMap();
    cfg.CreateMap<SparePartType, SparePartTypeDTO>().ReverseMap();
    cfg.CreateMap<Favor, FavorDTO>().ReverseMap();
    cfg.CreateMap<Order, OrderDTO>().ReverseMap();
});

var mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddControllers().AddFilterSupport();
builder.Services.AddSwaggerGen(options => options.AddFilterSupport());
builder.Services.AddSwaggerGen(c =>
{
    c.DocumentFilter<RemoveUnwantedSchemasDocumentFilter>();
});

var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();

app.UseSwagger()
    .UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });

app.UseMvc(
    routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "/{controller=Home}/{action=Index}/{id?}");
    }
);

app.Run();