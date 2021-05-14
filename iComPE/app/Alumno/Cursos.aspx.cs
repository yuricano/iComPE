using System;
using iCom_Generales;

public partial class app_Alumno_Cursos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('http://moodle.icom.education/login/index.php','_blank')");
        Response.Write("</script>");
    }

    #region Log

    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_Cursos", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
