<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Periodo.aspx.cs" 
    Inherits="app_Administracion_Periodo"
     ValidateRequest="false" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Periodos</h2>
        <div class="box no-shadow ">

            <div class="box-body">
                <!-- row -->
                <div class="row">
                    <div class="large-12 columns">
                        <asp:Button runat="server" Text="Agregar Periodo" ID="btAgregar"
                            OnClick="btnAgregar_Click" CssClass="button success" />
                        <br />

                        <asp:GridView runat="server" ID="gvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" 
                            HorizontalAlign="Left"
                            OnRowDataBound="gvDatos_OnRowDataBound"
                            OnSelectedIndexChanged="gvDatos_OnSelectedIndexChanged">

                            <Columns>
                                <asp:BoundField HeaderText="ID Perido" DataField="idperiodoescolar">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Periodo" DataField="periodoescolar">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>No hay datos</EmptyDataTemplate>
                        </asp:GridView>
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

