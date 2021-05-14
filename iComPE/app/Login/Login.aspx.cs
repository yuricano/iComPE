using iCom_Generales;
using System;
using System.Data;

public partial class Login_Login : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtLog = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        {
            txtUsuario.Focus();

            if (!IsPostBack)
            {
                if (Request.Cookies["UNAME"] != null && Request.Cookies["PWD"] != null)
                {
                    txtUsuario.Text = Request.Cookies["UNAME"].Value;
                    txtContrasena.Attributes["value"] = Request.Cookies["PWD"].Value;
                }
            }
        }
    }

    //
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Carga_Datos())
            {
                Session["login"] = "SI";
                Session["id"] = dtDatos.Rows[0]["idusuario"].ToString();

                Application["idusuario"] = dtDatos.Rows[0]["idusuario"].ToString();                
                Session["usuario"] = dtDatos.Rows[0]["usuario"].ToString();
                Session["nombre"] = dtDatos.Rows[0]["nombre"].ToString();

                ResgitraLog("Login - " + Session["usuario"].ToString() + " - " + Session["nombre"].ToString());

                switch (dtDatos.Rows[0]["usuariotipo"].ToString())
                {
                    case "admin":
                        Response.Redirect("../Administracion/Admin.aspx", false);
                        break;

                    case "alumno":
                        Response.Redirect("../Alumno/Alumno.aspx", false);
                        break;

                    case "docente":
                        Response.Redirect("../Docente/Docente.aspx", false);
                        break;
                }
            }
            else
            {
                lblError.Text = "Usuario o Contrasena no validos";
                return;
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    #region Datos

    protected bool Carga_Datos()
    { 
        iCom_BusinessEntity.Login oBE = new iCom_BusinessEntity.Login();
        iCom_BusinessLogic.Login oBL = new iCom_BusinessLogic.Login();

        try
        {
            if (txtUsuario.Text.ToString() == string.Empty)
            {
                return false;
            }

            if (txtContrasena.Text.ToString() == string.Empty)
            {
                return false;
            }
            else
            {
                lblError.Text = string.Empty;
                oBE.Usuario = txtUsuario.Text.ToString().Trim();
                oBE.Contrasena = txtContrasena.Text.ToString().Trim();

                dtDatos = oBL.Consultar(oBE);

                if (dtDatos.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    lblError.Text = "Usuario o Contrasena no validos";
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return false; 
        }
    }
    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"].ToString()), "Login", sMensaje);
        Log._Log(int.Parse(Session["id"].ToString()), "Login", sMensaje);

        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
