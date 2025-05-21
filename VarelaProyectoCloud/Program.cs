using Microsoft.EntityFrameworkCore;
using VarelaProyectoCloud.Data;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IParticipanteService, ParticipanteService>();
builder.Services.AddScoped<IPonenteService, PonenteService>();
builder.Services.AddScoped<IEspacioService, EspacioService>();
builder.Services.AddScoped<IInscripcionService, InscripcionService>();
builder.Services.AddScoped<IPagoService, PagoService>();
builder.Services.AddScoped<ICertificadosService, CertificadoService>();
builder.Services.AddScoped<ISesionService, SesionService>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<IPonenteSesionService, PonenteSesionService>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.MaxDepth = 64; // opcional, aumenta el límite de profundidad
});


var app = builder.Build();

// Configure the HTTP request pipeline.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
