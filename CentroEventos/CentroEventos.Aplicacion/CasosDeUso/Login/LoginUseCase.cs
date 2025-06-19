using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;


public class LoginUseCase(IRepositorioUsuario repo, UsuarioValidador validador)
{
    public Usuario Ejecutar(string email, string password)
    {
        var usuario = repo.BuscarUsuarioPorEmail(email) ?? throw new LoginException("no existe un usuario con el mail ingresado");

        if (string.IsNullOrWhiteSpace(password))
            throw new LoginException("La contraseña no puede estar vacía.");

        var hashIngresado = ContraseñaHash.Hash(password);

        var hashRepo = usuario.Contraseña;

        if (!hashIngresado.Equals(hashRepo))
        {
            throw new LoginException("Contraseña incorrecta");
        }

        return usuario;

    }


}