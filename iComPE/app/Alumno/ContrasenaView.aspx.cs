using iCom_Generales;
using System;
using System.Data;

public partial class app_Alumno_ContrasenaView : System.Web.UI.Page
{ 
    static DataTable dtDatos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    #region Datos

    protected bool Carga_Datos()
    {
        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

        try
        {
            oBE.idusuario = int.Parse(Session["id"].ToString());

            dtDatos = oBL.Consultar(oBE);

            if (dtDatos.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return false;
        }
    }

    #endregion

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Carga_Datos())
            {
                // Contraseña actual
                if (dtDatos.Rows[0]["contrasena"].ToString() == txtActual.Text)
                {
                    if (txtNueva.Text.Trim() == "")
                    {
                        ResgitraLog("Contraseña no puede ir vacio.");
                        txtNueva.Focus();
                        return;
                    }

                    if (txtConfirma.Text.Trim() == "")
                    {
                        ResgitraLog("Contraseña no puede ir vacio.");
                        txtConfirma.Focus();
                        return;
                    }
                    
                    if (txtNueva.Text == txtConfirma.Text)
                    {

                        iCom_BusinessEntity.Usuario oBE = new iCom_BusinessEntity.Usuario();
                        iCom_BusinessLogic.Usuario oBL = new iCom_BusinessLogic.Usuario();

                        oBE.idusuario = int.Parse(dtDatos.Rows[0]["idusuario"].ToString());
                        oBE.usuario = dtDatos.Rows[0]["usuario"].ToString();
                        oBE.contrasena = txtNueva.Text;
                        oBE.idusuariotipo = int.Parse(dtDatos.Rows[0]["idusuariotipo"].ToString());
                        oBE.activo = true;

                        dtDatos = oBL.Actualizar(oBE);

                        ResgitraLog("Datos guardados.");
                        return;
                    }
                    else
                    {
                        ResgitraLog("Contraseñas no coinciden.");
                        return;
                    }
                }
                else
                {
                    ResgitraLog("Contraseña actual no coincide.");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            ResgitraLog(ex.Message);
            return;
        }
    }

    #region Log

    protected void ResgitraLog(string sMensaje)
    {
        Log._Log(Convert.ToInt32(Session["id"]), "app_Alumno_ContrasenaView", sMensaje);
        lblMensaje.Text = "<br />" + sMensaje;
        mp1.Show();
    }
    #endregion
}
