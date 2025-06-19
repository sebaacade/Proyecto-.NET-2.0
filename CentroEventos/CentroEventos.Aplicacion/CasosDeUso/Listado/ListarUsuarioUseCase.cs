using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;

public class ListarUsuarioUseCase(IRepositorioUsuario repo)
{
    public List<Usuario> Ejecutar()
    {
        return repo.ListarUsuario();
    }
}