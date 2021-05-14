<%@ Page Title="" Language="C#" MasterPageFile="~/Docente.master"
    AutoEventWireup="true" CodeFile="Calificacion.aspx.cs" Inherits="app_Docente_Calificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Calificaciones</h2>
        <div class="box">
            <!-- /.box-header -->
            <div class="box-body " style="display: block;">
                <div class="row">

                    <div class="large-4 columns">
                        <label>
                            Periodo
                            <asp:DropDownList runat="server" ID="DdlPeriodo" 
                                AutoPostBack="true" 
                                AppendDataBoundItems="false" 
                                OnSelectedIndexChanged="DdlPeriodo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </label>
                    </div>

                    <div class="large-4 columns">
                        <label>
                            Carrera  
                              <asp:DropDownList runat="server" ID="DdlCarrera"
                                  AutoPostBack="true"
                                  AppendDataBoundItems="false"
                                  OnSelectedIndexChanged="DdlCarrera_SelectedIndexChanged">
                              </asp:DropDownList>
                        </label>
                    </div>

                    <div class="large-4 columns">
                        <label>
                            Materia
                            <asp:DropDownList runat="server" ID="ddlMateria"
                                AutoPostBack="true"
                                AppendDataBoundItems="false"
                                OnSelectedIndexChanged="ddlMateria_SelectedIndexChanged">
                            </asp:DropDownList>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-4 columns">
                        <label>
                            <!-- Grupo -->
                            <asp:DropDownList runat="server" ID="ddlGrupo" Visible="false"></asp:DropDownList>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <asp:GridView runat="server" ID="gvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" HorizontalAlign="Left"
                            OnRowDataBound="OnRowDataBound">
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="idusuariocurso">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="IdUsuario" DataField="idusuario">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="Alumno" DataField="nombre">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Calificación">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCalificacion" runat="server"
                                           Text='<% #Eval("calificacion")%>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Comentario">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtComentario" runat="server"
                                            Text='<% #Eval("comentario")%>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No hay datos</EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <asp:Button runat="server" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"
                            CssClass="button palette-Deep-Purple-900 bg" />
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
