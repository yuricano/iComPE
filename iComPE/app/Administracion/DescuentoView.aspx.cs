using iCom_Generales;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

public partial class app_Administracion_DescuentoView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Catalogos();
            Carga_Datos();
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Application["iddescuento"] = "0";
        Response.Redirect("~/app/Administracion/Descuento.aspx");
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Valida())
        {
            iCom_BusinessEntity.Descuento oBE = new iCom_BusinessEntity.Descuento();

            oBE.descuento = txtDescuento.Text;
            oBE.idconcepto = DdlConcepto.SelectedIndex;
            oBE.importe = decimal.Parse(txtImporte.Text);
            oBE.iva = 0;// decimal.Parse(txtIVA.Text);
            oBE.total = 0;
            oBE.porcentaje = decimal.Parse(txtPorcentaje.Text);
            oBE.idperiocidad = ddlPeriocidad.SelectedIndex;
            oBE.duracion = int.Parse(txtDuracion.Text);

            // Fecha 
            string sFecha = ddlAnioI.SelectedItem.ToString() + "-" + ddlMesI.SelectedItem.ToString() + "-" + ddlDiaI.SelectedItem.ToString();
            DateTime fecha = Convert.ToDateTime(sFecha + " 00:00:00.000", CultureInfo.InvariantCulture);
            oBE.fechaini = fecha;

            // Días
            if (ddlPeriocidad.SelectedIndex == 1)
            {
                oBE.fechafin = oBE.fechaini.AddDays(double.Parse(txtDuracion.Text));
            }

            // Meses
            if (ddlPeriocidad.SelectedIndex == 2)
            {
                oBE.fechafin = oBE.fechaini.AddMonths(int.Parse(txtDuracion.Text));
            }

            oBE.activo = true;

            iCom_BusinessLogic.Descuento oBL = new iCom_BusinessLogic.Descuento();

            if (int.Parse(Application["iddescuento"].ToString()) == 0)
            {
                dtDatos = oBL.Insertar(oBE);
            }
            else
            {
                oBE.iddescuento = int.Parse(Application["iddescuento"].ToString());
                oBE.activo = chkActivo.Checked;
                dtDatos = oBL.Actualizar(oBE);
            }

            ResgitraLog("Datos guardados");
            return;
        }
    }

    #region Datos

    // Catalogos
    protected void Carga_Catalogos()
    {
        try
        {
            // Día
            ddlDiaI.Items.Add(new ListItem("Dìa"));

            for (int i = 1; i <= 31; i++)
            {
                ddlDiaI.Items.Add(new ListItem(i.ToString()));
            }

            // Mes
            ddlMesI.Items.Add(new ListItem("Mes"));

            for (int i = 1; i <= 12; i++)
            {
                ddlMesI.Items.Add(new ListItem(i.ToString()));
            }

            // Año
            ddlAnioI.DataSource = Enumerable.Range(System.DateTime.Now.Year, 5).ToList();
            ddlAnioI.DataBind();

            // Concepto
            dtDatos = Filtros.Concepto (0);
            if (dtDatos.Rows.Count > 0)
            {
                DdlConcepto.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    DdlConcepto.Items.Add(new ListItem(row[1].ToString()));
                }
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
        iCom_BusinessEntity.Descuento oBE = new iCom_BusinessEntity.Descuento();
        iCom_BusinessLogic.Descuento oBL = new iCom_BusinessLogic.Descuento();

        try
        {
            oBE.iddescuento = int.Parse(Application["iddescuento"].ToString());
            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                txtDescuento.Text = dtDatos.Rows[0]["descuento"].ToString();
                DdlConcepto.SelectedIndex = int.Parse(dtDatos.Rows[0]["idconcepto"].ToString());
                txtImporte.Text = dtDatos.Rows[0]["importe"].ToString();
                //txtIVA.Text = dtDatos.Rows[0]["iva"].ToString();
                // txtTotal.Text = dtDatos.Rows[0]["total"].ToString();
                txtPorcentaje.Text = dtDatos.Rows[0]["porcentaje"].ToString();
                ddlPeriocidad.SelectedIndex = int.Parse(dtDatos.Rows[0]["idperiocidad"].ToString());
                txtDuracion.Text = dtDatos.Rows[0]["duracion"].ToString();

                string cadena = dtDatos.Rows[0]["fechaini"].ToString();
                string[] partes = cadena.Split('/');
                ddlDiaI.SelectedIndex = int.Parse(partes[0].ToString());
                ddlMesI.SelectedIndex = int.Parse(partes[1].ToString());
                ddlAnioI.SelectedIndex = int.Parse(partes[2].ToString().Substring(0, 4));

                cadena = dtDatos.Rows[0]["fechafin"].ToString();
                partes = cadena.Split('/');
                ddlDiaF.SelectedIndex = int.Parse(partes[0].ToString());
                ddlMesF.SelectedIndex = int.Parse(partes[1].ToString());
                ddlAnioF.SelectedIndex = int.Parse(partes[2].ToString().Substring(0, 4));

                chkActivo.Checked = true;

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
    protected bool Valida()
    {
        if (txtDescuento.Text.Trim() == string.Empty)
        {
            ResgitraLog("Descuento requerido");
            return false;
        }

        if (DdlConcepto.SelectedIndex == 0)
        {
            ResgitraLog("Concepto requerido");
            return false;
        }

        if (txtImporte.Text.Trim() == string.Empty)
        {
            if (txtPorcentaje.Text.Trim() == string.Empty)
            {
                ResgitraLog("Importe requerido");
                return false;
            }
        }
        else
        {
            if (txtPorcentaje.Text.Trim() != string.Empty)
            {
                ResgitraLog("Debes de seleccionar importe o porcentaje, no lo dos");
                return false;
            }
        }

        //if (txtIVA.Text.Trim() == string.Empty)
        //{
        //    ResgitraLog("IVA requerido");
        //    return false;
        //}

        if (txtPorcentaje.Text.Trim() == string.Empty)
        {
            if (txtImporte.Text.Trim() == string.Empty)
            {
                ResgitraLog("Debes de seleccionar importe o porcentaje, no lo dos");
                return false;
            }
        }
        else
        {
            if (txtImporte.Text.Trim() != string.Empty)
            {
                ResgitraLog("Debes de seleccionar importe o porcentaje, no lo dos");
                return false;
            }
        }

        if (ddlPeriocidad.SelectedIndex == 0)
        {
            ResgitraLog("Periocidad requerido");
            return false;
        }

        if (txtDuracion.Text.Trim() == string.Empty)
        {
            ResgitraLog("Duración requerido");
            return false;
        }

        if (ddlDiaI.SelectedIndex == 0)
        {
            ResgitraLog("Día inicial requerido");
            return false;
        }

        if (ddlMesI.SelectedIndex == 0)
        {
            ResgitraLog("Mes inicial requerido");
            return false;
        }

        if (txtImporte.Text ==string.Empty)
        {
            txtImporte.Text = "0";
        }

        if (txtPorcentaje.Text == string.Empty)
        {
            txtPorcentaje.Text = "0";
        }

        return true;
    }
    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_DescuentoView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
