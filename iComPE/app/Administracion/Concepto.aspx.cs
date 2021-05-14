using iCom_Generales;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class app_Administracion_Concepto : System.Web.UI.Page
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
        Application["idconcepto"] = "0";
        Response.Redirect("~/app/Administracion/ConceptoView.aspx");
    }

    protected void ddlIngresoEgreso_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
            if (int.Parse(ddlIngresoEgreso.SelectedValue.ToString()) == -1)
            {
                ResgitraLog("Selecciona Ingreo o Egreso");
                ddlIngresoEgreso.Focus();
                return;
            }

            try
            {
                iCom_BusinessEntity.Concepto oBE = new iCom_BusinessEntity.Concepto();
                iCom_BusinessLogic.Concepto oBL = new iCom_BusinessLogic.Concepto();

                oBE.tipo = true;

                if (ddlIngresoEgreso.SelectedValue.ToString() == "0")
                {
                    oBE.ingresoegreso = false;
                }
                else
                {
                    oBE.ingresoegreso = true;
                }

                dtDatos = oBL.ConsultarConceptoIE(oBE);

                if (dtDatos.Rows.Count > 0)
                {
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

        Application["idconcepto"] = SelectedRow.Cells[0].Text.ToString();
        Response.Redirect("~/app/Administracion/ConceptoView.aspx");
    }

    protected void Carga_Catalogos()
    {
        try
        {
            // Ingreso Egreso
            ddlIngresoEgreso.Items.Clear();

            iCom_BusinessLogic.Concepto oBL = new iCom_BusinessLogic.Concepto();

            dtDatos = oBL.ConsultarIE();

            if (dtDatos.Rows.Count > 0)
            {
                ddlIngresoEgreso.DataSource = dtDatos;
                ddlIngresoEgreso.DataTextField = "IE";
                ddlIngresoEgreso.DataValueField = "id";
                ddlIngresoEgreso.DataBind();
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void Carga_Datos()
    {
        iCom_BusinessEntity.Concepto oBE = new iCom_BusinessEntity.Concepto();
        iCom_BusinessLogic.Concepto oBL = new iCom_BusinessLogic.Concepto();

        oBE.idconcepto = 0;

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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_Concepto", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}