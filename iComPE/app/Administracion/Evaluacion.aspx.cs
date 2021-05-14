using iCom_Generales;
using System;
using System.Data;
using System.Web.UI;

public partial class app_Administracion_Evaluacion : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtLog = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Carga_Datos())
            {
                gvDatos.DataSource = dtDatos;
                gvDatos.DataBind();
            }
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/EvaluacionView.aspx");
    }

    #region Datos

    protected bool Carga_Datos()
    {
        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

        oBE.idusuario = 0;
        oBE.idusuariotipo = 3;

        try
        {
            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                // lblError.Text = "Usuario o Contrasena no validos";
                return false;
            }
        }
        catch (Exception ex)
        {
            Log._Log(Convert.ToInt32(Session["id"]), "Login", ex.Message);
            ClientScript.RegisterClientScriptBlock(typeof(Page), "Error", "alert('" + ex.Message + "')", true);
            return false;
        }
    }
    #endregion
}
