using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;


public class ListarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public List<EventoDeportivo> Ejecutar(){
        return repo.ListarEventoDeportivo();
    }
}
