using auth_jwt_refresh_mechanism.Interfaces;
using auth_jwt_refresh_mechanism.Repository;
using auth_jwt_refresh_mechanism.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


//for me
builder.Services.AddControllers();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
//


// DI like Autowired Service-Interface-Controller
builder.Services.AddTransient<ICustomerService, CustomerService>();
//


//for me sql connect
// builder.Services.AddDbContext<ApplicationDbContext>(o =>
// o.UseSqlServer(builder.Configuration.GetConnectionString("apicon")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

///




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
