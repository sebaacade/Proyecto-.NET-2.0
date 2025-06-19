using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;

public class ActualizarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Usuario u,Reserva r){
        if (!autorizacion.PoseeElPermiso(u, Permisos.ReservaModificaion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(r.Id))
        {
            throw new EntidadNotFoundException("La reserva que se intenta actualizar no existe");
        }
        repo.ActualizarReserva(r);
    }
}
