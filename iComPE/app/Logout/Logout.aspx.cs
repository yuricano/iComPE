using System;
using iCom_Generales;

public partial class Logout: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Application["admin"] = null;
        Application["idusuario"] = null;
        Application["matricula"] = null;

        Session["login"] = null;
        Session["nombre"] = null;
        Session["id"] = null;

        Response.Redirect("~/Default.aspx");
    }
}