using iCom_Generales;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

public partial class app_Administracion_DocumentosView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtFiltro = new DataTable();

    static int idusuariotipo = 0;
    static int iddatosgenerales = 0;

    static string usuario = string.Empty;
    static string contrasena = string.Empty;

    static string sConceptos = string.Empty;
    static string sDescuentos = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Catalogos
            Carga_Catalogos();

            try
            {
                // Existe
                if (Application["idusuario"].ToString() != "0")
                {
                    if (Carga_Datos(int.Parse(Application["idusuario"].ToString())))
                    {                        
                        idusuariotipo = int.Parse(dtDatos.Rows[0]["idusuariotipo"].ToString());
                        iddatosgenerales = int.Parse(dtDatos.Rows[0]["iddatosgenerales"].ToString());

                        DdlPeriodo.SelectedIndex = int.Parse(dtDatos.Rows[0]["idperiodoescolar"].ToString());
                        DdlCarrera.SelectedIndex = int.Parse(dtDatos.Rows[0]["idcarrera"].ToString());

                        string[] allfiles = System.IO.Directory.GetFiles("~/app/", "*.*", System.IO.SearchOption.AllDirectories);

                        TreeNode mainNode = new TreeNode();
                        mainNode.Text = "Main";
                        TreeView1.Nodes.Add(mainNode);
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
    }

    // Regresar
    protected void BtnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Documentos.aspx");
    }

    // Guardar
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {

        ResgitraLog("Datos guardados");
        return;
    }

    protected void DdlIngresoEgreso_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlConcepto.Items.Clear();

        if (int.Parse(DdlIngresoEgreso.SelectedValue.ToString()) == -1)
        {
            ResgitraLog("Selecciona Ingreo o Egreso");
            DdlIngresoEgreso.Focus();
            return;
        }

        try
        {
            iCom_BusinessEntity.Concepto oBE = new iCom_BusinessEntity.Concepto();
            iCom_BusinessLogic.Concepto oBL = new iCom_BusinessLogic.Concepto();

            oBE.tipo = false;

            if (DdlIngresoEgreso.SelectedValue.ToString() == "0")
            {
                oBE.ingresoegreso = false;
            }
            else
            {
                oBE.ingresoegreso = true;
            }

            dtFiltro = oBL.ConsultarConceptoIE(oBE);

            if (dtFiltro.Rows.Count > 0)
            {
                DdlConcepto.DataSource = dtFiltro;
                DdlConcepto.DataTextField = "nombreconcepto";
                DdlConcepto.DataValueField = "idconcepto";
                DdlConcepto.DataBind();

                // Lo convierto a JSON
                sConceptos = DataTableToJSONWithJSONNet(dtFiltro);
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void DdlConcepto_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idConcepto = int.Parse((DdlConcepto.SelectedValue.ToString()));

        var table = JsonConvert.DeserializeObject<DataTable>(sConceptos);

        try
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["idconcepto"].ToString() == idConcepto.ToString())
                {
                    txtImporte.Text = row["importe"].ToString();
                    //txtIVA.Text = row["iva"].ToString();

                    decimal Importe = decimal.Parse(txtImporte.Text.ToString());

                    txtTotal.Text = Importe.ToString();
                }

                Carga_Descuento(idConcepto);
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void DdlDescuento_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idDescuento = int.Parse((DdlDescuento.SelectedValue.ToString()));

        var table = JsonConvert.DeserializeObject<DataTable>(sDescuentos);

        try
            {
            foreach (DataRow row in table.Rows)
            {
                if (row["iddescuento"].ToString() == idDescuento.ToString())
                {
                    txtDescuentoMoneda.Text = row["importe"].ToString();
                    txtDescuentoPorcentaje.Text = row["porcentaje"].ToString();
                    //txtIVA.Text = row["iva"].ToString();

                    if (decimal.Parse(txtDescuentoMoneda.Text.ToString()) > 0)
                    {
                        decimal Total = decimal.Parse(txtTotal.Text.ToString());
                        decimal descuento = decimal.Parse(txtDescuentoMoneda.Text.ToString());
                        Total -= descuento;
                        txtTotal.Text = Total.ToString();
                    }
                    else
                    {
                        decimal Total = decimal.Parse(txtTotal.Text.ToString());
                        decimal descuento = decimal.Parse(txtDescuentoPorcentaje.Text.ToString());
                        decimal xDescuento = Total * (descuento / 100);
                        Total -= xDescuento;
                        txtTotal.Text = Total.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    #region Datos
    protected bool Carga_Datos(int idusuario)
    {
        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

        oBE.idusuario = idusuario;

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

    // Catalogos
    protected void Carga_Catalogos()
    {
        try
        {
            // Carrera
            dtDatos = Filtros.Carrera(0);
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
            if (dtDatos.Rows.Count > 0)
            {
                DdlPeriodo.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    DdlPeriodo.Items.Add(new ListItem(row[3].ToString()));
                }
            }

            // Ingreso Egreso
            DdlIngresoEgreso.Items.Clear();

            iCom_BusinessLogic.Concepto oBL = new iCom_BusinessLogic.Concepto();

            dtFiltro = oBL.ConsultarIE();

            if (dtFiltro.Rows.Count > 0)
            {
                DdlIngresoEgreso.DataSource = dtFiltro;
                DdlIngresoEgreso.DataTextField = "IE";
                DdlIngresoEgreso.DataValueField = "id";
                DdlIngresoEgreso.DataBind();
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void Carga_Descuento(int idConcepto)
    {
        DdlDescuento.Items.Clear();

        iCom_BusinessEntity.Descuento oBE = new iCom_BusinessEntity.Descuento();
        iCom_BusinessLogic.Descuento oBL = new iCom_BusinessLogic.Descuento();

        oBE.idconcepto = idConcepto;

        try
        {
            dtDatos = oBL.ConsultarDescuentoConcepto(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                DdlDescuento.DataSource = dtDatos;
                DdlDescuento.DataTextField = "nombreconcepto";
                DdlDescuento.DataValueField = "iddescuento";
                DdlDescuento.DataBind();

                // Lo convierto a JSON
                sDescuentos = DataTableToJSONWithJSONNet(dtDatos);
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
 
    // DT a JSON
    public string DataTableToJSONWithJSONNet(DataTable table)
    {
        try
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return null;
        }
    }
    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_DocumentosView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
