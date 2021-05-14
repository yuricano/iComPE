using iCom_Generales;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class app_Administracion_AdminAlumnoView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtFiltro = new DataTable();

    //static int idusuariotipo = 0;
    //static int iddatosgenerales = 0;
    //static int IdUsuarioL = 0;
    //static int IdUsuarioD = 0;

    //static string usuario = string.Empty;
    //static string contrasena = string.Empty;

    static string sConceptos = string.Empty;
    static string sDescuentos = string.Empty;

    static bool bGuardar = true;

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
                        //usuario = dtDatos.Rows[0]["usuario"].ToString();
                        //contrasena = dtDatos.Rows[0]["contrasena"].ToString();

                        //idusuariotipo = int.Parse(dtDatos.Rows[0]["idusuariotipo"].ToString());
                        //iddatosgenerales = int.Parse(dtDatos.Rows[0]["iddatosgenerales"].ToString());
                        //IdUsuarioL = int.Parse(dtDatos.Rows[0]["idusuariolaboral"].ToString());
                        //IdUsuarioD = int.Parse(dtDatos.Rows[0]["idusuariodireccion"].ToString());

                        txtNombre.Text = dtDatos.Rows[0]["nombreU"].ToString() + " " +
                            dtDatos.Rows[0]["appaterno"].ToString() + " " +
                            dtDatos.Rows[0]["apmaterno"].ToString();

                        DdlPeriodo.SelectedIndex = int.Parse(dtDatos.Rows[0]["idperiodoescolar"].ToString());
                        txtMatricula.Text = dtDatos.Rows[0]["matricula"].ToString();
                        DdlCarrera.SelectedIndex = int.Parse(dtDatos.Rows[0]["idcarrera"].ToString());
                    }

                    if (Carga_Historia(int.Parse(Application["idusuario"].ToString())))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            gvDatos.DataSource = dtDatos;
                            gvDatos.DataBind();
                        }
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

            txtMatricula.Focus();
        }
    }

    // Regresar
    protected void BtnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/AdminAlumno.aspx");
    }

    // Guardar
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (!bGuardar)
        {
            ResgitraLog("Datos ya guardados.");
            return;
        }

            // Guarda la cuenta $ del alumno
            try
        {
            iCom_BusinessEntity.Cuenta oBE = new iCom_BusinessEntity.Cuenta();
            iCom_BusinessLogic.Cuenta oBL = new iCom_BusinessLogic.Cuenta();

            oBE.idusuario = int.Parse(Application["idusuario"].ToString());
            oBE.idconcepto = int.Parse((DdlConcepto.SelectedValue.ToString()));
            oBE.importe = decimal.Parse(txtImporte.Text.ToString());
            oBE.iddescuento = int.Parse((DdlDescuento.SelectedValue.ToString()));

            oBE.descuento = Convert.ToDecimal(string.IsNullOrEmpty(txtDescuentoMoneda.Text) ? (decimal?)null : Convert.ToInt32(txtDescuentoMoneda.Text));

            oBE.pctdescuento = Convert.ToDecimal(string.IsNullOrEmpty(txtDescuentoPorcentaje.Text) ? (decimal?)null : Convert.ToInt32(txtDescuentoPorcentaje.Text));

            oBE.total= decimal.Parse(txtTotal.Text.ToString());

            oBL.Insertar(oBE);

            ResgitraLog("Datos guardados");
            BtnGUardar.Enabled = false;
            bGuardar = false;
            return;
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
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
                if (row["idConcepto"].ToString() == idConcepto.ToString())
                {
                    txtTotal.Text = row["importe"].ToString();
                    txtImporte.Text = row["importe"].ToString();
                    Carga_Descuento(idConcepto);
                    return;
                }
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
        // Carga concepto de nuevo
        int idConcepto = int.Parse((DdlConcepto.SelectedValue.ToString()));
        int idDescuento = int.Parse((DdlDescuento.SelectedValue.ToString()));

        var tableC = JsonConvert.DeserializeObject<DataTable>(sConceptos);
        var tableD = JsonConvert.DeserializeObject<DataTable>(sDescuentos);

        try
        {
            foreach (DataRow row in tableC.Rows)
            {
                if (row["idConcepto"].ToString() == idConcepto.ToString())
                {
                    txtTotal.Text = row["importe"].ToString();
                    txtImporte.Text = row["importe"].ToString();
                    break;
                }
            }
            
            foreach (DataRow row in tableD.Rows)
            {
                if (row["iddescuento"].ToString() == idDescuento.ToString())
                {
                    txtDescuentoMoneda.Text = row["importe"].ToString();
                    txtDescuentoPorcentaje.Text = row["porcentaje"].ToString();

                    if (decimal.Parse(txtDescuentoMoneda.Text.ToString()) > 0)
                    {
                        decimal Total = decimal.Parse(txtTotal.Text.ToString());
                        decimal descuento = decimal.Parse(txtDescuentoMoneda.Text.ToString());
                        Total -= descuento;
                        txtTotal.Text = Total.ToString();
                        break;
                    }
                    else
                    {
                        decimal Total = decimal.Parse(txtTotal.Text.ToString());
                        decimal descuento = decimal.Parse(txtDescuentoPorcentaje.Text.ToString());
                        decimal xDescuento = Total * (descuento / 100);
                        Total -= xDescuento;
                        txtTotal.Text = Total.ToString();
                        break;
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

    protected bool Carga_Historia(int idusuario)
    {
        iCom_BusinessEntity.Cuenta oBE = new iCom_BusinessEntity.Cuenta();
        iCom_BusinessLogic.Cuenta oBL = new iCom_BusinessLogic.Cuenta();

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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_AdminAlumnoView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
