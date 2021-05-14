<%@ Page Title="" Language="C#" MasterPageFile="~/Docente.master" 
    AutoEventWireup="true" CodeFile="CalendarioView.aspx.cs" Inherits="app_Docente_CalendarioView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Calendario</h2>

        <div class="box no-shadow ">
            <div class="box-body">

                <div class="row">
                    <div class="large-12 columns">
                        <div class="medium-8 columns">
                            <asp:Calendar runat="server" ID="Calendar1"
                                OnDayRender="Calendar1_DayRender"
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
