using iCom_Generales;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class app_Administracion_Descuento : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Datos();
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Application["iddescuento"] = "0";
        Response.Redirect("~/app/Administracion/DescuentoView.aspx");
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

        Application["iddescuento"] = SelectedRow.Cells[0].Text.ToString();
        Response.Redirect("~/app/Administracion/DescuentoView.aspx");
    }

    protected void Carga_Datos()
    {
        iCom_BusinessEntity.Descuento oBE = new iCom_BusinessEntity.Descuento();
        iCom_BusinessLogic.Descuento oBL = new iCom_BusinessLogic.Descuento();

        oBE.iddescuento = 0;

        try
        {
            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                gvDatos.DataSource = dtDatos;
                gvDatos.DataBind();
                return;
            }
            else
            {
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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_Descuento", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
