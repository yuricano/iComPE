<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno.master" AutoEventWireup="true" CodeFile="Contacto.aspx.cs" Inherits="app_Alumno_Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <h2>Ayuda, dudas, aclaraciones</h2>
        <h3>Ponte en contacto con nosotros</h3>

        <div class="box no-shadow ">
            <!-- /.box-header -->
            <div class="box-body">
                <!-- row -->
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">

                            <div class="large-5 large-offset-2 columns">
                                <div class="grid-x grid-padding-x">

                                    <div class="large-12 cell">
                                        <label class="texto-blanco">Asunto</label>
                                        <asp:DropDownList runat="server" ID="ddlAsunto"></asp:DropDownList>
                                    </div>

                                    <div class="large-12 cell">
                                        <label class="texto-blanco">Mensaje</label>
                                        <asp:TextBox runat="server" ID="txtMensaje"
                                            CssClass="texto-morado" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:Button runat="server" Text="ENVIAR" ID="btnEnviar" OnClick="btnEnviar_Click"
            CssClass="button palette-Deep-Purple-700 bg" />
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
