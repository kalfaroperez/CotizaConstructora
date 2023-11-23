using CotizaConstructora.Core;
using CotizaConstructora.Core.Contracts;
using CotizaConstructora.Domain;
using CotizaConstructora.Persistance;
using CotizaConstructora.Persistance.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IClienteDomain, ClienteDomain>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IMaterialesDomain, MaterialesDomain>();
builder.Services.AddScoped<IMaterialesRepository, MaterialesRepository>();
builder.Services.AddScoped<ICotizacionesDomain, CotizacionesDomain>();
builder.Services.AddScoped<ICotizacionesRepository, CotizacionesRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
