using EvaluacionDesempeno.Application.Interfaces;
using EvaluacionDesempeno.Infrastructure.Persistence;
using EvaluacionDesempeno.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services de la App
builder.Services.AddScoped<ICicloEvaluativoService, CicloEvaluativoService>();
builder.Services.AddScoped<IGrupoEvaluativoService, GrupoEvaluativoService>();
builder.Services.AddScoped<IModeloEvaluativoService, ModeloEvaluativoService>();
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<ICuestionarioService, CuestionarioService>();
builder.Services.AddScoped<IColaboradorService, ColaboradorService>();
builder.Services.AddScoped<IEvaluacionService, EvaluacionService>();
builder.Services.AddScoped<IRespuestaService, RespuestaService>();
builder.Services.AddScoped<IReporteService, ReporteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Seed(context);
}

app.Run();
