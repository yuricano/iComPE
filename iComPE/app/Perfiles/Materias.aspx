<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno.master" AutoEventWireup="true"
    CodeFile="Materias.aspx.cs"
    Inherits="app_Alumno_Materias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Materias</h2>

        <div class="box no-shadow ">
            <div class="box-header bg-transparent">
                <h3 class="box-title">
                    <span>Materias</span>
                </h3>
            </div>

            <div class="box-body">
                <!-- row -->
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-12 columns">
                                <h4>Materias de
                                    <asp:Label ID="lblCurso" runat="server" Text=""></asp:Label>
                                    &nbsp - &nbsp
                                    <asp:Label ID="lblCarrera" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="large-12 columns">
                                <asp:GridView runat="server" ID="gvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                    HorizontalAlign="Left">
                                    <Columns>
                                        <asp:BoundField HeaderText="Materia" DataField="materia">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataTemplate>No hay datos</EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
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
