using iCom_Generales;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class app_Administracion_Periodo : System.Web.UI.Page
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

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Application["idperiodo"] = "0";
        Response.Redirect("~/app/Administracion/PeriodoView.aspx");
    }

    #region Datos

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

        Application["idperiodo"] = SelectedRow.Cells[0].Text.ToString();
        Response.Redirect("~/app/Administracion/PeriodoView.aspx");
    }

    protected void Carga_Catalogos()
    {
        try
        {   
            // Periodo Escolar
            dtDatos = Filtros.PeriodoEscolar(0);
            if (dtDatos.Rows.Count > 0)
            {
                gvDatos.DataSource = dtDatos;
                gvDatos.DataBind();
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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_Periodo", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
