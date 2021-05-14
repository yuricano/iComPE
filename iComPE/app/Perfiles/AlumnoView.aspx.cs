using iCom_Generales;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class app_Alumno_AlumnoView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtFiltro = new DataTable();

    static int idusuariotipo = 0;
    static int iddatosgenerales = 0;
    static int IdUsuarioL = 0;
    static int IdUsuarioD = 0;

    static string usuario = string.Empty;
    static string contrasena = string.Empty;

    void Page_PreInit(object sender, EventArgs e)
    {
        // NULL
        if (Application["admin"] == null)
        {
            Response.Redirect("~/app/Login/Login.aspx");
            return;
        }

        if (Application["admin"].ToString() == "1")
        {
            MasterPageFile = "~/Admin.master";
        }
    }

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
                        usuario = dtDatos.Rows[0]["usuario"].ToString();
                        contrasena = dtDatos.Rows[0]["contrasena"].ToString();
                        
                        idusuariotipo = int.Parse(dtDatos.Rows[0]["idusuariotipo"].ToString());
                        iddatosgenerales = int.Parse(dtDatos.Rows[0]["iddatosgenerales"].ToString());
                        IdUsuarioL = int.Parse(dtDatos.Rows[0]["idusuariolaboral"].ToString());
                        IdUsuarioD = int.Parse(dtDatos.Rows[0]["idusuariodireccion"].ToString());

                        if (Application["admin"].ToString() == "1")
                        {
                            chkActivo.Visible = true;
                        }
                        else
                        {
                            chkActivo.Visible = false;
                        }

                        txtNombre.Text = dtDatos.Rows[0]["nombreU"].ToString();
                        txtApPaterno.Text = dtDatos.Rows[0]["appaterno"].ToString();
                        txtApMaterno.Text = dtDatos.Rows[0]["apmaterno"].ToString();
                        ddlModelo.SelectedIndex = int.Parse(dtDatos.Rows[0]["idmodeloeducativo"].ToString());
                        DdlPeriodo.SelectedIndex = int.Parse(dtDatos.Rows[0]["idperiodoescolar"].ToString());
                        txtMatricula.Text = dtDatos.Rows[0]["matricula"].ToString();
                        DdlCarrera.SelectedIndex = int.Parse(dtDatos.Rows[0]["idcarrera"].ToString());

                        string cadena = dtDatos.Rows[0]["fechanacimiento"].ToString();
                        string[] partes = cadena.Split('/');

                        ddlDia.SelectedIndex = int.Parse(partes[0].ToString());
                        ddlMes.SelectedIndex = int.Parse(partes[1].ToString());
                        txtAnio.Text = partes[2].ToString().Substring(0, 4);

                        txtNacionalidad.Text = dtDatos.Rows[0]["nacionalidad"].ToString();
                        txtTelContacto.Text = dtDatos.Rows[0]["telefono"].ToString();
                        txtCorreo.Text = dtDatos.Rows[0]["email"].ToString();

                        rblSexo.SelectedValue = dtDatos.Rows[0]["idsexo"].ToString();
                        rblEdoCivil.SelectedValue = dtDatos.Rows[0]["idestadocivil"].ToString();

                        txtCURP.Text = dtDatos.Rows[0]["curp"].ToString();
                        txtEscuelaProcedencia.Text = dtDatos.Rows[0]["escuelaprocedencia"].ToString();

                        txtCalle.Text = dtDatos.Rows[0]["calle"].ToString();
                        txtNumero.Text = dtDatos.Rows[0]["numeroexterior"].ToString();
                        txtNumeroInt.Text = dtDatos.Rows[0]["numerointerior"].ToString();
                        txtColonia.Text = dtDatos.Rows[0]["colonia"].ToString();

                        // Pais
                        ddlPais.SelectedIndex = int.Parse(dtDatos.Rows[0]["idpais"].ToString());

                        // Estado
                        Carga_Estado(int.Parse(dtDatos.Rows[0]["idpais"].ToString()));
                        ddlEstado.SelectedIndex = int.Parse(dtDatos.Rows[0]["idestado"].ToString());

                        // Ciudad
                        Carga_Ciudad(int.Parse(dtDatos.Rows[0]["idestado"].ToString()));
                        ddlCiudad.SelectedValue = dtDatos.Rows[0]["idciudad"].ToString();

                        txtCP.Text = dtDatos.Rows[0]["codigopostal"].ToString();

                        if (dtDatos.Rows[0]["labora"].ToString() == "True")
                        {
                            rblLaboral.SelectedIndex = 1;
                        }
                        else
                        {
                            rblLaboral.SelectedIndex = 0;
                        }

                        txtEmpresaLaaboral.Text = dtDatos.Rows[0]["nombreempresa"].ToString();
                        txtPuestoLaboral.Text = dtDatos.Rows[0]["puesto"].ToString();
                        txtTelLaboral.Text = dtDatos.Rows[0]["tellaboral"].ToString();
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
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Application["admin"].ToString() == "1")
        {
            Response.Redirect("~/app/Administracion/Alumno.aspx");
        }
        else
        {
            Response.Redirect("~/app/Alumno/Alumno.aspx");
        }
        
    }

    // Guardar
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int idusuario = int.Parse(Application["idusuario"].ToString());

        try
        {
            // Baja Usuario
            if (chkActivo.Checked == false)
            {
                iCom_BusinessEntity.Usuario oBEU = new iCom_BusinessEntity.Usuario();

                oBEU.idusuario = idusuario;
                oBEU.usuario = usuario;
                oBEU.contrasena = contrasena;
                oBEU.idusuariotipo = idusuariotipo;
                oBEU.activo = false;

                iCom_BusinessLogic.Usuario oBLU = new iCom_BusinessLogic.Usuario();
                dtDatos = oBLU.Actualizar(oBEU);

                lblMensaje.Text = "Se dío de baja al alumno.";
                mp1.Show();
                btnGUardar.Enabled = false;
                return;
            }

            // Datos generales
            iCom_BusinessEntity.UsuarioDatosGenerales oBEDG = new iCom_BusinessEntity.UsuarioDatosGenerales();

            oBEDG.iddatosgenerales = iddatosgenerales;
            oBEDG.idusuario = idusuario;

            oBEDG.nombre = txtNombre.Text;
            oBEDG.appaterno = txtApPaterno.Text;
            oBEDG.apmaterno = txtApMaterno.Text;
            oBEDG.idmodeloeducativo = 1;
            oBEDG.idperiodoescolar = DdlPeriodo.SelectedIndex;
            oBEDG.matricula = txtMatricula.Text;
            oBEDG.idcarrera = DdlCarrera.SelectedIndex;
            // Fecha Nac
            string sFecha = txtAnio.Text + "-" + ddlMes.SelectedItem.ToString() + "-" + ddlDia.SelectedItem.ToString();
            DateTime fecha = Convert.ToDateTime(sFecha + " 00:00:00.000", CultureInfo.InvariantCulture);
            oBEDG.fechanacimiento = fecha;

            oBEDG.nacionalidad = txtNacionalidad.Text;
            oBEDG.telefono = txtTelContacto.Text;
            oBEDG.email = txtCorreo.Text;
            oBEDG.idsexo = int.Parse(rblSexo.SelectedValue.ToString());
            oBEDG.idestadocivil = int.Parse(rblEdoCivil.SelectedValue.ToString());
            oBEDG.curp = txtCURP.Text;
            oBEDG.escuelaprocedencia = txtEscuelaProcedencia.Text;

            iCom_BusinessLogic.UsuarioDatosGenerales oBLUG = new iCom_BusinessLogic.UsuarioDatosGenerales();
            dtDatos = oBLUG.Actualizar(oBEDG);

            // Datos Direccion
            iCom_BusinessEntity.UsuarioDireccion oBEDir = new iCom_BusinessEntity.UsuarioDireccion();

            oBEDir.idusuariodireccion = IdUsuarioD;
            oBEDir.idusuario = idusuario;
            oBEDir.idusuariopadres = 0;
            oBEDir.calle = txtCalle.Text;
            oBEDir.numeroexterior = txtNumero.Text;
            oBEDir.numerointerior = txtNumeroInt.Text;
            oBEDir.colonia = txtColonia.Text;
            oBEDir.codigopostal = txtCP.Text;
            oBEDir.idpais = ddlPais.SelectedIndex;
            oBEDir.idestado = ddlEstado.SelectedIndex;
            oBEDir.idciudad = int.Parse(ddlCiudad.SelectedValue.ToString());

            iCom_BusinessLogic.UsuarioDireccion oBLDir = new iCom_BusinessLogic.UsuarioDireccion();
            dtDatos = oBLDir.Actualizar(oBEDir);

            // Laboral
            iCom_BusinessEntity.UsuarioLaboral oBEL = new iCom_BusinessEntity.UsuarioLaboral();
            oBEL.idusuariolaboral = IdUsuarioL;
            oBEL.idusuario = idusuario;

            if (int.Parse(rblLaboral.SelectedValue.ToString()) == 0)
            {
                oBEL.labora = false;
            } else
            {
                oBEL.labora = true;
            }

            oBEL.nombreempresa = txtEmpresaLaaboral.Text;
            oBEL.puesto = txtPuestoLaboral.Text;
            oBEL.telefono = txtTelLaboral.Text;

            iCom_BusinessLogic.UsuarioLaboral oBLL = new iCom_BusinessLogic.UsuarioLaboral();
            dtDatos = oBLL.Actualizar(oBEL);    

            lblMensaje.Text = "Datos modificados.";
            mp1.Show();
            return;
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
            // Día
            ddlDia.Items.Add(new ListItem("Dìa"));

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

            // Modelo
            dtDatos = Filtros.ModeloEducativo(0);
            if (dtDatos.Rows.Count > 0)
            {
                ddlModelo.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    ddlModelo.Items.Add(new ListItem(row[1].ToString()));
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

            // Pais
            dtDatos = Filtros.Pais(0);
            if (dtDatos.Rows.Count > 0)
            {
                ddlPais.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    ddlPais.Items.Add(new ListItem(row[1].ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected bool Carga_Estado(int idPais)
    {
        DataTable dtEstado = new DataTable();
        ddlEstado.Items.Clear();

        dtEstado = Filtros.Estado(0, idPais);
        if (dtEstado.Rows.Count > 0)
        {
            ddlEstado.Items.Add(new ListItem("Selecciona"));
            foreach (DataRow row in dtEstado.Rows)
            {
                ddlEstado.Items.Add(new ListItem(row[2].ToString()));
            }
        }
        return true;
    }

    protected bool Carga_Ciudad(int idEstado)
    {
        ddlCiudad.Items.Clear();

        try
        {
            dtFiltro = Filtros.Ciudad(0, ddlEstado.SelectedIndex);

            if (dtFiltro.Rows.Count > 0)
            {
                ddlCiudad.DataSource = dtFiltro;
                ddlCiudad.DataTextField = "ciudad";
                ddlCiudad.DataValueField = "idciudad";
                ddlCiudad.DataBind();
                ddlCiudad.Focus();
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return false;
        }

        return true;
    }
    
    protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEstado.Items.Clear();
        ddlCiudad.Items.Clear();

        try
        {
            dtFiltro = Filtros.Estado(0, ddlPais.SelectedIndex);
            if (dtFiltro.Rows.Count > 0)
            {
                ddlEstado.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtFiltro.Rows)
                {
                    ddlEstado.Items.Add(new ListItem(row[2].ToString()));
                }
            }

            ddlEstado.Focus();
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCiudad.Items.Clear();

        try
        {
            dtFiltro = Filtros.Ciudad(0, ddlEstado.SelectedIndex);
            if (dtFiltro.Rows.Count > 0)
            {
                ddlCiudad.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtFiltro.Rows)
                {
                    ddlCiudad.Items.Add(new ListItem(row[2].ToString()));
                }
            }

            ddlCiudad.Focus();
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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_AlumnoView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
