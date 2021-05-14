using iCom_Generales;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

public partial class app_Administracion_Calendario : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Application["idcalendario"] = "0";
            Carga_Catalogos();
        }
    }

    #region Proc
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Valida())
            {
                iCom_BusinessEntity.Calendario oBE = new iCom_BusinessEntity.Calendario();
                oBE.idcalendario = int.Parse(Application["idcalendario"].ToString());

                // Fecha 
                string sFecha = ddlAnio.SelectedItem.ToString() + "-" + ddlMes.SelectedItem.ToString() + "-" + ddlDia.SelectedItem.ToString();
                DateTime fecha = Convert.ToDateTime(sFecha + " 00:00:00.000", CultureInfo.InvariantCulture);
                oBE.fecha = fecha;

                oBE.evento = txtEvento.Text.Trim();
                if (chkActivo.Checked == true)
                {
                    oBE.activo = true;
                }
                else
                {
                    oBE.activo = false;
                }

                iCom_BusinessLogic.Calendario oBL = new iCom_BusinessLogic.Calendario();

                if (oBE.idcalendario == 0)
                {
                    dtDatos = oBL.Insertar(oBE);
                }
                else
                {
                    dtDatos = oBL.Actualizar(oBE);
                }

                ResgitraLog("Datos guardados");
                Calendar1.SelectedDate = DateTime.Now.Date;
                Application["idcalendario"] = "0";
                return;
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Application["idcalendario"] = null;
        Response.Redirect("~/app/Administracion/Admin.aspx");
    }
    #endregion

    #region Datos
    protected bool Valida()
    {
        if (txtEvento.Text.Trim() == string.Empty)
        {
            ResgitraLog("Evento requerido");
            return false;
        }
            
        if (ddlDia.SelectedIndex == 0)
        {
            ResgitraLog("Día requerido");
            return false;
        }

        if (ddlMes.SelectedIndex == 0)
        {
            ResgitraLog("Mes requerido");
            return false;
        }
        return true;
    }

    // Calendario
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        string cadena = Calendar1.SelectedDate.ToString().Substring(0, 10);
        string[] partes = cadena.Split('/');

        try
        {

            ddlDia.SelectedIndex = int.Parse(partes[0].ToString());
            ddlMes.SelectedIndex = int.Parse(partes[1].ToString());
            ddlAnio.SelectedValue = partes[2].ToString().Substring(0, 4);
            txtEvento.Text = string.Empty;

            foreach (DataRow row in dtDatos.Rows)
            {
                if (row[1].ToString().Contains(cadena))
                {
                    txtEvento.Text = row[2].ToString();
                    Application["idcalendario"] = int.Parse(row[0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        Calendar1.SelectedDates.Clear();

        try
        {
            iCom_BusinessEntity.Calendario oBE = new iCom_BusinessEntity.Calendario();
            iCom_BusinessLogic.Calendario oBL = new iCom_BusinessLogic.Calendario();
            dtDatos = oBL.Consultar(oBE);

            foreach (DataRow row in dtDatos.Rows)
            {
                if (row[1].ToString().Contains(e.Day.Date.ToString()) == true)
                {
                    Label lbl = new Label();
                    lbl.Text = "<br/>" + row[2].ToString();
                    e.Cell.Controls.Add(lbl);
                }
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    // Catalogos
    protected void Carga_Catalogos()
    {
        try
        {
            // Día
            ddlDia.Items.Add(new ListItem("Día"));

            for (int i = 1; i <= 31; i++)
            {
                ddlDia.Items.Add(new ListItem(i.ToString()));
            }

            // Mes
            ddlMes.Items.Add(new ListItem("Mes"));

            for (int i = 1; i <= 12; i++)
            {
                ddlMes.Items.Add(new ListItem(i.ToString()));
            }

            // Anio
            ddlAnio.Items.Add(new ListItem("Año"));
            ddlAnio.DataSource = Enumerable.Range(System.DateTime.Now.Year, 5).ToList();
            ddlAnio.DataBind();
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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_Calendario", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
