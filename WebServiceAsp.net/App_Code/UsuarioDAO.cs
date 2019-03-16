using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

public class UsuarioDAO
{
    MySqlCommand cmd;
    MySqlDataReader dr;

    public MySqlDataReader Dr
    {
        get
        {
            return dr;
        }

        set
        {
            dr = value;
        }
    }


    public DataSet listadoUsuarios()
    {
        MySqlDataAdapter da = new MySqlDataAdapter("select * from usuarios", Conexion.ObtenerConexion());
        DataSet ds = new DataSet();
        da.Fill(ds);
        Conexion.CerrarConexion();
        return ds;
    }

    public List<Usuario> GetListaUsuariosPorNivel(int nivel)
    {
        List <Usuario> lista = new List<Usuario>();
        Usuario nuevo;
        cmd = new MySqlCommand("proc_get_usuario_nivel", Conexion.ObtenerConexion());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("?n",MySqlDbType.Int32).Value=nivel;
        cmd.Parameters["?n"].Direction = ParameterDirection.Input;
        /*
         * el nombre de la base de datos en la cadena tiene q estar en minuscula,
         * de lo contrario se produce un error que no encuentra el procedimiento o funcion
         */
        Dr = cmd.ExecuteReader();
        Conexion.CerrarConexion();
        while(Dr.Read())
        {
            int nroDoc = Dr.GetInt32(0);
            string nombre = Dr.GetString(1);
            string apellido = Dr.GetString(2);
            int nivelID = Dr.GetInt32(3);
            string password = Dr.GetString(4);
            nuevo = new Usuario(nroDoc, nombre, apellido, nivelID, password);
            lista.Add(nuevo);
        }
        return lista;
    }

    List<Usuario> lista;
    public List<Usuario> ListaDeUsuarios()
    {
        lista = new List<Usuario>();
        Usuario usuario;
        cmd = new MySqlCommand("SELECT * FROM USUARIOS", Conexion.ObtenerConexion());
        Dr = cmd.ExecuteReader();
        Conexion.CerrarConexion();
        while (Dr.Read())
        {
            int nroDoc = Dr.GetInt32(0);
            string nombre = Dr.GetString(1);
            string apellido = Dr.GetString(2);
            int nivelID = Dr.GetInt32(3);
            string password = Dr.GetString(4);
            usuario = new Usuario(nroDoc, nombre, apellido, nivelID, password);
            lista.Add(usuario);
        }

        return lista;
    }
}