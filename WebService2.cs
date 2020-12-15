using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


/// <summary>
/// Descripción breve de WebService2
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService2 : System.Web.Services.WebService
{

    public WebService2()
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
    public DataSet consultar()
    {
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=INF_328;Integrated Security=True");
        SqlDataAdapter ada = new SqlDataAdapter("select registro, ci, paterno, materno, nombre, genero, fecha_nac, direccion, nacionalidad, telefono, correo, carrera from alumno where registro='107149'", con);
        DataSet ds = new DataSet();
        ada.Fill(ds, "alumno");
        return ds;
    }
    [WebMethod]
    public DataSet consultar_materias(string ci)
    {
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=INF_328;Integrated Security=True");
        SqlDataAdapter ada = new SqlDataAdapter("select materia,concepto from materias where ci='"+ci.ToString()+"'", con);
        DataSet ds = new DataSet();
        ada.Fill(ds, "materias");
        return ds;
    }
    [WebMethod]
    public DataSet consultar_ci(string valor)
    {
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=INF_328;Integrated Security=True");
        SqlDataAdapter ada = new SqlDataAdapter("select * from alumno where ci='"+valor.ToString()+"'", con);
        DataSet ds = new DataSet();
        ada.Fill(ds, "alumno");
        return ds;
    }
    [WebMethod]
    public DataSet cargar_ci()
    {
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=INF_328;Integrated Security=True");
        SqlDataAdapter ada = new SqlDataAdapter("select ci from alumno", con);
        DataSet ds = new DataSet();
        ada.Fill(ds, "alumno");
        return ds;
    }
}

