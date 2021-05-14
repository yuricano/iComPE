<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DescuentoView.aspx.cs"
    Inherits="app_Administracion_DescuentoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Descuento</h2>
        <div class="box">
            <div class="box-body " style="display: block;">
                <div class="row">
                    
                    <div class="large-6 columns">
                        <label>
                            Descuento
                            <asp:TextBox runat="server" ID="txtDescuento" placeholder="Nombre descuento"></asp:TextBox>
                        </label>
                    </div>

                    <div class="large-6 columns">
                        <label>
                            Aplicado a (Concepto)
                            <asp:DropDownList runat="server" ID="DdlConcepto"></asp:DropDownList>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-3 columns">
                        <label>
                            Importe
                            <asp:TextBox runat="server" ID="txtImporte" placeholder="$0.00"></asp:TextBox>
                        </label>
                    </div>

                    <div class="large-3 columns">
                        <label>
                            Porcentaje
                            <asp:TextBox runat="server" ID="txtPorcentaje" placeholder="0 %"></asp:TextBox>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-4 columns">
                        <p><strong>Programación de pago</strong> </p>
                    </div>
                </div>

                <div class="row">
                    <div class="large-6 columns">
                        <div class="row">
                            <div class="large-8 columns">
                                <label>
                                    Periocidad
                                    <asp:DropDownList runat="server" ID="ddlPeriocidad">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        <asp:ListItem Value="1">Día</asp:ListItem>
                                        <asp:ListItem Value="2">Mes</asp:ListItem>
                                    </asp:DropDownList>
                                </label>
                            </div>
                            <div class="large-4 columns">
                                <label>
                                    Duración
                                    <asp:TextBox runat="server" ID="txtDuracion" placeholder="Días / Meses"></asp:TextBox>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-9 columns">
                        <label>
                            Inicia
                        </label>
                        <div class="medium-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlDiaI"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMesI"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlAnioI"></asp:DropDownList>
                            </label>
                        </div>
                    </div>
                </div>

                <!--
                <div class="row">
                    <div class="large-9 columns">
                        <label>
                            Termina
                        </label>
                        <div class="medium-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlDiaF"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMesF"></asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-2 columns">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlAnioF"></asp:DropDownList>
                            </label>
                        </div>
                    </div>
                </div>
                -->

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
                            <asp:Button runat="server" Text="Guardar" ID="btnGUardar" OnClick="btnGuardar_Click"
                                CssClass="button palette-Deep-Purple-700 bg" />

                            <asp:Button runat="server" Text="Regresar" ID="btnRegresar" OnClick="btnRegresar_Click"
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
