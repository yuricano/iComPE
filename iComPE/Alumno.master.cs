using System;

public partial class Alumno : System.Web.UI.MasterPage
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
        Response.Redirect("~/app/Alumno/Alumno.aspx");
    }

    protected void btnContacto_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/Contacto.aspx");
    }

    protected void btnCalificaciones_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/CalificacionesView.aspx");
    }

    protected void btnEdoCta_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/EdoCtaView.aspx");
    }

    protected void btnMaterias_Click(object sender, EventArgs e)
    {
        Application["docente"] = null;
        Application["alumno"] = "1";
        Response.Redirect("~/app/Perfiles/Materias.aspx");
    }

    protected void btnCursos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/Cursos.aspx");
    }

    protected void btnCalendario_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/CalendarioView.aspx");
    }

    protected void btnServSoc_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/ServSocView.aspx");
    }

    protected void btnBiblioteca_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/BibliotecaView.aspx");
    }

    protected void btnDatos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Perfiles/AlumnoView.aspx");
    }

    protected void btnContrasena_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/ContrasenaView.aspx");
    }

    protected void btnEvaluacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Alumno/Admin.aspx");
    }

    protected void btnAviso_Click(object sender, EventArgs e)
    {
        Application["docente"] = null;
        Application["alumno"] = "1";
        Response.Redirect("~/app/Perfiles/Aviso.aspx");
    }
    #endregion
}
