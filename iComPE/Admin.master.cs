using System;

public partial class Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        Application["admin"] = "1";
        
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
        Response.Redirect("~/app/Administracion/Admin.aspx");
    }

    protected void btnMensaje_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Mensaje.aspx");
    }

    protected void btnDocente_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Docente.aspx");
    }

    protected void btnAlumno_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Alumno.aspx");
    }

    protected void btnDocumentos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Documentos.aspx");
    }

    protected void btnAdminAlumno_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/AdminAlumno.aspx");
    }

    protected void btnConceptos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Concepto.aspx");
    }

    protected void btnDescuentos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Descuento.aspx");
    }

    protected void btnPeriodo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Periodo.aspx");
    }

    protected void btnCalendario_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Calendario.aspx");
    }

    protected void btnEvaluacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Administracion/Evaluacion.aspx");
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/app/Logout/Logout.aspx");
    }

    #endregion
}
