using System;
using System.Data;
using iCom_Generales;

public partial class app_Administracion_ConceptoView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Datos();
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Application["idconcepto"] = "0";
        Response.Redirect("~/app/Administracion/Concepto.aspx");
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Valida())
        {
            iCom_BusinessEntity.Concepto oBE = new iCom_BusinessEntity.Concepto();

            oBE.nombreconcepto = txtConcepto.Text;
            oBE.abreviatura = txtAbreviatura.Text;
            oBE.descripcion = txtDecripcion.Text;
            oBE.importe = decimal.Parse(txtImporte.Text);
            oBE.iva = 0; //decimal.Parse(txtIVA.Text);
            oBE.diasvencimiento = int.Parse(txtDiasVencimiento.Text);
            
            if (rblPagoAnticipado.SelectedIndex == 0)
            {
                oBE.porcentajepagoanticipado = int.Parse(txtValorDesc.Text);
            }
            else
            {
                oBE.fijopagoanticipado = decimal.Parse(txtValorDesc.Text);
            }

            if (rblMora.SelectedIndex == 0)
            {
                oBE.porcentajerecargomora = int.Parse(txtValorRecargo.Text);
            }
            else
            {
                oBE.fijorecargomora = decimal.Parse(txtValorRecargo.Text);
            }

            switch (rblAplicadoA.SelectedIndex)
            {
                case 0:
                    oBE.aplicadoimportedia = true;
                    break;

                case 1:
                    oBE.aplicadoimportemes = true;
                    break;

                case 2:
                    oBE.aplicadoimporte = true;
                    break;
            }

            if (rblIE.SelectedIndex == 0)
            {
                oBE.ingresoegreso = false;
            }
            else
            {
                oBE.ingresoegreso = true;
            }

            oBE.activo = chkActivo.Checked;

            iCom_BusinessLogic.Concepto oBL = new iCom_BusinessLogic.Concepto();

            if (int.Parse(Application["idconcepto"].ToString()) == 0)
            {
                dtDatos = oBL.Insertar(oBE);
            }
            else
            {
                oBE.idconcepto = int.Parse(Application["idconcepto"].ToString());
                dtDatos = oBL.Actualizar(oBE);
            }

            ResgitraLog("Datos guardados");
            return;
        }
    }

    #region Datos

    protected void Carga_Datos()
    {
        iCom_BusinessEntity.Concepto oBE = new iCom_BusinessEntity.Concepto();
        iCom_BusinessLogic.Concepto oBL = new iCom_BusinessLogic.Concepto();

        try
        {
            oBE.idconcepto = int.Parse(Application["idconcepto"].ToString());
            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                txtConcepto.Text = dtDatos.Rows[0]["nombreconcepto"].ToString();
                txtAbreviatura.Text = dtDatos.Rows[0]["abreviatura"].ToString();

                if (dtDatos.Rows[0]["ingresoegreso"].ToString() == "False")
                {
                    rblIE.SelectedIndex = 0;
                }
                else
                {
                    rblIE.SelectedIndex = 1;
                }

                txtDecripcion.Text = dtDatos.Rows[0]["descripcion"].ToString();
                txtImporte.Text = dtDatos.Rows[0]["importe"].ToString();
                //txtIVA.Text = dtDatos.Rows[0]["iva"].ToString();
                txtDiasVencimiento.Text = dtDatos.Rows[0]["diasvencimiento"].ToString();

                if (dtDatos.Rows[0]["porcentajepaanticipado"].ToString() != "0")
                {
                    rblPagoAnticipado.SelectedIndex = 0;
                    txtValorDesc.Text = dtDatos.Rows[0]["porcentajepaanticipado"].ToString();
                }
                else
                {
                    rblPagoAnticipado.SelectedIndex = 1;
                    txtValorDesc.Text = dtDatos.Rows[0]["fijopaanticipado"].ToString();
                }

                if (dtDatos.Rows[0]["porcentajerecarmora"].ToString() != "0")
                {
                    rblMora.SelectedIndex = 0;
                    txtValorRecargo.Text = dtDatos.Rows[0]["porcentajerecarmora"].ToString();
                }
                else
                {
                    rblMora.SelectedIndex = 1;
                    txtValorRecargo.Text = dtDatos.Rows[0]["fijorecarmora"].ToString();
                }

                if (dtDatos.Rows[0]["aplicadoimportedia"].ToString() == "True")
                {
                    rblAplicadoA.SelectedIndex = 0;
                }

                if (dtDatos.Rows[0]["aplicadoimportemes"].ToString() == "True")
                {
                    rblAplicadoA.SelectedIndex = 1;
                }

                if (dtDatos.Rows[0]["aplicadoimporte"].ToString() == "True")
                {
                    rblAplicadoA.SelectedIndex = 2;
                }
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
        if (txtConcepto.Text.Trim() == string.Empty) 
        {
            ResgitraLog("Concepto requerido");
            return false;
        }

        if (txtAbreviatura.Text.Trim() == string.Empty)
        {
            ResgitraLog("Abreviatura requerido");
            return false;
        }

        if (txtDecripcion.Text.Trim() == string.Empty)
        {
            ResgitraLog("Descripción requerido");
            return false;
        }

        if (txtImporte.Text.Trim() == string.Empty)
        {
            ResgitraLog("Importe requerido");
            return false;
        }

        //if (txtIVA.Text.Trim() == string.Empty)
        //{
        //    ResgitraLog("IVA requerido");
        //    return false;
        //}

        if (txtDiasVencimiento.Text.Trim() == string.Empty)
        {
            ResgitraLog("Vencimiento requerido");
            return false;
        }

        return true;
    }
    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_ConceptoView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
