using Application.Input;
using Application.Output;
using Application.Service;
using Application.Service.Exportar;
using AutoMapper;
using Infra.Helpers;
using Infra.MarcoLista.Mapper;
using Infra.MarcoLista.Output.Adapter;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using infraestructure.Output.Adapter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:JwtBearer:Issuer"],
            ValidAudience = builder.Configuration["Authentication:JwtBearer:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtBearer:SecurityKey"]))
        };
    });

builder.Services.AddAutoMapper(typeof(OrganizacionProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var mapperConfig = new MapperConfiguration(m =>
{
    //m.AddProfile(new ProductorAgrarioProfile());
    m.AddProfile(new CondicionJuridicaProfile());
    m.AddProfile(new EspecieProfile());
    m.AddProfile(new ExcelProfile());
    m.AddProfile(new GestionRegistroProfile());
    m.AddProfile(new LineaProduccionProfile());
    m.AddProfile(new MarcoListaProfile());
    m.AddProfile(new NotificacionProfile());
    m.AddProfile(new OrganizacionProfile());
    m.AddProfile(new PanelRegistroProfile());
    m.AddProfile(new PersonaProfile());
    m.AddProfile(new PlantillaProfile());
    m.AddProfile(new TipoExplotacionProfile());
    m.AddProfile(new UsuarioProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
// Registrar las interfaces y sus implementaciones
//builder.Services.AddScoped<IProductorAgrarioService, ProductorAgrarioService>();
//builder.Services.AddScoped<IProductorAgrarioPort, ProductorAgrarioAdapter>();
//builder.Services.AddScoped<IProductorAgrarioRepository, ProductorAgrarioRepository>();
builder.Services.AddScoped<IExcelExporterService, ExcelExporterService>();
builder.Services.AddScoped<IGeneralService, GeneralService>();
builder.Services.AddScoped<IGeneralPort, GeneralAdapter>();
builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();
builder.Services.AddScoped<ICondicionJuridicaService, CondicionJuridicaService>();
builder.Services.AddScoped<ICondicionJuridicaPort, CondicionJuridicaAdapter>();
builder.Services.AddScoped<ICondicionJuridicaRepository, CondicionJuridicaRepository>();
builder.Services.AddScoped<IEspecieService, EspecieService>();
builder.Services.AddScoped<IEspeciePort, EspecieAdapter>();
builder.Services.AddScoped<IEspecieRepository, EspecieRepository>();
builder.Services.AddScoped<ILineaProduccionService, LineaProduccionService>();
builder.Services.AddScoped<ILineaProduccionPort, LineaProduccionAdapter>();
builder.Services.AddScoped<ILineaProduccionRepository, LineaProduccionRepository>();
builder.Services.AddScoped<IMarcoListaService, MarcoListaService>();
builder.Services.AddScoped<IMarcoListaPort, MarcoListaAdapter>();
builder.Services.AddScoped<IMarcoListaRepository, MarcoListaRepository>();
builder.Services.AddScoped<IOrganizacionService, OrganizacionService>();
builder.Services.AddScoped<IOrganizacionPort, OrganizacionAdapter>();
builder.Services.AddScoped<IOrganizacionRepository, OrganizacionRepository>();
builder.Services.AddScoped<ITipoExplotacionService, TipoExplotacionService>();
builder.Services.AddScoped<ITipoExplotacionPort, TipoExplotacionAdapter>();
builder.Services.AddScoped<ITipoExplotacionRepository, TipoExplotacionRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioPort, UsuarioAdapter>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<INotificacionService, NotificacionService>();
builder.Services.AddScoped<INotificacionPort, NotificacionAdapter>();
builder.Services.AddScoped<INotificacionRepository, NotificacionRepository>();
builder.Services.AddScoped<IPanelRegistroService, PanelRegistroService>();
builder.Services.AddScoped<IPanelRegistroPort, PanelRegistroAdapter>();
builder.Services.AddScoped<IPanelRegistroRepository, PanelRegistroRepository>();
builder.Services.AddScoped<IPlantillaService, PlantillaService>();
builder.Services.AddScoped<IPlantillaPort, PlantillaAdapter>();
builder.Services.AddScoped<IPlantillaRepository, PlantillaRepository>();
builder.Services.AddScoped<IGestionRegistroService, GestionRegistroService>();
builder.Services.AddScoped<IGestionRegistroPort, GestionRegistroAdapter>();
builder.Services.AddScoped<IGestionRegistroRepository, GestionRegistroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

var urlAceptadas = builder.Configuration["AllowedHosts"].ToString().Split(",");
app.UseCors(builder => builder.WithOrigins(urlAceptadas)
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      );
app.UseMiddleware<JwtMiddleware>();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
