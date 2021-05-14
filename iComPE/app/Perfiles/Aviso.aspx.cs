using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_Perfiles_Aviso : System.Web.UI.Page
{
    void Page_PreInit(object sender, EventArgs e)
    {
        if (Application["docente"] != null)
        {
            if (Application["docente"].ToString() == "1")
            {
                MasterPageFile = "~/Docente.master";
            }
        }

        if (Application["alumno"] != null)
        {
            if (Application["alumno"].ToString() == "1")
            {
                MasterPageFile = "~/Alumno.master";
            }
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}