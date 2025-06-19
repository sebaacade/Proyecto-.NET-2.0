using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{

    void AgregarUsuario(Usuario usuario);

    void EliminarUsuario(int id);

    List<Usuario> ListarUsuario();

    void ActualizarUsuario(Usuario usuario);

    Usuario BuscarUsuario(int id);

    bool ExistenUsuariosRegistrados();
   
    bool ExisteEmail(string email);
    Usuario BuscarUsuarioPorEmail(string email);

    /*
    bool ExisteId(int id);
    */
}
