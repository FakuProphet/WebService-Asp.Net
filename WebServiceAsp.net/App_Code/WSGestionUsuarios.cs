
using System.Collections;
using System.Data;
using System.Web.Services;

/// <summary>
/// Descripción breve de WSGestionUsuarios
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WSGestionUsuarios : System.Web.Services.WebService
{

    public WSGestionUsuarios()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos";
    }

    [WebMethod]
    public DataSet ListadoUsuarios()
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        DataSet SalidaDS = usuarioDAO.listadoUsuarios();
        return SalidaDS;
    }

}
