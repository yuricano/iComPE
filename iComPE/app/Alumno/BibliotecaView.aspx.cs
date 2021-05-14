using iCom_Generales;
using System;

public partial class app_Alumno_BibliotecaView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Iframe en el aspx para la página de la biblioteca
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }

    #region Log

    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_BibliotecaView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
