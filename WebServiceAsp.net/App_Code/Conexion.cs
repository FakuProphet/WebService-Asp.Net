using MySql.Data.MySqlClient;
using System;

class Conexion
{
    static string cadena = "Server=localhost;Port=3306;Database=ws;Uid=root;Pwd=;";


    public static string pCadena
    {
        get { return cadena; }
    }

    
    public static MySqlConnection ObtenerConexion()
    {

        try
        {
            MySqlConnection conectar = new MySqlConnection(connectionString: cadena);
            conectar.Open();
            return conectar;
        }
        catch (Exception )
        {
            throw new Exception("Error en la conexion");
        }
    }

    public static MySqlConnection CerrarConexion()
    {
        MySqlConnection desconectar = new MySqlConnection(connectionString: cadena);
        desconectar.Close();
        desconectar.Dispose();
        return desconectar;
    }
}
