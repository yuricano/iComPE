using iCom_Generales;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class app_Alumno_CalificacionesView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtLog = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Catalogos();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        iCom_BusinessEntity.UsuarioCurso oBE = new iCom_BusinessEntity.UsuarioCurso();
        iCom_BusinessLogic.UsuarioCurso oBL = new iCom_BusinessLogic.UsuarioCurso();

        oBE.idusuario = int.Parse(Session["id"].ToString());
        //oBE.idperiodo = DdlPeriodo.SelectedIndex;

        try
        {
            dtDatos = oBL.Calificacion(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                gvDatos.DataSource = dtDatos;
                gvDatos.DataBind();
                return;
            }
            else
            {
                // Sin datos
                gvDatos.DataSource = null;
                ResgitraLog("No hay datos.");
                gvDatos.DataBind();
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
        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

        oBE.idusuario = int.Parse(Session["id"].ToString());

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

    protected void Carga_Catalogos()
    {
        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.PeriodoEscolar oBL = new iCom_BusinessLogic.PeriodoEscolar();

        oBE.idusuario = int.Parse(Session["id"].ToString());

        try
        {
            dtDatos = oBL.ConsultarAlumno(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                DdlPeriodo.DataSource = dtDatos;
                DdlPeriodo.DataTextField = "periodoescolar";
                DdlPeriodo.DataValueField = "idperiodoescolar";
                DdlPeriodo.DataBind();
                DdlPeriodo.Focus();
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    #endregion

    #region Log

    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_Calificaciones", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
