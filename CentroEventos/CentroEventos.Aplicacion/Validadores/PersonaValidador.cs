using System;
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;
using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion;

public class PersonaValidador(IRepositorioPersona repositorio,IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoED)
{//Decirle a belen que lo cambie que la interfaz no va en el parametro del metodo
 // si no va en el constructor primario.
    public bool ValidarNombre(string nombre)
    {
        return !(string.IsNullOrWhiteSpace(nombre));
    }
    public bool ValidarApellido(string apellido)
    {

        return !(string.IsNullOrWhiteSpace(apellido));

    }

    public bool ValidarDNI(string dni)
    {

        return !(string.IsNullOrWhiteSpace(dni));
    }
    public bool ValidarEmail(string email)
    {

        return !(string.IsNullOrWhiteSpace(email));
    }

    public bool ValidarExisteEmail(string email)
    {
        return repositorio.ExisteEmail(email);
    }

    public bool ValidarExisteDni(string dni)
    {
        return repositorio.ExisteDNI(dni);
    }

    public bool ValidarExiste(int id)//validacion solo para el eliminar y modificar
    {
        return repositorio.ExisteId(id);
    }
    public bool ValidarNoTieneReservaAsociada(int id){ //validación para eliminar
        return !repoReserva.PersonaTieneReservaAsociada(id);
    }

    public bool ValidarNoEsResponsableDeEventoDeportivo(int id){ //validación para eliminar
        return !repoED.EsResponsableDeEventoDeportivo(id);
    }
}
