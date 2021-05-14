using iCom_Generales;
using System;
using System.Data;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;

public partial class app_Docente_DocenteView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtFiltro = new DataTable();
    static DataTable dtDocente = new DataTable();

    static int idusuariotipo = 0;
    static int iddatosgenerales = 0;
    static int IdUsuarioL = 0;
    static int IdUsuarioD = 0;
    static int idusuarioacademica = 0;

    static string usuario = string.Empty;
    static string contrasena = string.Empty;

    static bool bGuarda = true;

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
                        idusuarioacademica = int.Parse(dtDatos.Rows[0]["idusuarioacademica"].ToString());

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

                        // Académica
                        rblTipoDocente.SelectedValue = dtDatos.Rows[0]["idtipodocente"].ToString();
                        DdlCarrera.SelectedIndex = int.Parse(dtDatos.Rows[0]["idcarrera"].ToString());

                        cadena = dtDatos.Rows[0]["fechaingreso"].ToString();
                        partes = cadena.Split('/');

                        ddlDiaI.SelectedIndex = int.Parse(partes[0].ToString());
                        ddlMesI.SelectedIndex = int.Parse(partes[1].ToString());
                        txtAnioI.Text = partes[2].ToString().Substring(0, 4);
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

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        // Existe
        if (Application["idusuario"].ToString() != "0")
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

                // Académica
                iCom_BusinessEntity.UsuarioAcademica oBEAc= new iCom_BusinessEntity.UsuarioAcademica();

                oBEAc.idusuarioacademica = idusuarioacademica;
                oBEAc.idtipodocente = int.Parse(rblTipoDocente.SelectedValue.ToString());
                oBEAc.idcarrera = DdlCarrera.SelectedIndex;
                sFecha = txtAnio.Text + "-" + ddlMes.SelectedItem.ToString() + "-" + ddlDia.SelectedItem.ToString();
                fecha = Convert.ToDateTime(sFecha + " 00:00:00.000", CultureInfo.InvariantCulture);
                oBEAc.fecingreso = fecha;

                iCom_BusinessLogic.UsuarioAcademica oBLAc = new iCom_BusinessLogic.UsuarioAcademica();
                dtDatos = oBLAc.Actualizar(oBEAc);
            }
            catch (Exception ex)
            {
                ResgitraLog(ex.Message);
                return;
            }
        }
        // Nuevo
        else
        {
            try
            {
                // Creo el nuevo usuario
                int idusuario = 0;

                iCom_BusinessLogic.Usuario oBLUsuario = new iCom_BusinessLogic.Usuario();

                // Obtengo el id
                dtDatos = oBLUsuario.IdUsuario();

                if (dtDatos.Rows.Count > 0)
                {
                    idusuario = int.Parse(dtDatos.Rows[0]["idusuario"].ToString());
                }
                else
                {
                    ResgitraLog("No se obtuvo el ID");
                    return;
                }

                // Alta de Usuario
                iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
                oBE.usuario = "doc" + DateTime.Now.Year.ToString() + idusuario.ToString();
                oBE.contrasena = "12345678";
                oBE.idusuariotipo = 3;

                dtDatos = oBLUsuario.Insertar(oBE);

                // Datos generales
                iCom_BusinessEntity.UsuarioDatosGenerales oBEDG = new iCom_BusinessEntity.UsuarioDatosGenerales();

                oBEDG.idusuario = idusuario;
                oBEDG.nombre = txtNombre.Text;
                oBEDG.appaterno = txtApPaterno.Text;
                oBEDG.apmaterno = txtApMaterno.Text;
                oBEDG.idmodeloeducativo = 1;
                oBEDG.matricula = "doc" + DateTime.Now.Year.ToString() + idusuario.ToString();
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

                iCom_BusinessLogic.UsuarioDatosGenerales oBLUG = new iCom_BusinessLogic.UsuarioDatosGenerales();
                dtDatos = oBLUG.Insertar(oBEDG);

                // Datos Direccion
                iCom_BusinessEntity.UsuarioDireccion oBEDir = new iCom_BusinessEntity.UsuarioDireccion();

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
                dtDatos = oBLDir.Insertar(oBEDir);

                // Laboral
                iCom_BusinessEntity.UsuarioLaboral oBEL = new iCom_BusinessEntity.UsuarioLaboral();

                oBEL.idusuario = idusuario;
                oBEL.labora = false;
                oBEL.nombreempresa = string.Empty;
                oBEL.puesto = string.Empty;
                oBEL.dias = string.Empty;
                oBEL.telefono = string.Empty;

                iCom_BusinessLogic.UsuarioLaboral oBLL = new iCom_BusinessLogic.UsuarioLaboral();
                dtDatos = oBLL.Insertar(oBEL);

                // Académica
                iCom_BusinessEntity.UsuarioAcademica oBEAc = new iCom_BusinessEntity.UsuarioAcademica();

                oBEAc.idusuarioacademica = idusuarioacademica;
                oBEAc.idtipodocente = int.Parse(rblTipoDocente.SelectedValue.ToString());
                oBEAc.idcarrera = DdlCarrera.SelectedIndex;
                sFecha = txtAnio.Text + "-" + ddlMes.SelectedItem.ToString() + "-" + ddlDia.SelectedItem.ToString();
                fecha = Convert.ToDateTime(sFecha + " 00:00:00.000", CultureInfo.InvariantCulture);
                oBEAc.fecingreso = fecha;

                iCom_BusinessLogic.UsuarioAcademica oBLAc = new iCom_BusinessLogic.UsuarioAcademica();
                dtDatos = oBLAc.Insertar(oBEAc);

                // Enviar correo
                if (Application["admin"].ToString() == "1")
                { 
                    string sBody = "Hola, " + txtNombre.Text.ToString() + "\n" +
                    "Tu alta como docente de iCom se ha iniciado exitosamente.\n" + "Saludos!\n" +
                    "usuario: " + oBE.usuario + "\n" + "contraseña: tu fecha de nacimiento en el formato ddmmaaaa";

                    enviarMail(sBody, oBEDG.email);

                    ResgitraLog("LISTO! El  alta como docente de iCom se ha iniciado exitosamente. <br> " +
                                "Se enviará un correo electrónico al docente con su usuario y contraseña " +
                                "para accesar a la plataforma. <br>");
                }
                // Ya se envio.
                bGuarda = false;
                btnGUardar.Enabled = false;
            }
            catch (Exception ex)
            {
                ResgitraLog(ex.Message);
                return;
            }
        }

        lblMensaje.Text = "Datos guardados";
        btnGUardar.Enabled = false;
        mp1.Show();
        return;
    }

    protected void enviarMail(String sBody, string sMailAlumno)
    {
        try
        {
            var client = new SmtpClient("mail.icom.education", 25)
            {
                Credentials = new NetworkCredential("admisiones@icom.education", "iCom2018.!"),
                EnableSsl = false
            };
            client.Send("admisiones@icom.education", sMailAlumno, "iCom Admisiones", sBody);
            ResgitraLog("Enviando: " + sBody + " - " + sMailAlumno);
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        DataRow workRow;

        if (txtCentroE.Text.Trim() == string.Empty)
        {
            ResgitraLog("Centro Educativo requerido");
            return;
        }

        if (txtAnios.Text.Trim() == string.Empty)
        {
            ResgitraLog("Años requerido");
            return;
        }

        if (txtMateria.Text.Trim() == string.Empty)
        {
            ResgitraLog("Materia requerido");
            return;
        }

        try
        {
            // Reviso el datagrid para saber si ya ay datos
            dtDocente = new DataTable();
            dtDocente.Columns.Add("CentroEducativo", typeof(string));
            dtDocente.Columns.Add("Anios", typeof(string));
            dtDocente.Columns.Add("Materia", typeof(string));

            foreach (GridViewRow row in gvDatos.Rows)
            {
                workRow = dtDocente.NewRow();

                workRow["CentroEducativo"] = row.Cells[0].Text;
                workRow["Anios"] = row.Cells[1].Text;
                workRow["Materia"] = row.Cells[2].Text;

                dtDocente.Rows.Add(workRow);
                gvDatos.DataSource = dtDocente;
            }

            if (dtDocente.Rows.Count == 0)
            {
                dtDatos = new DataTable();

                dtDatos.Columns.Add("CentroEducativo", typeof(string));
                dtDatos.Columns.Add("Anios", typeof(string));
                dtDatos.Columns.Add("Materia", typeof(string));

                workRow = dtDatos.NewRow();

                workRow["CentroEducativo"] = txtCentroE.Text;
                workRow["Anios"] = txtAnios.Text;
                workRow["Materia"] = txtMateria.Text;

                dtDatos.Rows.Add(workRow);
                gvDatos.DataSource = dtDatos;
            }
            else
            {
                workRow = dtDocente.NewRow();

                workRow[0] = txtCentroE.Text;
                workRow[1] = txtAnios.Text;
                workRow[2] = txtMateria.Text;

                dtDocente.Rows.Add(workRow);
                gvDatos.DataSource = dtDocente;
            }

            gvDatos.DataBind();

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
            ddlDiaI.Items.Add(new ListItem("Dìa"));

            for (int i = 1; i <= 31; i++)
            {
                ddlDia.Items.Add(new ListItem(i.ToString()));
                ddlDiaI.Items.Add(new ListItem(i.ToString()));
            }

            // Mes
            ddlMes.Items.Add(new ListItem("Mes"));
            ddlMesI.Items.Add(new ListItem("Mes"));

            for (int i = 1; i <= 12; i++)
            {
                ddlMes.Items.Add(new ListItem(i.ToString()));
                ddlMesI.Items.Add(new ListItem(i.ToString()));
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


    #endregion

    #region Log

    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Docente_DocenteView", sMensaje);
        lblMensaje.Text = sMensaje;
        mp1.Show();
    }
    #endregion

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
            Carga_Ciudad(ddlEstado.SelectedIndex);
            ddlCiudad.Focus();
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }
}
