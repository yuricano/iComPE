<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Alumno.aspx.cs" Inherits="app_Administracion_Alumno"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Alumnos</h2>

        <div class="box no-shadow ">

            <div class="box-body">

                <div class="row">
                    <div class="large-12 columns">
                        <div class="medium-4 columns">
                            <label>
                                Carrera
                            <asp:DropDownList runat="server" ID="DdlCarrera"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-4 columns">
                            <label>
                                Periodo
                            <asp:DropDownList runat="server" ID="DdlPeriodo"></asp:DropDownList>
                            </label>
                        </div>
                        
                        <div class="medium-4 columns">
                            <label>
                                &nbsp;
                                <asp:Button runat="server" Text="Alta Alumno" ID="BtnAlta" OnClick="BtnAlta_Click"
                                    CssClass="boton-accion button success" />
                            </label>
                        </div>

                        <!--
                        <div class="medium-4 columns">
                            <label>
                                Materia
                                <asp:DropDownList runat="server" ID="ddlMateria"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-5 columns">
                            <label>
                                Grupo
                                <asp:DropDownList runat="server" ID="ddlGrupo"></asp:DropDownList>
                            </label>
                        </div>
                        -->
                    </div>

                    <div class="large-12 columns">
                        <div class="medium-1 columns">
                            <label>
                                <asp:Button runat="server" Text="Filtrar" ID="BtnFiltrar" OnClick="BtnFiltrar_Click"
                                    CssClass="boton-accion button success" />
                            </label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="large-12 columns">
                            <asp:GridView runat="server" ID="gvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                HorizontalAlign="Left"
                                OnRowDataBound="gvDatos_OnRowDataBound"
                                OnSelectedIndexChanged="gvDatos_OnSelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="idusuario" DataField="idusuario">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="0px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Matrícula" DataField="usuario">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Alumno" DataField="nombre">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Carrera" DataField="carrera">
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

                        <asp:Button runat="server" Text="Cerrar" ID="btnClose" CssClass="oton-accion button error" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
