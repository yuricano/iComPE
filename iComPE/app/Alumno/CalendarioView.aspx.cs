using System;
using System.Data;
using System.Web.UI.WebControls;
using iCom_Generales;

public partial class app_Alumno_CalendarioView : System.Web.UI.Page
{
    static DataTable dtDatos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Application["idcalendario"] = "0";
        }
    }

    #region Datos
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        Calendar1.SelectedDates.Clear();

        try
        {
            iCom_BusinessEntity.Calendario oBE = new iCom_BusinessEntity.Calendario();
            iCom_BusinessLogic.Calendario oBL = new iCom_BusinessLogic.Calendario();
            dtDatos = oBL.Consultar(oBE);

            foreach (DataRow row in dtDatos.Rows)
            {   
                if (row[1].ToString().Contains(e.Day.Date.ToString()) == true)
                {
                    Label lbl = new Label();
                    lbl.Text = "<br/>" + row[2].ToString();
                    e.Cell.Controls.Add(lbl);
                }
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
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_Calendario", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
