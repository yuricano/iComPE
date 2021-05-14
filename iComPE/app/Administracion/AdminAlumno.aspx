<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeFile="AdminAlumno.aspx.cs" Inherits="app_Administracion_AdminAlumno"
    ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Administración de cuenta del alumno</h2>

        <div class="box">

            <div class="box-body " style="display: block;">

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

                        <!-- 
                        <div class="medium-3 columns">
                            <label>
                                Materia
                            <asp:DropDownList runat="server" ID="ddlMateria"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-2 columns">
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
                                &nbsp;
                                <asp:Button runat="server" Text="Filtrar" ID="btnFiltrar" OnClick="btnFiltrar_Click" 
                                    CssClass="boton-accion button success" />
                            </label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <br />
                        <asp:GridView runat="server" ID="GvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                            HorizontalAlign="Left"
                            OnRowDataBound="GvDatos_OnRowDataBound"
                            OnSelectedIndexChanged="GvDatos_OnSelectedIndexChanged">
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
