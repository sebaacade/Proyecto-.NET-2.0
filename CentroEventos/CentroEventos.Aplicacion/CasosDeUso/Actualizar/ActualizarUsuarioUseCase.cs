using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;

public class ActualizarUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Usuario u, Usuario u1)
    {
        if (!autorizacion.PoseeElPermiso(u, Permisos.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarEmail(u1.Email))
        {
            throw new EntidadNotFoundException("El usuario que  se intenta actualizar no existe.");
        }
        repo.ActualizarUsuario(u1);
    }
}