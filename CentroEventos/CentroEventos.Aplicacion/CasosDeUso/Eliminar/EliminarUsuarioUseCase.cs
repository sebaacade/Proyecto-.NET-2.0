using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;

public class EliminarUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Usuario u1, Usuario u)
    {
        if (!autorizacion.PoseeElPermiso(u1, Permisos.UsuarioBaja))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        
        if (!validador.ValidarEmail(u.Email))
        {
            throw new EntidadNotFoundException("El Usuario que se intenta eliminar no está registrado.");
        }
        repo.EliminarUsuario(u.Id);
    }
}