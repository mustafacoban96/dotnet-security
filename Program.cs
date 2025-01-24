using System.Text;
using auth_jwt_refresh_mechanism.Helpers;
using auth_jwt_refresh_mechanism.Interfaces;
using auth_jwt_refresh_mechanism.Interfaces.IRepository;
using auth_jwt_refresh_mechanism.Repository;
using auth_jwt_refresh_mechanism.service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

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



////Jwt config
var _authkey = builder.Configuration.GetValue<string>("TokenService:_key");
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };

});
//////

//auto mapper
var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

/////
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// builder.Services.AddCors(p => p.AddPolicy("corspolicy1", build =>
// {
//     build.WithOrigins("https://localhost:5259").AllowAnyMethod().AllowAnyHeader();
// }));

builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


///
// DI like Autowired Service-Interface-Controller
builder.Services.AddTransient<ICustomerRepo,CustomerRepository>();
builder.Services.AddTransient<IRefreshHandler, RefreshHandler>();
//
//
builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter(policyName: "fixedwindow", options =>
{
    options.Window = TimeSpan.FromSeconds(10);
    options.PermitLimit = 1;
    options.QueueLimit = 0;
    options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
}).RejectionStatusCode=401);

//Logger config
string logpath = builder.Configuration.GetSection("Logging:Logpath").Value;
var _logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(logpath)
    .CreateLogger();
builder.Logging.AddSerilog(_logger);
//

/////
var _tokenservice = builder.Configuration.GetSection("TokenService");
builder.Services.Configure<TokenService>(_tokenservice);

///

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


//for me
app.UseCors();
//
app.UseHttpsRedirection();

//auth
app.UseAuthentication();
app.UseAuthorization();

//for me 2
app.MapControllers();
//



app.Run();
