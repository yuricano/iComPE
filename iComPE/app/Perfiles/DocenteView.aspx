<%@ Page Language="C#" MasterPageFile="~/Docente.master" AutoEventWireup="true"
    CodeFile="DocenteView.aspx.cs"
    Inherits="app_Docente_DocenteView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Tus Datos</h2>

        <div class="box no-shadow ">
            <div class="box-header bg-transparent">
                <h3 class="box-title">
                    <span>Información Básica</span>
                </h3>
            </div>

            <div class="box-body">
                <!-- row -->
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-12 columns">
                                <h4>Datos del docente</h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="medium-4 columns">
                                <label>
                                    Nombre(s)
                                <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Apellido paterno
                                <asp:TextBox runat="server" ID="txtApPaterno"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Apellido materno
                                <asp:TextBox runat="server" ID="txtApMaterno"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Nacionalidad
                                <asp:TextBox runat="server" ID="txtNacionalidad"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Teléfono de contacto
                                <asp:TextBox runat="server" ID="txtTelContacto" MaxLength="10"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Correo
                                <asp:TextBox runat="server" ID="txtCorreo"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    CURP / ID Nacionalidad
                                        <asp:TextBox runat="server" ID="txtCURP">
                                        </asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Fecha Nacimiento
                                </label>

                                <div class="medium-4 columns">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlDia"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-4 columns">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlMes"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-4 columns">
                                    <label>
                                        <asp:TextBox runat="server" ID="txtAnio" placeholder="Año"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <fieldset class="large-4 columns">
                                <legend>Sexo</legend>
                                <asp:RadioButtonList runat="server" ID="rblSexo" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Hombre</asp:ListItem>
                                    <asp:ListItem Value="2">Mujer</asp:ListItem>
                                </asp:RadioButtonList>
                            </fieldset>

                            <fieldset class="large-6 columns">
                                <legend>Estado civil</legend>
                                <asp:RadioButtonList runat="server" ID="rblEdoCivil" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Soltero</asp:ListItem>
                                    <asp:ListItem Value="2">Casado</asp:ListItem>
                                    <asp:ListItem Value="3">Divorciado</asp:ListItem>
                                    <asp:ListItem Value="4">Otro</asp:ListItem>
                                </asp:RadioButtonList>
                            </fieldset>
                            <div class="medium-2 columns">
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="large-12 columns">
                                <div class="row">
                                    <div class="medium-12 columns">
                                        <h4>Vivienda</h4>
                                    </div>

                                    <div class="medium-4 columns">
                                        <label>
                                            Calle
                                    <asp:TextBox runat="server" ID="txtCalle"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="medium-2 columns">
                                        <label>
                                            Número exterior
                                    <asp:TextBox runat="server" ID="txtNumero"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="medium-2 columns">
                                        <label>
                                            Número interior
                                        <asp:TextBox runat="server" ID="txtNumeroInt"></asp:TextBox>
                                        </label>
                                    </div>

                                    <div class="medium-4 columns">
                                        <label>
                                            Colonia
                                    <asp:TextBox runat="server" ID="txtColonia"></asp:TextBox>
                                        </label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="large-3 columns">
                                        <label>
                                            Selecciona pais		
                                   <asp:DropDownList runat="server" ID="ddlPais" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"
                                       AutoPostBack="true"
                                       AppendDataBoundItems="false">
                                   </asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="large-4 columns">
                                        <label>
                                            Selecciona estado
									<asp:DropDownList runat="server" ID="ddlEstado" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                        AutoPostBack="true"
                                        AppendDataBoundItems="false">
                                    </asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="medium-3 columns">
                                        <label>
                                            Ciudad
                                    <asp:DropDownList runat="server" ID="ddlCiudad"></asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="medium-2 columns">
                                        <label>
                                            Código Postal
                                    <asp:TextBox runat="server" ID="txtCP"></asp:TextBox>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="box no-shadow ">
            <div class="box-header bg-transparent">
                <h3 class="box-title">
                    <span>Información Académica</span>
                </h3>
            </div>

            <div class="box-body">
                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-12 columns">
                                <h4>Información Académica</h4>
                            </div>
                        </div>

                        <div class="large-12 columns">
                            <div class="row">
                                <fieldset class="large-6 columns">
                                    <legend>Tipo de docente</legend>
                                    <asp:RadioButtonList runat="server" ID="rblTipoDocente" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">Planta</asp:ListItem>
                                        <asp:ListItem Value="2">Honorarios</asp:ListItem>
                                        <asp:ListItem Value="3">Invitado</asp:ListItem>
                                    </asp:RadioButtonList>
                                </fieldset>
                            </div>
                        </div>

                        <div class="large-12 columns">
                            <div class="row">
                                <div class="large-7 columns">
                                    <label>
                                        Carrera
										  <asp:DropDownList runat="server" ID="DdlCarrera"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-5 columns">
                                    <label>
                                        Fecha de ingreso
                                    </label>

                                    <div class="medium-4 columns">
                                        <label>
                                            <asp:DropDownList runat="server" ID="ddlDiaI"></asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="medium-4 columns">
                                        <label>
                                            <asp:DropDownList runat="server" ID="ddlMesI"></asp:DropDownList>
                                        </label>
                                    </div>

                                    <div class="medium-4 columns">
                                        <label>
                                            <asp:TextBox runat="server" ID="txtAnioI" placeholder="Año"></asp:TextBox>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Laboral
    <div class="box no-shadow ">
        <div class="box-header bg-transparent">
            <h3 class="box-title"><i class="ti-view-list palette-Indigo-700 text"></i>
                <span>Información Laboral</span>
            </h3>
        </div>

        <div class="box-body" id="grid">
            <div class="row">
                <div class="large-12 columns">
                    <label>
                        Breve descripción de tí
                        <asp:TextBox runat="server" ID="txtDescripcion" MaxLength="400" TextMode="MultiLine"></asp:TextBox>
                    </label>

                    <div class="row">
                        <div class="medium-4 columns">
                            <label>
                                Centro Educativo
                                    <asp:TextBox runat="server" ID="txtCentroE"></asp:TextBox>
                            </label>
                        </div>
                        <div class="medium-2 columns">
                            <label>
                                Años
                                    <asp:TextBox runat="server" ID="txtAnios"></asp:TextBox>
                            </label>
                        </div>
                        <div class="medium-2 columns">
                            <label>
                                Materia
                                    <asp:TextBox runat="server" ID="txtMateria"></asp:TextBox>
                            </label>
                        </div>

                        <div class="medium-2 columns">
                            <label>
                                Agregar 
                                    <br />
                                <asp:Button runat="server" ID="btnAgregar" autopostback="false"
                                    CssClass="button palette-Deep-Purple-700 bg"
                                    ssClass="button" Text=" + "
                                    OnClick="BtnAgregar_Click" />
                            </label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <asp:GridView runat="server" ID="gvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" HorizontalAlign="Left">
                            <Columns>
                                <asp:BoundField HeaderText="Centro Educativo" DataField="CentroEducativo">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Años" DataField="Anios">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Materia" DataField="Materia">
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
    -->

    <div class="box no-shadow ">
        <div class="box-header bg-transparent">
            <h3 class="box-title">
                <span>Activo</span>
            </h3>
        </div>

        <div class="box-body">
            <div class="row">
                <div class="large-12 columns">
                    <div class="row">
                        <div class="medium-12 columns">
                            <h4>Activo</h4>
                        </div>
                    </div>

                    <div class="large-12 columns">
                        <div class="row">

                            <div class="medium-12 columns">
                                <label>
                                    Activo
                                    <asp:CheckBox runat="server" ID="chkActivo" Checked="true" />
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <hr />

            <div class="row">
                <div class="large-12 columns">
                    <div class="row">
                        <div class="medium-12 columns">
                            <asp:Button runat="server" Text="Guardar" ID="btnGUardar" OnClick="btnGuardar_Click"
                                CssClass="button palette-Deep-Purple-700 bg" />
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
