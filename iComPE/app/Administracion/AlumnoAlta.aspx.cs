using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using iCom_Generales;

public partial class app_Administracion_AlumnoAlta : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();
    static DataTable dtFiltro = new DataTable();
    static bool bGuarda = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Catalogos
            Carga_Catalogos();
        }
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
            return;
        }
    }

    // Guardar
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        // Validar
        if (bGuarda == false)
        {
            ResgitraLog("El formulario ya ha sido enviado.");
            return;
        }

        if (!Valida())
        {
            return;
        }

        // Valida Archivos
        if (Request.Files[0].ContentLength == 0)
        {
            ResgitraLog("Para poder realizar tu inscripción es necesario que nos envíes tu documentación.");
            return;
        }

        foreach (HttpPostedFile postedFile in FileUpload.PostedFiles)
        {
            // Tamaño
            string fileName = Path.GetFileName(postedFile.FileName);
            int iFileSize = postedFile.ContentLength;

            if (iFileSize > 1048576)  // 1MB
            {
                ResgitraLog("El archivo " + postedFile.FileName + " es demasiado grande. Max 1 MB por archivo.");
                return;
            }

            Regex reg = new Regex(@"^.*\.(pdf|PDF)$");
            if (!reg.IsMatch(fileName))
            {
                ResgitraLog("Solo puedes eniviar archivos con formato PDF.");
                return;
            }
        }

        // Creo el nuevo usuario
        int idusuario = 0;

        iCom_BusinessLogic.Usuario oBLUsuario = new iCom_BusinessLogic.Usuario();

        // Obtengo el id
        try
        {
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

            // Carpeta por alumno
            string dirAlumno = Server.MapPath("~/Cargas/") + idusuario.ToString();

            if (!Directory.Exists(dirAlumno))
            {
                Directory.CreateDirectory(dirAlumno);
            }

            foreach (HttpPostedFile postedFile in FileUpload.PostedFiles)
            {
                // Tamaño
                string fileName = Path.GetFileName(postedFile.FileName);

                fileName = idusuario.ToString() + "-" + fileName;
                postedFile.SaveAs(dirAlumno + "//" + fileName);
            }

            // Alta de Usuario
            iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
            oBE.usuario = "al" + DateTime.Now.Year.ToString() + idusuario.ToString();

            // Paswword
            oBE.contrasena = string.Format("{0:00}", Convert.ToInt32(ddlDia.SelectedItem.ToString())) +
                string.Format("{0:00}", Convert.ToInt32(ddlMes.SelectedItem.ToString())) +
                txtAnio.Text;

            oBE.idusuariotipo = 4;

            dtDatos = oBLUsuario.Insertar(oBE);

            // Datos generales
            iCom_BusinessEntity.UsuarioDatosGenerales oBEDG = new iCom_BusinessEntity.UsuarioDatosGenerales();

            oBEDG.idusuario = idusuario;
            oBEDG.nombre = txtNombre.Text;
            oBEDG.appaterno = txtApPaterno.Text;
            oBEDG.apmaterno = txtApMaterno.Text;
            oBEDG.idmodeloeducativo = 1;
            oBEDG.idperiodoescolar = ddlPeriodo.SelectedIndex;
            oBEDG.matricula = "al" + DateTime.Now.Year.ToString() + idusuario.ToString();
            oBEDG.idcarrera = ddlCarrera.SelectedIndex;

            // Revisar
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
            oBEDir.idciudad = int.Parse(ddlCiudad.SelectedValue.ToString());
            oBEDir.idestado = ddlEstado.SelectedIndex;
            oBEDir.idpais = ddlPais.SelectedIndex;

            iCom_BusinessLogic.UsuarioDireccion oBLDir = new iCom_BusinessLogic.UsuarioDireccion();
            dtDatos = oBLDir.Insertar(oBEDir);

            // Laboral
            iCom_BusinessEntity.UsuarioLaboral oBEL = new iCom_BusinessEntity.UsuarioLaboral();

            oBEL.idusuario = idusuario;
            oBEL.labora = false;
            oBEL.nombreempresa = string.Empty;
            oBEL.puesto = string.Empty;
            oBEL.dias = string.Empty;
            //oBEL.horariodesde = null;
            //oBEL.horariohasta = null;
            oBEL.telefono = string.Empty;
            oBEL.descripciondoncente = string.Empty;

            iCom_BusinessLogic.UsuarioLaboral oBLL = new iCom_BusinessLogic.UsuarioLaboral();
            dtDatos = oBLL.Insertar(oBEL);

            string sBody = "Hola,\n" +
                "Tu proceso de inscripción se ha iniciado exitosamente.\n" +
                "Saludos!\n" +
                "usuario: " + oBE.usuario + "\n" + "contraseña: tu fecha de nacimiento en el formato ddmmaaaa";
            //oBE.contrasena;

            enviarMail(sBody, oBEDG.email);

            ResgitraLog("LISTO! Tu proceso de inscripción se ha iniciado exitosamente. <br> " +
                "Recibirás un correo electrónico con los pasos a seguir para completar tu matrícula. <br>" +
                "En caso de no recibirlo revisa el spam. Gracias!!!");

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

    #region Datos
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

            // Carrera
            dtDatos = Filtros.Carrera(0);
            if (dtDatos.Rows.Count > 0)
            {
                ddlCarrera.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    ddlCarrera.Items.Add(new ListItem(row[1].ToString()));
                }
            }

            // Periodo Escolar
            dtDatos = Filtros.PeriodoEscolar(0);
            if (dtDatos.Rows.Count > 0)
            {
                ddlPeriodo.Items.Add(new ListItem("Selecciona"));
                foreach (DataRow row in dtDatos.Rows)
                {
                    ddlPeriodo.Items.Add(new ListItem(row[3].ToString()));
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

    protected bool Valida()
    {
        bool bSelccion = false;

        // Validacion
        if (txtNombre.Text.Trim() == "")
        {
            txtNombre.Focus();
            ResgitraLog("Nombre requerido");
            return false;
        }

        if (txtApPaterno.Text.Trim() == "")
        {
            txtApPaterno.Focus();
            ResgitraLog("Apellido Paterno requerido");
            return false;
        }

        if (txtApMaterno.Text.Trim() == "")
        {
            txtApMaterno.Focus();
            ResgitraLog("Apellido Mateno requerido");
            return false;
        }

        if (ddlDia.SelectedIndex == 0)
        {
            ddlDia.Focus();
            ResgitraLog("Día requerido");
            return false;
        }

        if (ddlMes.SelectedIndex == 0)
        {
            ddlMes.Focus();
            ResgitraLog("Mes requerido");
            return false;
        }

        if (txtAnio.Text.Trim() == "")
        {
            txtAnio.Focus();
            ResgitraLog("Año requerido");
            return false;
        }

        if (txtNacionalidad.Text.Trim() == "")
        {
            txtNacionalidad.Focus();
            ResgitraLog("Nacionalidad requerido");
            return false;
        }

        if (txtCURP.Text.Trim() == "")
        {
            txtCURP.Focus();
            ResgitraLog("CURP/ID Nacionalidad requerido");
            return false;
        }

        if (txtCalle.Text.Trim() == "")
        {
            txtCalle.Focus();
            ResgitraLog("Calle requerido");
            return false;
        }

        if (txtNumero.Text.Trim() == "")
        {
            txtNumero.Focus();
            ResgitraLog("Número exterior requerido");
            return false;
        }

        if (txtColonia.Text.Trim() == "")
        {
            txtColonia.Focus();
            ResgitraLog("Colonia requerido");
            return false;
        }

        if (ddlPais.SelectedIndex == 0)
        {
            ddlPais.Focus();
            ResgitraLog("País requerido");
            return false;
        }

        if (ddlEstado.SelectedIndex == 0)
        {
            ddlEstado.Focus();
            ResgitraLog("Estado requerido");
            return false;
        }

        if (ddlCiudad.SelectedIndex == 0)
        {
            ddlCiudad.Focus();
            ResgitraLog("Ciudad requerido");
            return false;
        }

        if (txtCP.Text.Trim() == "")
        {
            txtCP.Focus();
            ResgitraLog("Código Postal requerido");
            return false;
        }

        if (txtTelContacto.Text.Trim() == "")
        {
            txtTelContacto.Focus();
            ResgitraLog("Teléfono de contacto requerido");
            return false;
        }

        if (txtCorreo.Text.Trim() == "")
        {
            txtCorreo.Focus();
            ResgitraLog("Correo electrónico requerido");
            return false;
        }

        if (ddlPeriodo.SelectedIndex == 0)
        {
            ddlPeriodo.Focus();
            ResgitraLog("Periodo requerido");
            return false;
        }

        if (ddlCarrera.SelectedIndex == 0)
        {
            ddlCarrera.Focus();
            ResgitraLog("Oferta educativa requerido");
            return false;
        }

        if (txtEscuelaProcedencia.Text.Trim() == "")
        {
            txtEscuelaProcedencia.Focus();
            ResgitraLog("Escuela de procedencia requerido");
            return false;
        }

        foreach (ListItem lisit in chkDocumentos.Items)
        {
            if (lisit.Selected)
            {
                bSelccion = true;
                break;
            }
        }

        if (!bSelccion)
        {
            chkDocumentos.Focus();
            ResgitraLog("Debes de seleccionar los documentos de inscripción que nos enviarás.");
            return false;
        }

        return true;
    }
    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "_Solicitud", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
