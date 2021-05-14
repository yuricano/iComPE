<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno.master" AutoEventWireup="true" CodeFile="ServSocView.aspx.cs" Inherits="app_Alumno_ServSocView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Servicio Social</h2>
        <div class="box">
            <!-- /.box-header -->
            <div class="box-body " style="display: block;">
                <div class="row">
                    <div class="large-12 columns text-justify">
                        <p>
                            Conoce la información necesaria para llevar a cabo el proceso de Servicio Social requerido por la Secretaría de Educación del Estado y la 
                            Secretaría de Educación Pública de la Federación, como instrumento de validez oficial  y reconocimiento de conclusión de estudios universitarios.
                        </p>
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

    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
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
