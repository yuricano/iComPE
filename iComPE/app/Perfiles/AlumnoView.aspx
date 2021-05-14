<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno.master" AutoEventWireup="true" 
    CodeFile="AlumnoView.aspx.cs"
    Inherits="app_Alumno_AlumnoView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Datos</h2>
        <div class="box no-shadow ">
    
            <div class="box-body">
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-6 columns">
                                <label>
                                    Modelo    
                                        <asp:DropDownList runat="server" ID="ddlModelo" Enabled="false"></asp:DropDownList>
                                </label>
                            </div>

                            <div class="medium-6 columns">
                                <label>
                                    Carrera a cursar                                                               
                                        <asp:DropDownList runat="server" ID="DdlCarrera" Enabled="false"></asp:DropDownList>
                                </label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="medium-4 columns">
                                <label>
                                    Periodo                                       
                                    <asp:DropDownList runat="server" ID="DdlPeriodo" Enabled="false"></asp:DropDownList>
                                </label>
                            </div>

                            <div class="medium-2 columns">
                                <label>
                                    Grupo
                                    <asp:DropDownList runat="server" ID="ddlGrupo" Enabled="false"></asp:DropDownList>
                                </label>
                            </div>

                            <div class="medium-3 columns">
                                <label>Matrícula</label>
                                <h3>
                                    <asp:TextBox runat="server" ID="txtMatricula" placeholder="00000" Enabled="false"></asp:TextBox>
                                </h3>
                            </div>

                            <div class="medium-3 columns">
                                <label>
                                    &nbsp;
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="box no-shadow ">
            <div class="box-header bg-transparent">
                <h3 class="box-title">
                    <span>Información Básica</span>
                </h3>
            </div>

            <div class="box-body">
                <!-- row -->
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-12 columns">
                                <h4>Datos del alumno</h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="medium-4 columns">
                                <label>
                                    Nombre(s)
                                        <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Apellido paterno
                                        <asp:TextBox runat="server" ID="txtApPaterno"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Apellido materno
                                        <asp:TextBox runat="server" ID="txtApMaterno"></asp:TextBox>
                                </label>
                            </div>


                            <div class="medium-4 columns">
                                <label>
                                    Nacionalidad
                                        <asp:TextBox runat="server" ID="txtNacionalidad"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Teléfono de contacto
                                    <asp:TextBox runat="server" ID="txtTelContacto" MaxLength="10"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Correo
                                        <asp:TextBox runat="server" ID="txtCorreo"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    CURP / ID Nacionalidad
                                        <asp:TextBox runat="server" ID="txtCURP" >

                                        </asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Fecha Nacimiento
                                </label>

                                <div class="medium-4 columns">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlDia"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-4 columns">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlMes"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-4 columns">
                                    <label>
                                        <asp:TextBox runat="server" ID="txtAnio" placeholder="Año"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <fieldset class="large-4 columns">
                                <legend>Sexo</legend>
                                <asp:RadioButtonList runat="server" ID="rblSexo" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Hombre</asp:ListItem>
                                    <asp:ListItem Value="2">Mujer</asp:ListItem>
                                </asp:RadioButtonList>
                            </fieldset>

                            <fieldset class="large-6 columns">
                                <legend>Estado civil</legend>
                                <asp:RadioButtonList runat="server" ID="rblEdoCivil" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Soltero</asp:ListItem>
                                    <asp:ListItem Value="2">Casado</asp:ListItem>
                                    <asp:ListItem Value="3">Divorciado</asp:ListItem>
                                    <asp:ListItem Value="4">Otro</asp:ListItem>
                                </asp:RadioButtonList>
                            </fieldset>
                            <div class="medium-2 columns">
                            </div>
                        </div>

                        <div class="row">
                            <div class="medium-4 columns">
                                <label>
                                    Escuela de procedencia
                                        <asp:TextBox runat="server" ID="txtEscuelaProcedencia"></asp:TextBox>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                <hr />

                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-12 columns">
                                <h4>Vivienda</h4>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Calle
                                    <asp:TextBox runat="server" ID="txtCalle"></asp:TextBox>
                                </label>
                            </div>
                            <div class="medium-2 columns">
                                <label>
                                    Número exterior
                                    <asp:TextBox runat="server" ID="txtNumero"></asp:TextBox>
                                </label>
                            </div>
                            <div class="medium-2 columns">
                                <label>
                                    Número interior
                                        <asp:TextBox runat="server" ID="txtNumeroInt"></asp:TextBox>
                                </label>
                            </div>
                            <div class="medium-4 columns">
                                <label>
                                    Colonia
                                    <asp:TextBox runat="server" ID="txtColonia"></asp:TextBox>
                                </label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-3 columns">
                                <label>
                                    País
                                    <asp:DropDownList runat="server" ID="ddlPais" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"
                                        AutoPostBack="true"
                                        AppendDataBoundItems="false">
                                    </asp:DropDownList>
                                </label>
                            </div>

                            <div class="large-4 columns">
                                <label>
                                    Estado
									<asp:DropDownList runat="server" ID="ddlEstado" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" 
                                        AutoPostBack="true" 
                                        AppendDataBoundItems="false">
									</asp:DropDownList>
                                </label>
                            </div>

                            <div class="medium-3 columns">
                                <label>
                                    Ciudad
                                    <asp:DropDownList runat="server" ID="ddlCiudad"></asp:DropDownList>
                                </label>
                            </div>

                            <div class="medium-2 columns">
                                <label>
                                    Código Postal
                                    <asp:TextBox runat="server" ID="txtCP"></asp:TextBox>
                                </label>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="box no-shadow ">
            <div class="box-header bg-transparent">
                <h3 class="box-title">
                    <span>Información Laboral</span>
                </h3>
            </div>

            <div class="box-body">
                <!-- row -->
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-12 columns">
                                <h4>Información Laboral</h4>
                            </div>
                        </div>

                        <div class="large-12 columns">
                            <div class="row">
                                <fieldset class="large-6 columns">
                                    <legend>¿Laboras actualmente?</legend>
                                    <asp:RadioButtonList runat="server" ID="rblLaboral" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </fieldset>
                            </div>
                        </div>

                        <div class="large-12 columns">
                            <div class="row">
                                <div class="medium-12 columns">
                                    <label>
                                        Nombre de la Empresa o Negocio
                                        <asp:TextBox runat="server" ID="txtEmpresaLaaboral"></asp:TextBox>
                                    </label>
                                </div>
                                <div class="medium-6 columns">
                                    <label>
                                        Puesto o Cargo que desempeña
                                        <asp:TextBox runat="server" ID="txtPuestoLaboral"></asp:TextBox>
                                    </label>
                                </div>

                                <div class="medium-6 columns">
                                    <label>
                                        Teléfono donde puede ser contactado
                                    <asp:TextBox runat="server" ID="txtTelLaboral" MaxLength="10"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="box no-shadow ">
            <div class="box-header bg-transparent">
                <h3 class="box-title">
                    <span>Activo</span>
                </h3>
            </div>

            <div class="box-body">
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-12 columns">
                                <h4>Activo</h4>
                            </div>
                        </div>

                        <div class="large-12 columns">
                            <div class="row">

                                <div class="medium-12 columns">
                                    <label>
                                        Activo
                                    <asp:CheckBox runat="server" ID="chkActivo" Checked="true" />
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <hr />

                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-12 columns">
                                <asp:Button runat="server" Text="Regresar" ID="btnRegresar" OnClick="btnRegresar_Click"
                                CssClass="button palette-Deep-Purple-700 bg" />

                                <asp:Button runat="server" Text="Guardar" ID="btnGUardar" OnClick="btnGuardar_Click"
                                    CssClass="button palette-Deep-Purple-700 bg" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Mensaje -->
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ScriptManager>

    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="HiddenField1"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:HiddenField ID="HiddenField1" runat="server" />

    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div class="box">
            <div class="box-body " style="display: block;">
                <div class="row">
                    <div class="large-12 columns">
                        <p class="centrar-texto">
                            <asp:Label runat="server" ID="lblMensaje"></asp:Label>
                        </p>

                        <asp:Button runat="server" Text="Cerrar" ID="btnClose"
                            CssClass="button error" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
