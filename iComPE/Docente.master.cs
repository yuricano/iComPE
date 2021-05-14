using System;

public partial class Docente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        Application["admin"] = "0";

        lblUsuarioGral.Text = Session["nombre"].ToString();
    }

    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["login"] = null;
        Response.Redirect("~/Default.aspx");
    }

    #region menu

    protected void btnResumen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Docente/Docente.aspx");
    }

    protected void btnCalificaciones_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Docente/Calificacion.aspx");
    }

    protected void btnCalendario_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Docente/CalendarioView.aspx");
    }

    protected void btnDatos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Perfiles/DocenteView.aspx");
    }

    protected void btnContrasena_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Docente/ContrasenaView.aspx");
    }

    protected void btnAviso_Click(object sender, EventArgs e)
    {
        Application["docente"] = "1";
        Application["alumno"] = null;
        Response.Redirect("~/app/Perfiles/Aviso.aspx");
    }

    #endregion
}
