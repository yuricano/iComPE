<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PeriodoView.aspx.cs"
    Inherits="app_Administracion_PeriodoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Periodo</h2>

        <div class="box no-shadow ">
            <div class="box-body">

                <div class="row">
                    <div class="medium-12 columns">
                        <div class="medium-8 columns">
                            <label>
                                Periodo
                            <asp:RadioButtonList runat="server" ID="rblMes" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Enero - Abril</asp:ListItem>
                                <asp:ListItem Value="2">Mayo - Agosto</asp:ListItem>
                                <asp:ListItem Value="3">Septiembre - Diciembre</asp:ListItem>
                            </asp:RadioButtonList>
                            </label>
                        </div>

                        <div class="medium-2 columns">
                            <label>
                                Año
                            <asp:DropDownList runat="server" ID="ddlAnio"></asp:DropDownList>
                            </label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <div class="medium-7 columns">
                            <label>
                                Activo
                                    <asp:CheckBox runat="server" ID="chkActivo" Checked="true" />
                            </label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <div class="medium-7 columns">
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
