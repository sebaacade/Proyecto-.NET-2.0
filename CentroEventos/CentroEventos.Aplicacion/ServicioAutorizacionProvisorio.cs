using System;

namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(Usuario u, Permisos p)//cambie la lista de permisos por ususraio ya que al preguntar se pasa
    {                                                //el usuario y el permiso a verificar
        return u.UsuarioPermisos.Contains(p);
    }
}