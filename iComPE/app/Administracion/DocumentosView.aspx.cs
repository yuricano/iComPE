using iCom_Generales;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class app_Administracion_DocumentosView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtFiltro = new DataTable();

    static int idusuariotipo = 0;
    static int iddatosgenerales = 0;

    static string usuario = string.Empty;
    static string contrasena = string.Empty;

    static string sConceptos = string.Empty;
    static string sDescuentos = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Catalogos
            Carga_Catalogos();

            try
            {
                // Existe
                if (Application["idusuario"].ToString() != "0")
                {
                    if (Carga_Datos(int.Parse(Application["idusuario"].ToString())))
                    {                        
                        idusuariotipo = int.Parse(dtDatos.Rows[0]["idusuariotipo"].ToString());
                        iddatosgenerales = int.Parse(dtDatos.Rows[0]["iddatosgenerales"].ToString());

                        txtNombre.Text = dtDatos.Rows[0]["nombreU"].ToString() + " " +
                           dtDatos.Rows[0]["appaterno"].ToString() + " " +
                           dtDatos.Rows[0]["apmaterno"].ToString();

                        txtMatricula.Text = dtDatos.Rows[0]["matricula"].ToString();
                        DdlCarrera.SelectedIndex = int.Parse(dtDatos.Rows[0]["idcarrera"].ToString());
                        DdlCarrera.SelectedIndex = int.Parse(dtDatos.Rows[0]["idcarrera"].ToString());

                        archivoCarpeta(@"C:\Desarrollo\Documentos\1041");
                    }
                }
                else
                {
                    Response.Redirect("~/app/Login/Login.aspx");
                }
            } 
            catch (Exception ex)
            {
                ResgitraLog(ex.Message);
                return;
            }
        }
    }

    // Regresar
    protected void BtnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Documentos.aspx");
    }

    #region PDF
    // Leer Ruta
    public static void GetConfigurationValue()
    {
        var ruta = ConfigurationManager.AppSettings["RutaArchivos"];

        var applicationSettings = ConfigurationManager.GetSection("ApplicationSettings") as NameValueCollection;
        foreach (var key in applicationSettings.AllKeys)
        {
            Console.WriteLine(key + " = " + applicationSettings[key]);
        }
    }

    public void archivoCarpeta(string ruta)
    {
        string carpeta = ruta; //ConfigurationManager.AppSettings["carpetaDescarga"];
        DirectoryInfo dir = new DirectoryInfo(carpeta);

        dtDatos = new DataTable();

        dtDatos.Columns.Add("IdDocumento");
        dtDatos.Columns.Add("Documento");
        dtDatos.Columns.Add("FechaCreacion");
        int i = 0;

        try
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                i += 1;
                dtDatos.Rows.Add(i.ToString(), file.Name, file.CreationTime.ToString()); ;

                if (dtDatos.Rows.Count > 0)
                {
                    gvDatos.DataSource = dtDatos;
                    gvDatos.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }
    #endregion

    #region Datos
    protected bool Carga_Datos(int idusuario)
    {
        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

        oBE.idusuario = idusuario;

        try
        {
            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return false;
        }
    }

    // Catalogos
    protected void Carga_Catalogos()
    {
        try
        {
            // Carrera
            dtDatos = Filtros.Carrera(0);
            if (dtDatos.Rows.Count > 0)
            {
                DdlCarrera.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    DdlCarrera.Items.Add(new ListItem(row[1].ToString()));
                }
            }

        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void gvDatos_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.gvDatos, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void gvDatos_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow SelectedRow = gvDatos.SelectedRow;
        string ruta = @"C:\Desarrollo\Documentos\1041";

        // Ruta del PDF...
        //string path = Server.MapPath(SelectedRow.Cells[1].Text.ToString());
        string path = ruta + @"\" + SelectedRow.Cells[1].Text.ToString();
        WebClient client = new WebClient();
        Byte[] buffer = client.DownloadData(path);

        if (buffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
        }
    }

    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_DocumentosView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
