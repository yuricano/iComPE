<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeFile="ConceptoView.aspx.cs" Inherits="app_Administracion_ConceptoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Concepto</h2>
        <div class="box">

            <div class="box-body " style="display: block;">

                <div class="row">
                    <div class="large-4 columns">
                        <p><strong>Concepto</strong> </p>
                    </div>
                </div>

                <div class="row">
                    <div class="large-6 columns">
                        <label>
                            Nombre de concepto
                            <asp:TextBox runat="server" ID="txtConcepto"></asp:TextBox>
                        </label>
                    </div>
                    <div class="large-2 columns">
                        <label>
                            Abreviatura
                            <asp:TextBox runat="server" ID="txtAbreviatura"></asp:TextBox>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-4 columns">
                        <label>
                            Ingreso / Egreso
                            <asp:RadioButtonList runat="server" ID="rblIE" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">Ingreso</asp:ListItem>
                                <asp:ListItem>Egreso</asp:ListItem>
                            </asp:RadioButtonList>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-10 columns">
                        <label>
                            Descripción
                            <asp:TextBox runat="server" ID="txtDecripcion"></asp:TextBox>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-4 columns">
                        <p><strong>Parámetros de facturación</strong> </p>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="large-6 columns">
                                <label>
                                    Importe
                                    <asp:TextBox runat="server" ID="txtImporte" placeholder="$0.00"></asp:TextBox>
                                </label>
                            </div>

                            <div class="large-2 columns">
                                <label>
                                    Vencimiento
                            <asp:TextBox runat="server" ID="txtDiasVencimiento" placeholder="Días"></asp:TextBox>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="large-6 columns">
                        <label>
                            Descuento por pago anticipado
                                <asp:RadioButtonList runat="server" ID="rblPagoAnticipado" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">Porcentaje</asp:ListItem>
                                    <asp:ListItem>Fijo</asp:ListItem>
                                </asp:RadioButtonList>
                        </label>
                    </div>

                    <div class="large-4 columns">
                        <label>
                            Valor
                            <asp:TextBox runat="server" ID="txtValorDesc" placeholder="Porcentaje/Fijo"></asp:TextBox>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-6 columns">
                        <label>
                            Recargo por mora
                                <asp:RadioButtonList runat="server" ID="rblMora" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">Porcentaje</asp:ListItem>
                                    <asp:ListItem>Fijo</asp:ListItem>
                                </asp:RadioButtonList>
                        </label>
                    </div>

                    <div class="large-4 columns">
                        <label>
                            Valor
                            <asp:TextBox runat="server" ID="txtValorRecargo" placeholder="Porcentaje/Fijo"></asp:TextBox>
                        </label>
                    </div>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <label>
                            Recargo aplicado a
                        <asp:RadioButtonList runat="server" ID="rblAplicadoA" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">Valor del importe por día vencido</asp:ListItem>
                            <asp:ListItem>Valor del importe por mes vencido</asp:ListItem>
                            <asp:ListItem>Valor del importe</asp:ListItem>
                        </asp:RadioButtonList>
                        </label>
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

                        <asp:Button runat="server" Text="Regresar" ID="btnRegresar" OnClick="btnRegresar_Click"
                            CssClass="button palette-Deep-Purple-700 bg" />

                        <asp:Button runat="server" Text="Guardar" ID="btnGUardar" OnClick="btnGuardar_Click"
                            CssClass="button palette-Deep-Purple-700 bg" />
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
