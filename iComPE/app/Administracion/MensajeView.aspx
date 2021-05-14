<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="MensajeView.aspx.cs" Inherits="app_Administracion_MensajeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Mensaje</h2>
        <div class="box">
            <div class="box-body " style="display: block;">
                <div class="row">
                    <div class="large-12 columns">
                        <div class="large-4 columns">
                            <label>
                                Tipo de usuario al que va dirigido el mensaje
                                <asp:DropDownList runat="server" ID="ddlUsuarioTipo"
                                    OnSelectedIndexChanged="ddlUsuarioTipo_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </label>
                        </div>

                        <div class="large-8 columns">
                            <label>
                                Usuario al que va dirigido el mensaje (vacio para todos)
                                <asp:DropDownList runat="server" ID="ddlUsuario"></asp:DropDownList>
                            </label>
                        </div>
                    </div>

                    <div class="large-12 columns">
                        <div class="large-12 columns">
                            <label>
                                Mensaje
                                <asp:TextBox runat="server" ID="txtMensaje"></asp:TextBox>
                            </label>
                        </div>
                    </div>

                    <div class="large-12 columns">
                        <div class="medium-12 columns">
                            <label>
                                Fecha inicial
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlDiaIni"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMesIni"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlAnioIni"></asp:DropDownList>
                            </label>
                        </div>
                    </div>

                    <div class="large-12 columns">
                        <div class="medium-12 columns">
                            <label>
                                Fecha final
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlDiaFin"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMesFin"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlAnioFin"></asp:DropDownList>
                            </label>
                        </div>
                    </div>

                    <div class="large-12 columns">
                        <div class="medium-12 columns">
                            <label>
                                Activo 
                                <asp:CheckBox runat="server" ID="chkActivo" Checked="true" />
                            </label>
                        </div>
                    </div>

                    <br />

                    <div class="large-12 columns">
                        <div class="medium-12 columns">
                            <asp:Button runat="server" Text="Regresar" ID="btnRegresar" OnClick="btnRegresar_Click"
                                CssClass="boton-accion button palette-Deep-Purple-700 bg"
                                />

                            <asp:Button runat="server" Text="Guardar" ID="btnGUardar" OnClick="btnGuardar_Click"
                                CssClass="boton-accion button palette-Deep-Purple-700 bg"
                                />
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
                    <div class="large-12 columns fondo-blanco">
                        <p class="centrar-texto">
                            <asp:Label runat="server" ID="lblMensaje"> </asp:Label>
                        </p>

                        <asp:Button runat="server" Text="Cerrar" ID="btnClose" CssClass="button error" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
