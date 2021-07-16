<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" 
    CodeFile="AlumnoAlta.aspx.cs" Inherits="app_Administracion_AlumnoAlta"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="solicitud" class=" fondo-oscuro padding">
        <div class="grid-container" id="oferta">

            <h3 class="texto-blanco center padding20">ALTA DE ALUMNO</h3>

            <div class="fondo-oscuro">
                <div class="grid-container">
                    <div class="grid-x grid-padding-x">
                        <div class="large-8 large-offset-2 medium-8 cell">

                            <div class="callout large">
                                <h3 class="texto-morado">Datos Personales</h3>

                                <div class="grid-x grid-padding-x">
                                    <div class="large-4 medium-4 cell">
                                        <label>Nombre (s)</label>
                                        <asp:TextBox runat="server" ID="txtNombre" placeholder="Nombre(s)">
                                        </asp:TextBox>
                                    </div>

                                    <div class="large-4 medium-4 cell">
                                        <label>Apellido Paterno</label>
                                        <asp:TextBox runat="server" ID="txtApPaterno" placeholder="Apellido paterno">
                                        </asp:TextBox>
                                    </div>

                                    <div class="large-4 medium-4 cell">
                                        <label>Apellido Materno</label>
                                        <asp:TextBox runat="server" ID="txtApMaterno" placeholder="Apellido materno">
                                        </asp:TextBox>
                                    </div>

                                    <div class="large-6 medium-6 small-6 cell">
                                        <label>
                                            Fecha Nacimiento
                                        </label>
                                    </div>

                                    <div class="large-6 medium-6 small-6 cell">
                                        <label>
                                            Nacionalidad
                                        </label>
                                    </div>

                                    <div class="large-2 medium-2 cell">
                                        <label>
                                            <asp:DropDownList runat="server" ID="ddlDia"></asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="large-2 medium-2 cell">
                                        <label>
                                            <asp:DropDownList runat="server" ID="ddlMes"></asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="large-2 medium-2 cell">
                                        <label>
                                            <asp:TextBox runat="server" ID="txtAnio" placeholder="Año"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="large-6 medium-6 cell">
                                        <asp:TextBox runat="server" ID="txtNacionalidad" placeholder="Nacionalidad"></asp:TextBox>
                                    </div>

                                    <div class="large-4 medium-4 cell">
                                        <label>
                                            Sexo
                                                <asp:RadioButtonList runat="server" ID="rblSexo"
                                                    RepeatDirection="Horizontal"
                                                    BorderStyle="None">
                                                    <asp:ListItem Value="1">Hombre</asp:ListItem>
                                                    <asp:ListItem Value="2">Mujer</asp:ListItem>
                                                </asp:RadioButtonList>
                                        </label>
                                    </div>

                                    <div class="large-8 medium-8 cell">
                                        <label>
                                            Estado Civil
                                                <asp:RadioButtonList runat="server" ID="rblEdoCivil"
                                                    RepeatDirection="Horizontal"
                                                    BorderStyle="None">
                                                    <asp:ListItem Value="1">Soltero</asp:ListItem>
                                                    <asp:ListItem Value="2">Casado</asp:ListItem>
                                                    <asp:ListItem Value="3">Divorciado</asp:ListItem>
                                                    <asp:ListItem Value="4">Otro</asp:ListItem>
                                                </asp:RadioButtonList>
                                        </label>
                                    </div>

                                    <div class="large-8 medium-8 cell">
                                        <label>
                                            CURP / ID Nacionalidad
                                            <asp:TextBox runat="server" ID="txtCURP">
                                                  
                                            </asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="large-12 medium-12 small-12 cell">
                                        <label>
                                            Calle
                                                    <asp:TextBox runat="server" ID="txtCalle"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="large-3 medium-3 small-3 cell">
                                        <label>
                                            Número exterior
                                                    <asp:TextBox runat="server" ID="txtNumero"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="large-3 medium-3 small-3 cell">
                                        <label>
                                            Número interior
                                                    <asp:TextBox runat="server" ID="txtNumeroInt"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="large-6 medium-6 small-6 cell">
                                        <label>
                                            Colonia
                                                    <asp:TextBox runat="server" ID="txtColonia"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="large-3 medium-3 small-3 cell">
                                        <label>
                                            País		
                                                <asp:DropDownList runat="server" ID="ddlPais" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"
                                                    AutoPostBack="true"
                                                    AppendDataBoundItems="false">
                                                </asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="large-3 medium-3 small-3 cell">
                                        <label>
                                            Estado
                                                    <asp:DropDownList runat="server" ID="ddlEstado" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                                        AutoPostBack="true"
                                                        AppendDataBoundItems="false">
                                                    </asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="large-3 medium-3 small-3 cell">
                                        <label>
                                            Ciudad
                                                    <asp:DropDownList runat="server" ID="ddlCiudad"></asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="large-3 medium-3 small-3 cell">
                                        <label>
                                            Código Postal
                                                    <asp:TextBox runat="server" ID="txtCP"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="large-4 medium-4 small-12 cell">
                                        <label>
                                            Teléfono de contacto
                                            <asp:TextBox runat="server" ID="txtTelContacto" placeholder="10 dígitos"
                                                MaxLength="10"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="large-8 medium-8 small-12 cell">
                                        <label>
                                            Correo electrónico
                                                <asp:TextBox runat="server" ID="txtCorreo" placeholder="nombre@dominio.com"></asp:TextBox>
                                        </label>
                                    </div>
                                </div>

                                <hr style="border: 1px solid;" />

                                <h3 class="texto-morado">Datos Académicos</h3>
                                <div class="grid-x grid-padding-x">
                                    <div class="large-6 medium-6 small-12 cell">
                                        <label>
                                            Periodo                                       
                                                <asp:DropDownList runat="server" ID="ddlPeriodo"></asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="large-6 medium-6 small-12 cell">
                                        <label>
                                            Oferta educativa que deseas cursar
                                                    <asp:DropDownList runat="server" ID="ddlCarrera"></asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="large-12 medium-12 small-12 cell">
                                        <label>
                                            Escuela de procedencia
                                                    <asp:TextBox runat="server" ID="txtEscuelaProcedencia" placeholder="Escuela procedencia"></asp:TextBox>
                                        </label>

                                        <label>
                                            Escanear y adjuntar todos los archivos originales y certificados por ambos lados (Solo PDF).
                                                <br />
                                            <br />
                                            Selecciona los documentos que enviarás:
                                                <br />
                                            <asp:CheckBoxList ID="chkDocumentos" runat="server" CssClass="large-12 medium-12 small-12 cell cell-block">
                                                <asp:ListItem Value="1">Certificado de Prepa</asp:ListItem>
                                                <asp:ListItem Value="2">Carta de Pasante</asp:ListItem>
                                                <asp:ListItem Value="3">Título</asp:ListItem>
                                                <asp:ListItem Value="4">Cédula profesional</asp:ListItem>
                                                <asp:ListItem Value="5">Acta de nacimiento</asp:ListItem>
                                                <asp:ListItem Value="6">CURP</asp:ListItem>
                                                <asp:ListItem Value="7">Fotografía</asp:ListItem>
                                            </asp:CheckBoxList>

                                            <b>Debes de seleccionar TODOS los documentos que nos vayas a enviar.</b>
                                        </label>
                                    </div>

                                    <div class="large-7 medium-7 small-7 cell">
                                        <asp:FileUpload ID="FileUpload" runat="server" AllowMultiple="true" CssClass="button" />
                                    </div>

                                    <br />

                                    <div class="large-12 medium-12 small-12 cell">
                                        <asp:Button runat="server" Text="Alta de alumno" ID="btnGUardar" OnClick="btnGuardar_Click"
                                            CssClass="button center" />
                                    </div>
                                </div>
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
            <div class="box-body " style="display: block; background-color: #ffffff">
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
