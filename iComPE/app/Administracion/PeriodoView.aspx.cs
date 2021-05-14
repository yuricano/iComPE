using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using iCom_Generales;

public partial class app_Administracion_PeriodoView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtLog = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Año
            ddlAnio.DataSource = Enumerable.Range(System.DateTime.Now.Year, 5).ToList();
            ddlAnio.DataBind();

            if (Application["idperiodo"].ToString() != "0")
            {
                try
                {
                    if (Carga_Datos(int.Parse(Application["idperiodo"].ToString())))
                    {
                        rblMes.SelectedValue = dtDatos.Rows[0]["idperiodo"].ToString();
                        ddlAnio.SelectedValue = dtDatos.Rows[0]["anio"].ToString();
                        chkActivo.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    ResgitraLog(ex.Message);
                    return;
                }
            }
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Periodo.aspx");
    }

    #region Datos

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            iCom_BusinessLogic.PeriodoEscolar oBLPeriodo = new iCom_BusinessLogic.PeriodoEscolar();
            iCom_BusinessEntity.PeriodoEscolar oBE = new iCom_BusinessEntity.PeriodoEscolar();


            if (Application["idperiodo"].ToString() == "0")
            {
                // Nuevo
                oBE.idperiodo = int.Parse(rblMes.SelectedValue.ToString());
                oBE.anio = int.Parse(ddlAnio.SelectedValue.ToString());
                oBE.periodoescolar = rblMes.SelectedItem.ToString() + " " + ddlAnio.SelectedItem.Value;

                dtDatos = oBLPeriodo.Insertar(oBE);

                lblMensaje.Text = "Datos guardados.";
            }
            else
            {
                // Existe
                oBE.idperiodoescolar = int.Parse(Application["idperiodo"].ToString());
                oBE.idperiodo = int.Parse(rblMes.SelectedValue.ToString());
                oBE.anio = int.Parse(ddlAnio.SelectedValue.ToString());
                oBE.periodoescolar = rblMes.SelectedItem.ToString() + " " + ddlAnio.SelectedItem.Value;
                oBE.activo = chkActivo.Checked;

                dtDatos = oBLPeriodo.Actualizar(oBE);
                lblMensaje.Text = "Datos modificados.";
            }

            mp1.Show();
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected bool Carga_Datos(int idperiodo)
    {
        iCom_BusinessEntity.PeriodoEscolar oBE = new iCom_BusinessEntity.PeriodoEscolar();
        iCom_BusinessLogic.PeriodoEscolar oBL = new iCom_BusinessLogic.PeriodoEscolar();

        oBE.idperiodoescolar = idperiodo;

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
