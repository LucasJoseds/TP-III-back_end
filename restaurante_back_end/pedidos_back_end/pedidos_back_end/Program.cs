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
builder.Services.AddScoped<FuncionarioService>();

builder.Services.AddScoped<JwtService>();
builder.Services.AddDbContext<AppDbContext>(opttions =>
{
    opttions.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();

        });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("FuncionarioPolicy", policy =>
        policy.RequireRole("Funcionario"));
});

var app = builder.Build();

app.UseCors("AllowLocalhost3000");

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
