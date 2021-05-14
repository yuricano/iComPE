using iCom_Generales;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

public partial class app_Administracion_MensajeView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtUsuario = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Catalogos();

            // Existe
            if (Application["idmensaje"].ToString() != "0")
            {
                try
                {
                    if (Carga_Datos(int.Parse(Application["idmensaje"].ToString())))
                    {
                        ddlUsuarioTipo.SelectedIndex = int.Parse(dtDatos.Rows[0]["idtipousuario"].ToString());
                        ddlUsuarioTipo.Enabled = false;

                        if (int.Parse(dtDatos.Rows[0]["idusuario"].ToString()) > 0)
                        {
                            Carga_Usuarios();
                            ddlUsuario.SelectedIndex = int.Parse(dtDatos.Rows[0]["idusuario"].ToString());
                        }

                        txtMensaje.Text= dtDatos.Rows[0]["mensaje"].ToString();

                        string cadena = dtDatos.Rows[0]["fechainicio"].ToString();
                        string[] partes = cadena.Split('/');
                        ddlDiaIni.SelectedIndex = int.Parse(partes[0].ToString());
                        ddlMesIni.SelectedIndex = int.Parse(partes[1].ToString());
                        ddlAnioIni.SelectedIndex = int.Parse(partes[2].ToString().Substring(0,4));

                        cadena = dtDatos.Rows[0]["fechafin"].ToString();
                        partes = cadena.Split('/');
                        ddlDiaFin.SelectedIndex = int.Parse(partes[0].ToString());
                        ddlMesFin.SelectedIndex = int.Parse(partes[1].ToString());
                        ddlAnioFin.SelectedIndex = int.Parse(partes[2].ToString().Substring(0,4));
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
        Application["idusuario"] = "0";
        Response.Redirect("~/app/Administracion/Mensaje.aspx");
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Valida())
        {
            return;
        }

        // Nuevo
        try
        {
            if (Application["idmensaje"].ToString() == "0")
            {
                // Gurda datos
                iCom_BusinessEntity.Mensaje oBE = new iCom_BusinessEntity.Mensaje();
                iCom_BusinessLogic.Mensaje oBL = new iCom_BusinessLogic.Mensaje();

                oBE.idusuario = int.Parse(ddlUsuario.SelectedItem.Value.ToString());
                oBE.idtipousuario = ddlUsuarioTipo.SelectedIndex;
                oBE.mensaje = txtMensaje.Text.Trim();
                oBE.fechainicio = DateTime.Parse(ddlDiaIni.SelectedItem.ToString() + "/" + ddlMesIni.SelectedItem.ToString() + "/" + ddlAnioIni.SelectedItem.ToString());
                oBE.fechafin = DateTime.Parse(ddlDiaFin.SelectedItem.ToString() + "/" + ddlMesFin.SelectedItem.ToString() + "/" + ddlAnioFin.SelectedItem.ToString());
                dtDatos = oBL.Insertar(oBE);

                ResgitraLog("Datos guardados.");
            } else
            {
                // Gurda datos
                iCom_BusinessEntity.Mensaje oBE = new iCom_BusinessEntity.Mensaje();
                iCom_BusinessLogic.Mensaje oBL = new iCom_BusinessLogic.Mensaje();

                oBE.idmensaje = int.Parse(Application["idmensaje"].ToString());
                oBE.idusuario = int.Parse(ddlUsuario.SelectedItem.Value.ToString());
                oBE.idtipousuario = ddlUsuarioTipo.SelectedIndex;
                oBE.mensaje = txtMensaje.Text.Trim();
                oBE.fechainicio = DateTime.Parse(ddlDiaIni.SelectedItem.ToString() + "/" + ddlMesIni.SelectedItem.ToString() + "/" + ddlAnioIni.SelectedItem.ToString());
                oBE.fechafin = DateTime.Parse(ddlDiaFin.SelectedItem.ToString() + "/" + ddlMesFin.SelectedItem.ToString() + "/" + ddlAnioFin.SelectedItem.ToString());
                oBE.activo = chkActivo.Checked;

                dtDatos = oBL.Actualizar(oBE);

                ResgitraLog("Datos actualizados.");
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
        DateTime fIni;
        DateTime fFin;

        if (ddlUsuarioTipo.SelectedIndex == 0)
        {
            ResgitraLog("Debes de seleccionar al menos un tipo de usuario.");
            return false;
        }

        if (ddlDiaIni.SelectedIndex == 0)
        {
            ResgitraLog("Día inicial requerido");
            return false;
        }

        if (ddlMesIni.SelectedIndex == 0)
        {
            ResgitraLog("Mes inicial requerido");
            return false;
        }

        if (ddlDiaFin.SelectedIndex == 0)
        {
            ResgitraLog("Día final requerido");
            return false;
        }

        if (ddlMesFin.SelectedIndex == 0)
        {
            ResgitraLog("Mes final requerido");
            return false;
        }

        if (txtMensaje.Text.Trim() == "")
        {
            ResgitraLog("Mensaje requerido");
            return false;
        }

        fIni = DateTime.Parse(ddlDiaIni.SelectedItem.ToString() + "/" + ddlMesIni.SelectedItem.ToString() + "/" + ddlAnioIni.SelectedItem.ToString());
        fFin = DateTime.Parse(ddlDiaFin.SelectedItem.ToString() + "/" + ddlMesFin.SelectedItem.ToString() + "/" + ddlAnioFin.SelectedItem.ToString());

        if (fIni > fFin)
        {
            ResgitraLog("Fecha inical no puede ser mayor a fecha final.");
            return false;
        }

        return true;
    }

    protected void ddlUsuarioTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Carga_Usuarios();
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    #region datos
    protected bool Carga_Datos(int idmensaje)
    {
        iCom_BusinessEntity.Mensaje oBE = new iCom_BusinessEntity.Mensaje();
        iCom_BusinessLogic.Mensaje oBL = new iCom_BusinessLogic.Mensaje();

        oBE.idmensaje = idmensaje;

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

    // Usuarios
    protected void Carga_Usuarios()
    {
        ddlUsuario.Items.Clear();

        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

        try
        {
            oBE.idusuario = 0;
            oBE.idusuariotipo = ddlUsuarioTipo.SelectedIndex;

            dtUsuario = oBL.Consultar(oBE);

            if (dtUsuario.Rows.Count > 0)
            {
                ddlUsuario.DataTextField = "nombre";
                ddlUsuario.DataValueField = "idusuario";
                ddlUsuario.DataSource = dtUsuario;
                ddlUsuario.DataBind();

                ddlUsuario.Items.Insert(0, new ListItem("Selecciona", "0"));
            }

            return;
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    // Usuario
    protected bool Carga_Usuario(int idusuario)
    {
        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

        oBE.idusuario = idusuario;

        try
        {
            dtUsuario = oBL.Consultar(oBE);

            if (dtUsuario.Rows.Count > 0)
            {
                ddlUsuario.SelectedIndex = int.Parse(dtUsuario.Rows[0]["idusuario"].ToString());
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
            // Tipo de usuario
            iCom_BusinessEntity.UsuarioTipo oBE = new iCom_BusinessEntity.UsuarioTipo();
            iCom_BusinessLogic.UsuarioTipo oBL = new iCom_BusinessLogic.UsuarioTipo();

            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                ddlUsuarioTipo.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    ddlUsuarioTipo.Items.Add(new ListItem(row[1].ToString()));
                }
            }
            
            // Día
            ddlDiaIni.Items.Add(new ListItem("Día"));
            ddlDiaFin.Items.Add(new ListItem("Día"));

            for (int i = 1; i <= 31; i++)
            {
                ddlDiaIni.Items.Add(new ListItem(i.ToString()));
                ddlDiaFin.Items.Add(new ListItem(i.ToString()));
            }

            // Mes
            ddlMesIni.Items.Add(new ListItem("Mes"));
            ddlMesFin.Items.Add(new ListItem("Mes"));

            for (int i = 1; i <= 12; i++)
            {
                ddlMesIni.Items.Add(new ListItem(i.ToString()));
                ddlMesFin.Items.Add(new ListItem(i.ToString()));
            }

            // Anio
            ddlAnioIni.Items.Add(new ListItem("Año"));
            ddlAnioFin.Items.Add(new ListItem("Año"));

            ddlAnioIni.DataSource = Enumerable.Range(System.DateTime.Now.Year, 5).ToList();
            ddlAnioFin.DataSource = Enumerable.Range(System.DateTime.Now.Year, 5).ToList();

            ddlAnioIni.DataBind();
            ddlAnioFin.DataBind();
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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Administracion_MensajeView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
