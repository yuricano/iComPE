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

                        //string path = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "/") + "doc.pdf";
                        //string path = HttpContext.Current.Request.Url.AbsoluteUri.Replace(@"C:\Desarrollo\Documentos\1041", "/") + "*.pdf";

                        archivoCarpeta(@"C:\Desarrollo\Documentos\1041");

                        //string[] allfiles = System.IO.Directory.GetFiles(@"C:\Desarrollo\Documentos\1040", " *.*", System.IO.SearchOption.AllDirectories);
                        //TreeNode mainNode = new TreeNode();
                        //mainNode.Text = "Main";
                        //TreeFiles.Nodes.Add(mainNode);
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

    protected void btnpdf_Click(object sender, EventArgs e)
    {
        // Ruta del PDF...
        string path = Server.MapPath("SiteAnalytics.pdf");
        WebClient client = new WebClient();
        Byte[] buffer = client.DownloadData(path);

        if (buffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
        }
    }

    protected void View(object sender, EventArgs e)
    {
        string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        //ltEmbed.Text = string.Format(embed, ResolveUrl("~/Files/Mudassar_Khan.pdf"));
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

        foreach (FileInfo file in dir.GetFiles())
        {
            //HtmlTableRow tr = new HtmlTableRow();
            //HtmlTableCell td = new HtmlTableCe+;ll();
            //td.InnerHtml = file.Name;
            //tr.Cells.Add(td);
            //td = new HtmlTableCell();
            //td.InnerHtml = file.CreationTime.ToString();
            //tr.Cells.Add(td);
            //tblFich.Rows.Add(tr);

            i += 1;
            dtDatos.Rows.Add(i.ToString(), file.Name, file.CreationTime.ToString()); ;

            if (dtDatos.Rows.Count > 0)
            {
                gvDatos.DataSource = dtDatos;
                gvDatos.DataBind();
            }
        }
    }


    //listar los archivos de un directorio y del primer subnivel de directorios
    public void Listar()
    {
        int i = 0;
        int j = 0;

        string ruta = @"C:\Desarrollo\Documentos\1041";
        string ruta2 = @"C:\Desarrollo\Documentos\1041";

        string archivo = ""; //para el nombre de archivos y carpetas
        string carpeta = "";
        string[] sArchivos; //array con los nombres de archivos y carpetas
        string[] sCarpetas;

        DirectoryInfo carpetaInfo = default(DirectoryInfo); //objeto para extraer propiedades de las carpetas
        FileInfo archivoInfo = default(FileInfo); //objeto para extraer propiedades de los archivos
        try
        {
            //el objeto Response permite interaccionar servidor con cliente,
            //su método Write enví­a resultados HTTP al navegador web cliente.
            //Aquí lo utilizamos para ir enviando código HTML que va formateando una tabla
            //cuyas celdas se irán rellenando con texto y resultados de la ejecución de código C#
            Response.Write("<h2 align=center style='font-family:verdana;'>Listar archivos de un directorio</h2>");
            //array con los nombres de archivo en el directorio actual
            sArchivos = Directory.GetFiles(ruta);
            sCarpetas = Directory.GetDirectories(ruta);
            //número de archivos en el directorio
            i = sArchivos.Length;
            //crear la tabla y la cabecera con tí­tulos de columnas
            Response.Write("<table align=center border=0 style='font-family:verdana; font-size:10pt;'>");
            Response.Write("<tr style='background-color:black; color:white; font-weight:bold;'>");
            Response.Write("<td>Nombre</td>");
            Response.Write("<td align=right>TamaÃ±o</td>");
            Response.Write("<td align=center>Fecha</td>");
            Response.Write("<td align=center>Hora</td></tr>");
            //sección que lista los archivos que cuelgan directamente del directorio actual
            //condiciones: listar sólo en carpetas con al menos 1 archivo
            if (i > 0)
            {
                Response.Write("<tr><td colspan=4 align=center style='background-color:gray; color:white;'>");
                Response.Write("<b>Directorio " + ruta2 + " [archivos: " + System.Convert.ToString(i) + "</b>]");
            }
            Response.Write("</td></tr>");

            //Obtener lista de archivos contenidos en el directorio actual
            foreach (string archivoLoop in sArchivos)
            {
                archivo = archivoLoop;
                archivoInfo = new FileInfo(archivo);
                Response.Write("<tr>");
                Response.Write("<td bgcolor=Gainsboro>" + archivoInfo.Name + "</td>");
                Response.Write("<td bgcolor=Gainsboro align=right>" + archivoInfo.Length.ToString("#,#") + " bytes</td>");
                Response.Write("<td bgcolor=Gainsboro align=center>" + archivoInfo.CreationTime.ToShortDateString() + "</td>");
                Response.Write("<td bgcolor=Gainsboro align=center>" + archivoInfo.CreationTime.ToLongTimeString() + "</td></tr>");
            }

            //Obtener lista de directorios del directorio actual
            foreach (string carpetaLoop in sCarpetas)
            {
                carpeta = carpetaLoop;
                //For Each carpeta In Directory.GetDirectories(ruta)
                carpetaInfo = new DirectoryInfo(carpeta);
                //array con nombres de archivos en cada directorio
                sArchivos = Directory.GetFiles(carpeta);
                //número de carpetas en el directorio
                j = sArchivos.Length;
                //sección que lista las carpetas que cuelgan directamente del directorio
                //condición: listar sólo en carpetas con al menos 1 archivo
                //If j > 0 Then
                Response.Write("<tr><td colspan=4 align=center style='background-color:gray; color:white;'>");
                //condición: ocultar algunos directorios que no queremos que aparezcan en la lista
                //If carpetaInfo.Name <> "nombre_de_carpeta_para_ocultar" Then
                if (ruta2 == "/")
                {
                    Response.Write("<b>Directorio " + ruta2 + carpetaInfo.Name + " [archivos: " + System.Convert.ToString(j) + "</b>]");
                }
                else if (ruta2.StartsWith("C:\\"))
                {
                    Response.Write("<b>Directorio " + ruta2 + "\\" + carpetaInfo.Name + "[archivos: " + System.Convert.ToString(j) + "</b>]");
                }
                else
                {
                    Response.Write("<b>Directorio " + ruta2 + "/" + carpetaInfo.Name + " [archivos: " + System.Convert.ToString(j) + "</b>]");
                }
                //End If
                //End If
                Response.Write("</td></tr>");
                //calcular el número total de archivos que hay en los directorios
                i += j;
                //obtener lista de archivos contenidos en los directorios de primer nivel
                //sección que lista los archivos de esos directorios
                foreach (string archivoLoop in Directory.GetFiles(carpeta))
                {
                    archivo = archivoLoop;
                    archivoInfo = new FileInfo(archivo);
                    Response.Write("<tr bgcolor=Gainsboro><td>/" + carpetaInfo.Name + "/" + archivoInfo.Name + "</td>");
                    Response.Write("<td bgcolor=Gainsboro align=right>" + archivoInfo.Length.ToString("#,#") + " bytes</td>");
                    Response.Write("<td bgcolor=Gainsboro>" + archivoInfo.CreationTime.ToShortDateString() + "</td>");
                    Response.Write("<td bgcolor=Gainsboro>" + archivoInfo.CreationTime.ToLongTimeString() + "</td></tr>");
                }
            }

        }
        catch (Exception pollo)
        {
            //'finalizar la tabla con el Nº total de archivos listados
            //'sólo si el TextBox contiene alguna ruta
            //If ruta2 <> "" Then
            //    Response.Write("<tr><td colspan=4 align=center style='background-color:blue; color:white;'>")
            //    Response.Write("<b>número total de archivos = " & i & "</b>")
            //    Response.Write("</td></tr>")
            //End If
            Response.Write("</table>");
            //if (texto.Text.Length == 0)
            //{
            //    Response.Write("<p align=center style='font-family:verdana; font-size:10pt; color:red;'><b>" +
            //        "No se ha definido la ruta a los archivos que se van a listar.</b></p>");
            //}
            //else
            //{
            //    Response.Write("<p align=center style='font-family:verdana; font-size:10pt; color:red;'><b>" +
            //        pollo.Message + "</b></p>");
            //}
            //Response.End(); //detiene la carga de la página
        }
        //finalizar la tabla con el Nº total de archivos listados
        Response.Write("<tr><td colspan=4 align=center style='background-color:blue; color:white;'>");
        Response.Write("<b>número total de archivos = " + System.Convert.ToString(i) + "</b>");
        Response.Write("</td></tr>");
        Response.Write("</table>");
        Response.End(); //detiene la carga de la página
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

        Application["idusuario"] = SelectedRow.Cells[0].Text.ToString();
        Application["matricula"] = SelectedRow.Cells[1].Text.ToString();
        Application["admin"] = "1";
        Response.Redirect("~/app/Perfiles/AlumnoView.aspx");
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
