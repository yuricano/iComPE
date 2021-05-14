using iCom_Generales;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class app_Alumno_Materias : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();

    void Page_PreInit(object sender, EventArgs e)
    {
        if (Application["docente"] != null)
        {
            if (Application["docente"].ToString() == "1")
            {
                MasterPageFile = "~/Docente.master";
            }
        }

        if (Application["alumno"] != null)
        {
            if (Application["alumno"].ToString() == "1")
            {
                MasterPageFile = "~/Alumno.master";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Catalogos
            if (Application["idusuario"] != null)
            {
                Carga_Catalogos();
            }
            else
            {
                Response.Redirect("~/app/Login/Login.aspx");
                return;
            }
        }
    }

    #region Datos
    // Catalogos
    protected void Carga_Catalogos()
    {
        try
        {
            // Usuario
            iCom_BusinessEntity.Usuario oBEU = new iCom_BusinessEntity.Usuario();
            iCom_BusinessLogic.Usuario oBLU = new iCom_BusinessLogic.Usuario();

            oBEU.idusuario = int.Parse(Application["idusuario"].ToString());

            dtDatos = oBLU.Consultar(oBEU);

            if (dtDatos.Rows.Count == 0)
            {
                return;
            }

            // Carrera
            lblCarrera.Text = dtDatos.Rows[0]["carrera"].ToString();

            // Materias
            gvDatos.DataSource = null;
            gvDatos.DataBind();

            iCom_BusinessEntity.UsuarioCurso oBE = new iCom_BusinessEntity.UsuarioCurso();
            iCom_BusinessLogic.UsuarioCurso oBL = new iCom_BusinessLogic.UsuarioCurso();

            oBE.idusuario = int.Parse(Application["idusuario"].ToString());

            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                // Curso
                lblCurso.Text = dtDatos.Rows[0]["curso"].ToString();

                gvDatos.DataSource = dtDatos;
                gvDatos.DataBind();
                return;
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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_AlumnoView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
