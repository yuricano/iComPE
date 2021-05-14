<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Calendario.aspx.cs" Inherits="app_Administracion_Calendario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Calendario</h2>

        <div class="box no-shadow ">
            <div class="box-body">
                <div class="row">
                    <div class="large-9 columns">
                        <div class="large-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlDia"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMes"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlAnio"></asp:DropDownList>
                            </label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <div class="medium-7 columns">
                            <label>
                                Evento
                            <asp:TextBox runat="server" ID="txtEvento" placeholder="Evento"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <div class="medium-7 columns">

                            <label>
                                Activo
                                    <asp:CheckBox runat="server" ID="chkActivo" Checked="true" />
                            </label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <div class="medium-7 columns">
                            <asp:Button runat="server" Text="Regresar" ID="btnRegresar" OnClick="btnRegresar_Click"
                                CssClass="button palette-Deep-Purple-700 bg" />
                            
                            <asp:Button runat="server" Text="Guardar" ID="btnGUardar" OnClick="btnGuardar_Click"
                                CssClass="button palette-Deep-Purple-700 bg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="large-12 columns">
                <div class="medium-8 columns">
                    <asp:Calendar runat="server" ID="Calendar1"
                        OnDayRender="Calendar1_DayRender"
                        OnSelectionChanged="Calendar1_SelectionChanged"
                        DayStyle-Height="100" DayStyle-Width="75" DayStyle-HorizontalAlign="Left"
                        DayStyle-VerticalAlign="Top"
                        DayStyle-Font-Name="Arial" DayStyle-Font-Size="12"
                        NextPrevFormat="FullMonth" SelectionMode="Day"
                        TitleStyle-Font-Bold="False" TitleStyle-Font-Name="Verdana"
                        TitleStyle-Font-Size="12" BackColor="white" BorderColor="#000000"
                        CellPadding="2" CellSpacing="2"
                        SelectedDayStyle-BackColor="#faebd7"
                        SelectedDayStyle-ForeColor="#000000"
                        OtherMonthDayStyle-ForeColor="#C0C0C0" DayStyle-BorderStyle="Solid"
                        DayStyle-BorderWidth="1" TodayDayStyle-ForeColor="Black" Height="600"
                        DayHeaderStyle-Font-Name="Verdana"
                        Width="750"></asp:Calendar>
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
