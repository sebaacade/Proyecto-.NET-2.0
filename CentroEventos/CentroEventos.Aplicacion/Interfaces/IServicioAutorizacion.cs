using System;

namespace CentroEventos.Aplicacion;

public interface IServicioAutorizacion
{
   public bool PoseeElPermiso(Usuario u, Permisos permiso);
}