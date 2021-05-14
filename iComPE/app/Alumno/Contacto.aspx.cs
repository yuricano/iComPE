using iCom_Generales;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;

public partial class app_Alumno_Contacto : System.Web.UI.Page
{
    static bool bGuarda = true;
    static DataTable dtDatos;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga_Datos();
        }
    }

    #region contacto
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        string sBody = "Gracias por contactarnos " + Session["nombre"].ToString() + ", en breve un asesor académico se pondrá en contacto contigo." + "<br/>" +
        "No olvides revisar el buzón de tu correo escolar " + Session["usuario"].ToString() + "@icom.education.com" + "<br/>" +
        "Saludos!";

        if (!Valida())
        {
            return;
        }

        // Guardo solicitud de ayuda
        iCom_BusinessLogic.Ayuda oBL = new iCom_BusinessLogic.Ayuda();
        iCom_BusinessEntity.Ayuda oBE = new iCom_BusinessEntity.Ayuda();

        oBE.idusuario = int.Parse(Application["idusuario"].ToString());
        oBE.idasunto = int.Parse(ddlAsunto.SelectedValue.ToString());
        oBE.mensaje = txtMensaje.Text.Trim();
        oBE.mailContacto = Session["usuario"].ToString() + "@icom.education.com";
        dtDatos = oBL.Insertar(oBE);

        ResgitraLog("Ayuda - " + ddlAsunto.SelectedItem.Text + " - " + txtMensaje.Text);

        enviarMail(sBody, "yuri.ivann.cano@gmail.com");
        //enviarMail(sBody, Session["usuario"].ToString() + "@icom.education.com");

        // Ya se envio.
        bGuarda = false;
        btnEnviar.Enabled = false;
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
            ResgitraLog(sBody);
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }
    #endregion

    #region datos

    protected void Carga_Datos()
    {
        ddlAsunto.Items.Clear();

        try
        {
            if (Application["idusuario"].ToString() != "0")
            {
                // Asunto
                iCom_BusinessEntity.Asunto oBE = new iCom_BusinessEntity.Asunto();
                iCom_BusinessLogic.Asunto oBL = new iCom_BusinessLogic.Asunto();
                dtDatos = oBL.Consultar(oBE);

                if (dtDatos.Rows.Count > 0)
                {
                    ddlAsunto.DataSource = dtDatos;
                    ddlAsunto.DataTextField = "asunto";
                    ddlAsunto.DataValueField = "idasunto";
                    ddlAsunto.DataBind();
                    ddlAsunto.Focus();
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
        // Validacion
        if (bGuarda == false)
        {
            ResgitraLog("El formulario ya ha sido enviado.");
            return false;
        }

        if (ddlAsunto.SelectedIndex < 1)
        {
            ResgitraLog("Selecciona un asunto");
            return false;
        }

        if (txtMensaje.Text.Trim() == "")
        {
            ResgitraLog("Escríbenos un mensaje.");
            return false;
        }

        return true;
    }
    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_Ayuda", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
