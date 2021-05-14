using iCom_Generales;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class app_Docente_Calificacion : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                btnGuardar.Visible = false;
                Carga_Periodos();
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int i = 0;

        iCom_BusinessEntity.UsuarioCurso oBE = new iCom_BusinessEntity.UsuarioCurso();
        iCom_BusinessLogic.UsuarioCurso oBL = new iCom_BusinessLogic.UsuarioCurso();

        foreach (GridViewRow row in gvDatos.Rows)
        {

            oBE.idusuariocurso = int.Parse(row.Cells[0].Text);

            TextBox tx = (TextBox)gvDatos.Rows[i].FindControl("txtCalificacion");
            oBE.calificacion = int.Parse(tx.Text.ToString());

            tx = (TextBox)gvDatos.Rows[i].FindControl("txtComentario");
            oBE.comentario = tx.Text;

            dtDatos = oBL.ActualizarCalificacion(oBE);

            i = i + 1;
        }

        ResgitraLog("Datos guardados.");
    }

    /*
    Public Sub myGrid_OnRowCreated(ByVal sender As Object, ByVal e As Web.UI.WebControls.GridViewRowEventArgs) Handles myGrid.RowCreated

        'Those columns you don't want to display you config here,

        'you could use a for statement if you have many :)

        e.Row.Cells(1).Visible = False

    End Sub
    */

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    TableCell cell = e.Row.Cells[2];

        //    if (cell != null)
        //    {
        //        if (cell.ToString() != "0" || cell.ToString() == string.Empty)
        //        {
        //            e.Row.Cells[2].Enabled = false;
        //        }
        //    }

        //    cell = e.Row.Cells[3];

        //    if (cell != null)
        //    {
        //        if (cell.ToString() != string.Empty)
        //        {
        //            e.Row.Cells[3].Enabled = false;
        //        }
        //    }
        //}
    }

    #region Catalogos
    protected void DdlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlCarrera.Items.Clear();

        try
        {
            // Carrera
            iCom_BusinessEntity.Materia oBE = new iCom_BusinessEntity.Materia();
            iCom_BusinessLogic.Materia oBL = new iCom_BusinessLogic.Materia();

            oBE.idusuariodocente = int.Parse(Application["idusuario"].ToString());
            oBE.periodoB = false;
            oBE.carreaB = true;
            oBE.idcarrera = 0;
            oBE.materiaB = false;

            dtDatos = oBL.ConsultarDocente(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                DdlCarrera.DataSource = dtDatos;
                DdlCarrera.DataTextField = "carrera";
                DdlCarrera.DataValueField = "idcarrera";
                DdlCarrera.DataBind();
                DdlCarrera.Focus();
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void DdlCarrera_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMateria.Items.Clear();

        try
        {
            // Materia
            iCom_BusinessEntity.Materia oBE = new iCom_BusinessEntity.Materia();
            iCom_BusinessLogic.Materia oBL = new iCom_BusinessLogic.Materia();

            oBE.idusuariodocente = int.Parse(Application["idusuario"].ToString());
            oBE.periodoB = false;
            oBE.carreaB = false;
            oBE.idcarrera = int.Parse(DdlCarrera.SelectedValue.ToString());
            oBE.materiaB = true;

            dtDatos = oBL.ConsultarDocente(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                ddlMateria.DataSource = dtDatos;
                ddlMateria.DataTextField = "materia";
                ddlMateria.DataValueField = "idmateria";
                ddlMateria.DataBind();
                ddlMateria.Focus();
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Materia
        iCom_BusinessEntity.UsuarioCurso oBE = new iCom_BusinessEntity.UsuarioCurso();
        iCom_BusinessLogic.UsuarioCurso oBL = new iCom_BusinessLogic.UsuarioCurso();

        oBE.idusuario = 0;
        oBE.idperiodoescolar = int.Parse(DdlPeriodo.SelectedValue.ToString());
        oBE.idmateria = int.Parse(ddlMateria.SelectedValue.ToString());
        oBE.idusuariodocente = int.Parse(Application["idusuario"].ToString());

        dtDatos = oBL.Calificacion(oBE);

        try
        {
            if (dtDatos.Rows.Count > 0)
            {
                gvDatos.DataSource = dtDatos;
                gvDatos.DataBind();
                btnGuardar.Visible = true;
            }
            else
            {
                // Sin datos
                gvDatos.DataSource = null;
                gvDatos.DataBind();
                btnGuardar.Visible = false;
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
    protected void Carga_Periodos()
    {
        try
        {
            // Periodos
            iCom_BusinessEntity.Materia oBE = new iCom_BusinessEntity.Materia();
            iCom_BusinessLogic.Materia oBL = new iCom_BusinessLogic.Materia();

            oBE.idusuariodocente = int.Parse(Application["idusuario"].ToString());
            oBE.periodoB = true;
            oBE.carreaB = false;
            oBE.idcarrera = 0;
            oBE.materiaB = false;

            dtDatos = oBL.ConsultarDocente(oBE);

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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_Calificacion", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
