using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using pedidos_back_end.Data;
using pedidos_back_end.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CardapioService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddDbContext<AppDbContext>(opttions =>
{
    opttions.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

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