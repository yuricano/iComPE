<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" 
    CodeFile="DocumentosView.aspx.cs"
    Inherits="app_Administracion_DocumentosView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Documentos del alumno</h2>

        <div class="box no-shadow ">
            <div class="box-body">
                <div class="box-header bg-transparent">
                    <h3 class="box-title">
                        <span>Alumno</span>
                    </h3>
                </div>

                <!-- Datos del alumno -->
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-4 columns">
                                <label>
                                    Carrera
                                        <asp:DropDownList runat="server" ID="DdlCarrera" Enabled="false"></asp:DropDownList>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Nombre
                                        <asp:TextBox runat="server" ID="txtNombre" Enabled="false"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>Matrícula</label>
                                <h3>
                                    <asp:TextBox runat="server" ID="txtMatricula" placeholder="00000" Enabled="false"></asp:TextBox>
                                </h3>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Documentos -->
                <asp:GridView runat="server" ID="gvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                HorizontalAlign="Left"
                OnRowDataBound="gvDatos_OnRowDataBound"
                OnSelectedIndexChanged="gvDatos_OnSelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="IdDocumento" DataField="idDocumento">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="0px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Documento" DataField="Documento">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Fecha Creación" DataField="FechaCreacion">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataTemplate>No hay datos</EmptyDataTemplate>
            </asp:GridView>
            </div>

               
                <div class="fondo-oscuro padding">
                    <div class="grid-x grid-padding-x">
                        <div id="doctos" class="large-12 medium-4 small-12 cell">
                        </div>
                    </div>
                </div>
            </div>

            <!-- Regresar -->
            <div class="row">
                <div class="large-12 columns">
                    <asp:Button runat="server" Text="Regresar" ID="BtnRegresar" OnClick="BtnRegresar_Click"
                        CssClass="button palette-Deep-Purple-700 bg" />
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
