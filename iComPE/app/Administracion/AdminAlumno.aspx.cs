using iCom_Generales;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class app_Administracion_AdminAlumno : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Catalogos();
        }
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        try
        {
            iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
            iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

            oBE.idusuariotipo = 4;
            oBE.idcarrera = DdlCarrera.SelectedIndex;
            oBE.idperiodo = DdlPeriodo.SelectedIndex;

            dtDatos = oBL.Filtrar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                GvDatos.DataSource = dtDatos;
                GvDatos.DataBind();
                return;
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void GvDatos_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GvDatos, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void GvDatos_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow SelectedRow = GvDatos.SelectedRow;

        Application["idusuario"] = SelectedRow.Cells[0].Text.ToString();
        Application["matricula"] = SelectedRow.Cells[1].Text.ToString();
        Response.Redirect("~/app/Administracion/AdminAlumnoView.aspx");
    }

    #region Datos

    protected bool Carga_Datos()
    {
        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

        oBE.idusuario = 0;
        oBE.idusuariotipo = 4;

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
        try
        {
            // Carrera
            dtDatos = Filtros.Carrera(0);
            DdlCarrera.Items.Clear();

            if (dtDatos.Rows.Count > 0)
            {
                DdlCarrera.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    DdlCarrera.Items.Add(new ListItem(row[1].ToString()));
                }
            }

            // Periodo Escolar
            dtDatos = Filtros.PeriodoEscolar(0);
            DdlPeriodo.Items.Clear();

            if (dtDatos.Rows.Count > 0)
            {
                DdlPeriodo.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    DdlPeriodo.Items.Add(new ListItem(row[3].ToString()));
                }
            }

            // Materia
            //ddlMateria.Items.Add(new ListItem("Selecciona"));

            // Grupo
            //ddlGrupo.Items.Add(new ListItem("Selecciona"));
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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_AdminAlumno", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
