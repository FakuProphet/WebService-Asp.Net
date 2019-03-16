using System;
using System.Data;
using System.Collections.Generic;
using WSGestionUsuarios;
using System.Collections;

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


    //public DataTable ToDataTable<T>(this IList<T> data)
    //{
    //    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
    //    object[] values = new object[props.Count];
    //    using (DataTable table = new DataTable())
    //    {
    //        long _pCt = props.Count;
    //        for (int i = 0; i < _pCt; ++i)
    //        {
    //            PropertyDescriptor prop = props[i];
    //            table.Columns.Add(prop.Name, prop.PropertyType);
    //        }
    //        foreach (T item in data)
    //        {
    //            long _vCt = values.Length;
    //            for (int i = 0; i < _vCt; ++i)
    //            {
    //                values[i] = props[i].GetValue(item);
    //            }
    //            table.Rows.Add(values);
    //        }
    //        return table;
    //    }
    //}
    //public DataTable ConvertToDataTable<T>(IList<T> data)
    //{
    //    PropertyDescriptorCollection propiedades = TypeDescriptor.GetProperties(typeof(T));
    //    DataTable table = new DataTable();

    //    foreach (PropertyDescriptor prop in propiedades)
    //    {
    //        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? rop.PropertyType);
    //    }
    //    foreach (T item in data)
    //    {
    //        DataRow row = table.NewRow();
    //        foreach (PropertyDescriptor prop in properties)
    //        {
    //            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
    //        }
    //        table.Rows.Add(row);
    //    }
    //    return table;

    //}


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