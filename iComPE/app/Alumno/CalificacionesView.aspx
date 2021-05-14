<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno.master" AutoEventWireup="true" CodeFile="CalificacionesView.aspx.cs" Inherits="app_Alumno_CalificacionesView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Calificaciones</h2>
        <div class="box">
            <!-- /.box-header -->
            <div class="box-body " style="display: block;">
                <div class="row">
                    <div class="large-12 columns">
                        <div class="large-4 columns">
                            <label>
                                Periodo
                            <asp:DropDownList runat="server" ID="DdlPeriodo"></asp:DropDownList>
                            </label>
                        </div>

                        <!--
                        <div class="large-3 columns">
                            <label>
                                Materia
                            <asp:DropDownList runat="server" ID="ddlCurso"></asp:DropDownList>
                            </label>
                        </div>
                        -->

                        <div class="large-3 columns">
                            <label>
                                <br />
                                <asp:Button runat="server" Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="button success" />
                            </label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <asp:GridView runat="server" ID="gvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" HorizontalAlign="Left">
                            <Columns>
                                <asp:BoundField HeaderText="Materia" DataField="materia">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                
                                <asp:BoundField HeaderText="Calificación" DataField="calificacion">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                
                                <asp:BoundField HeaderText="Comentario" DataField="comentario">
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

