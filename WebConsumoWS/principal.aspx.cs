using System;
using System.Data;
using System.Collections.Generic;

public partial class principal : System.Web.UI.Page
{

    WSGestionUsuarios.WSGestionUsuariosSoapClient ws = new WSGestionUsuarios.WSGestionUsuariosSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        cargarListado();
    }

    protected void cargarListado()
    {    
        GridView1.DataSource = ws.ListadoUsuarios();
        GridView1.DataBind();
    }


    static DataTable ConvertListToDataTable(List<string[]> list)
    {
        // New table.
        DataTable table = new DataTable();

        // Get max columns.
        int columns = 0;
        foreach (var array in list)
        {
            if (array.Length > columns)
            {
                columns = array.Length;
            }
        }

        // Add columns.
        for (int i = 0; i < columns; i++)
        {
            table.Columns.Add();
        }

        // Add rows.
        foreach (var array in list)
        {
            table.Rows.Add(array);
        }

        return table;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int nivel = Convert.ToInt32(TextBox1.Text);
        GridView1.DataSource = ws.BuscarPorNivel(nivel);
        GridView1.DataBind();
    }
}