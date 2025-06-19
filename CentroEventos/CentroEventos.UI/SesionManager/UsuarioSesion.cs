using CentroEventos.Aplicacion;

public class UsuarioSesion
{
    // Guarda sólo lo necesario: Id y Permisos; si necesitas más, añade propiedades.
    public int        IdUsuario   { get; private set; }
    public List<Permisos>? Permiso { get; private set; }

    public bool EstaLogueado => IdUsuario != 0;

    public void SetUsuario(Usuario u)
    {
        IdUsuario = u.Id;
        Permiso = u.UsuarioPermisos;
    }

    public void Logout()
    {
        IdUsuario = 0;
        if (Permiso != null)
            Permiso.Clear();
    }

}