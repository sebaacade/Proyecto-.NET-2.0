using System;

namespace CentroEventos.Aplicacion;

public class LoginException:Exception
{
    public LoginException(string mensaje):base(mensaje){}
}