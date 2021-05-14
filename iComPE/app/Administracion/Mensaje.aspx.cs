using iCom_Generales;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class app_Administracion_Mensaje : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Catalogos();
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Application["idmensaje"] = "0";
        Response.Redirect("~/app/Administracion/MensajeView.aspx");
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

        Application["idmensaje"] = SelectedRow.Cells[0].Text.ToString();
        Response.Redirect("~/app/Administracion/MensajeView.aspx");
    }

    #region datos
    // Catalogos
    protected void Carga_Catalogos()
    {
        try
        {
            // Mensaje
            iCom_BusinessEntity.Mensaje oBE = new iCom_BusinessEntity.Mensaje();
            iCom_BusinessLogic.Mensaje oBL = new iCom_BusinessLogic.Mensaje();

            dtDatos = oBL.Mensajes(oBE);

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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_Mensaje", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
