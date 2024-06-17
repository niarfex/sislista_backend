using Application.Input;
using Application.Output;
using Application.Service;
using AutoMapper;
using Infra.MarcoLista.Mapper;
using Infra.MarcoLista.Output.Adapter;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using infraestructure.Output.Adapter;




//using Infra.ProductorAgrario.Mapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddAutoMapper(typeof(ProductorAgrarioProfile));
//builder.Services.AddAutoMapper(typeof(UbigeoProfile));
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
    m.AddProfile(new OrganizacionProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
// Registrar las interfaces y sus implementaciones
//builder.Services.AddScoped<IProductorAgrarioService, ProductorAgrarioService>();
//builder.Services.AddScoped<IProductorAgrarioPort, ProductorAgrarioAdapter>();
//builder.Services.AddScoped<IProductorAgrarioRepository, ProductorAgrarioRepository>();
builder.Services.AddScoped<IOrganizacionService, OrganizacionService>();
builder.Services.AddScoped<IOrganizacionPort, OrganizacionAdapter>();
builder.Services.AddScoped<IOrganizacionRepository, OrganizacionRepository>();
builder.Services.AddScoped<IGeneralService, GeneralService>();
builder.Services.AddScoped<IGeneralPort, GeneralAdapter>();
builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
