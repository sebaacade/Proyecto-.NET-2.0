using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public class ActualizarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Usuario u,Persona p){
        if (!autorizacion.PoseeElPermiso(u, Permisos.PersonaModificacion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(p.Id))
        {
            throw new EntidadNotFoundException("La persona que  se intenta actualizar no existe.");
        }
        repo.ActualizarPersona(p);
    }
}
