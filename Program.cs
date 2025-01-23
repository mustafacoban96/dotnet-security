using auth_jwt_refresh_mechanism.Helpers;
using auth_jwt_refresh_mechanism.Interfaces;
using auth_jwt_refresh_mechanism.Interfaces.IRepository;
using auth_jwt_refresh_mechanism.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//for me
builder.Services.AddControllers();
builder.Services.AddOpenApi();


//for me sql connect
// builder.Services.AddDbContext<ApplicationDbContext>(o =>
// o.UseSqlServer(builder.Configuration.GetConnectionString("apicon")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//auto mapper
var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

///
// DI like Autowired Service-Interface-Controller
builder.Services.AddTransient<ICustomerRepo,CustomerRepository>();
//




//for me newJosn
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

//




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//for me 2
app.MapControllers();
//



app.Run();
