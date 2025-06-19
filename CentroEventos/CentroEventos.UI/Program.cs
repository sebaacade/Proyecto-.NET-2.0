using CentroEventos.UI.Components;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// Configurar el context de base de datos
builder.Services.AddDbContext<CentroEventosContext>();

//Inyeccion de dependencias 
builder.Services.AddTransient<IServicioAutorizacion,ServicioAutorizacionProvisorio >();
builder.Services.AddTransient<PersonaValidador>();
builder.Services.AddTransient<ReservaValidador>();
builder.Services.AddTransient<UsuarioValidador>();
builder.Services.AddTransient<EventoDeportivoValidador>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersonaEF>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReservaEF>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivoEF>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
//Persona
builder.Services.AddTransient<AgregarPersonaUseCase>();
builder.Services.AddTransient<ListarPersonaUseCase>();
builder.Services.AddTransient<EliminarPersonaUseCase>();
builder.Services.AddTransient<ActualizarPersonaUseCase>();
//reserva
builder.Services.AddTransient<AgregarReservaUseCase>();
builder.Services.AddTransient<ListarReservaUseCase>();
builder.Services.AddTransient<EliminarReservaUseCase>();
builder.Services.AddTransient<ActualizarReservaUseCase>();
//EventosD
builder.Services.AddTransient<AgregarEventoDeportivoUseCase>();
builder.Services.AddTransient<ListarEventoDeportivoUseCase>();
builder.Services.AddTransient<EliminarUsuarioUseCase>();
builder.Services.AddTransient<ActualizarUsuarioUseCase>();

builder.Services.AddScoped<LoginUseCase>();

//usuario
builder.Services.AddScoped<AgregarUsuarioUseCase>();
builder.Services.AddScoped<ActualizarUsuarioUseCase>();



var app = builder.Build();

//inicializar base de datos
CentroEventosSqlite.Inicializar();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();