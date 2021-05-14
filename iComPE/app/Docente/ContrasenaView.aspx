<%@ Page Title="" Language="C#" MasterPageFile="~/Docente.master" 
    AutoEventWireup="true" CodeFile="ContrasenaView.aspx.cs" Inherits="app_Docente_ContrasenaView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Modificar contraseña</h2>

        <!-- Begin page content -->
        <!--Form ITEM-->
        <div class="box no-shadow ">
            <!-- /.box-header -->
            <div class="box-body">
                <!-- row -->
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">

                            <div class="medium-4 columns">
                                <label>
                                    Contraseña actual
                                   
                                    <asp:TextBox runat="server" ID="txtActual"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-9 columns">
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Nueva contraseña
                                    <asp:TextBox runat="server" ID="txtNueva"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-6 columns">
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Confirmar nueva contraseña
                                    <asp:TextBox runat="server" ID="txtConfirma"></asp:TextBox>
                                </label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Button runat="server" Text="Guardar" ID="btnGUardar" OnClick="btnGuardar_Click"
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
