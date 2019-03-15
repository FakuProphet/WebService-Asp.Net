

/// <summary>
/// Clase para encapsulamiento de cada atributo
/// </summary>
public class Usuario
{
    private int nroDoc;
    private string nombre;
    private string apellido;
    private int nivelID;
    private string password;

    public Usuario(int nroDoc, string nombre, string apellido, int nivelID, string password)
    {
        this.nroDoc = nroDoc;
        this.nombre = nombre;
        this.apellido = apellido;
        this.nivelID = nivelID;
        this.password = password;
    }

    public Usuario() { }

    public int NroDoc
    {
        get
        {
            return nroDoc;
        }

        set
        {
            nroDoc = value;
        }
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }

    public string Apellido
    {
        get
        {
            return apellido;
        }

        set
        {
            apellido = value;
        }
    }

    public int NivelID
    {
        get
        {
            return nivelID;
        }

        set
        {
            nivelID = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }
}