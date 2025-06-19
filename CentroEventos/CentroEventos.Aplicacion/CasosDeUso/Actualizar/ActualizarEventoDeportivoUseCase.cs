using System;
using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public class ActualizarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo,EventoDeportivoValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Usuario u,EventoDeportivo e){
        if (!autorizacion.PoseeElPermiso(u, Permisos.EventoModificacion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(e.Id))
        {
            throw new EntidadNotFoundException("El evento deportivo que se quiere actualizar no existe");
        }
        if (validador.ValidarSiExpiro(e.Id))
        {
            throw new OperacionInvalidaException("No se puede actualizar el evento porque este ya fue realizado");
        }
        if (!validador.ValidarFecha(e.FechaHoraInicio))
        {
            throw new OperacionInvalidaException("La fecha ingresada para actualizar es invalida.");// esta bien la excepcion o es validacionEXCEPCION?
        }
        repo.ActualizarEventoDeportivo(e);
    }
}
