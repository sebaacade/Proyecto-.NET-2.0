using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;

public class AgregarUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador)
{

    public void Ejecutar(Usuario u)
    {
        
        if (!validador.ValidarNombre(u.Nombre))
        {
            throw new ValidacionException("No se ingresó el nombre del Usuario");
        }

        if (!validador.ValidarApellido(u.Apellido))
        {
            throw new ValidacionException("No se ingresó el apellido del Usuario");
        }

        if (!validador.ValidarEmail(u.Email))
        {
            throw new ValidacionException("No se ingresó el Email del Usuario");
        }
        if (!validador.ValidarContraseña(u.Contraseña))
        {
            throw new ValidacionException("No se ingresó la Contraseña del Usuario");
        }
        if (validador.ValidarExisteEmail(u.Email!))
        {
            throw new DuplicadoException("Ya existe un Usuario registrado con el Email ingresado.");
        }

        // Hashear contraseña
        u.Contraseña = ContraseñaHash.Hash(u.Contraseña!);

        // Si es el primer usuario en registrarse (admin), le otorgo todos los permisos

        if (!repo.ExistenUsuariosRegistrados())
        {
            u.UsuarioPermisos = Enum.GetValues(typeof(Permisos)).Cast<Permisos>().ToList();
            //u.UsuarioPermisos = Enum.GetValues<Permisos>().ToList(); //otra manera creo
        }
        repo.AgregarUsuario(u);
    }

}