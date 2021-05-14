using iCom_Generales;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class app_Alumno_EdoCtaView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtLog = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Catalogos();
            Carga_Datos_Filtro();

            //sResgitraLog("Inicio");
        }
    }

    #region Proc
    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        gvDatos.DataSource = null;
        gvDatos.DataBind();

        try
        {
            if (Valida_Filtro() == false)
            {
                return;
            }

            Carga_Datos_Filtro();
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void btnPagar_Click(object sender, EventArgs e)
    {
        // mpTC.Show();
    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //string message = "Selected Item: " + DropDownList1.SelectedItem.Text;
        //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + message + "');", true);
    }
    #endregion

    #region Datos
    protected void  Carga_Datos_Filtro()
    {
        try
        {
            if (Application["idusuario"].ToString() != "0")
            {
                iCom_BusinessEntity.Cuenta oBE = new iCom_BusinessEntity.Cuenta();
                iCom_BusinessLogic.Cuenta oBL = new iCom_BusinessLogic.Cuenta();

                oBE.idusuario = int.Parse(Application["idusuario"].ToString());

                dtDatos = oBL.ConsultarFiltro(oBE);

                if (dtDatos.Rows.Count > 0)
                {
                    gvDatos.DataSource = dtDatos;
                    gvDatos.DataBind();
                    return;
                }
                else
                {
                    ResgitraLog("No hay datos");
                    return;
                }
            }
            else
            {
                Response.Redirect("~/app/Login/Login.aspx");
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void Carga_Catalogos()
    {
        try
        {
            // Día
            ddlDiaI.Items.Add(new ListItem("Día"));
            ddlDiaF.Items.Add(new ListItem("Día"));

            for (int i = 1; i <= 31; i++)
            {
                ddlDiaI.Items.Add(new ListItem(i.ToString()));
                ddlDiaF.Items.Add(new ListItem(i.ToString()));
            }

            // Mes
            ddlMesI.Items.Add(new ListItem("Mes"));
            ddlMesF.Items.Add(new ListItem("Mes"));

            for (int i = 1; i <= 12; i++)
            {
                ddlMesI.Items.Add(new ListItem(i.ToString()));
                ddlMesF.Items.Add(new ListItem(i.ToString()));
            }

            // Estado
            ddlEstado.Items.Add(new ListItem("Selecciona"));

        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected bool Valida_Filtro()
    {
        // Fecha Inicial
        if (ddlDiaI.SelectedIndex == 0)
        {
            ResgitraLog("Debes de seleccionar un día.");
            ddlDiaI.Focus();
            return false;
        }

        if (ddlMesI.SelectedIndex == 0)
        {
            ResgitraLog("Debes de seleccionar un mes.");
            ddlMesI.Focus();
            return false;
        }

        if (txtAnioI.Text.Trim() == "")
        {
            ResgitraLog("Debes de capturar un año.");
            txtAnioI.Focus();
            return false;
        }

        // Fecha Final
        if (ddlDiaF.SelectedIndex == 0)
        {
            ResgitraLog("Debes de seleccionar un día.");
            ddlDiaF.Focus();
            return false;
        }

        if (ddlMesF.SelectedIndex == 0)
        {
            ResgitraLog("Debes de seleccionar un mes.");
            ddlMesF.Focus();
            return false;
        }

        if (txtAnioF.Text.Trim() == "")
        {
            ResgitraLog("Debes de capturar un año.");
            txtAnioF.Focus();
            return false;
        }

        DateTime fechaini = DateTime.Parse(ddlDiaI.SelectedItem.ToString() + "/" + ddlMesI.SelectedItem.ToString() + "/" + txtAnioI.Text);
        DateTime fechafin = DateTime.Parse(ddlDiaF.SelectedItem.ToString() + "/" + ddlMesF.SelectedItem.ToString() + "/" + txtAnioF.Text);

        if (fechaini > fechafin)
        {
            ResgitraLog("La fecha inical no puede ser mayor a la fecha final.");
            return false;
        }

        return true;
    }
    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_EdoCtaView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }

    protected void ResgitraLogDebug(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_EdoCtaView", sMensaje);
    }

    #endregion
}