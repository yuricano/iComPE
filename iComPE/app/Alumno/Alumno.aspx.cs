using System;
using System.Data;
using iCom_Generales;

public partial class app_Alumno_Alumno : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblUsuario.Text = Session["nombre"].ToString();
            Carga_Datos();
        }
    }

    #region Datos
    protected void Carga_Datos()
    {
        iCom_BusinessEntity.Mensaje oBE = new iCom_BusinessEntity.Mensaje();
        iCom_BusinessLogic.Mensaje oBL = new iCom_BusinessLogic.Mensaje();

        oBE.idusuario = int.Parse(Session["id"].ToString());
        oBE.idtipousuario = 4;

        try
        {
            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                    gvDatos.DataSource = dtDatos;
                    gvDatos.DataBind();
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }
    #endregion

    #region Log
    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_Alumno", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
