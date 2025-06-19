using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo,EventoDeportivoValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Usuario u,int id){
        if (!autorizacion.PoseeElPermiso(u, Permisos.EventoBaja))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        } 
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("El evento que se intenta elimnar no esta registrado.");
        }
         if(!validador.ValidarNoTieneReservaAsociada(id)){
            throw new OperacionInvalidaException("El evento que se intenta eliminar cuenta con al menos una reserva asociada.");
        }
        repo.EliminarEventoDeportivo(id);
    }
}
