<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno.master" AutoEventWireup="true" CodeFile="EdoCtaView.aspx.cs" Inherits="app_Alumno_EdoCtaView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Estado de cuenta</h2>
        <div class="box">
            <!-- /.box-header -->
            <div class="box-body " style="display: block;">
                <div class="row">
                    <div class="row">
                        <div class="large-12 columns">
                            <div class="large-9 columns">
                                <label>Desde</label>

                                <div class="medium-3 columns">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlDiaI"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-3 columns">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlMesI"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-3 columns">
                                    <label>
                                        <asp:TextBox runat="server" ID="txtAnioI" placeholder="Año"></asp:TextBox>
                                    </label>
                                </div>

                                <div class="medium-3 columns">
                                    <label>
                                        &nbsp;
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="large-12 columns">
                            <div class="large-9 columns">
                                <label>Hasta</label>
                                <div class="medium-3 columns">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlDiaF"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-3 columns">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlMesF"></asp:DropDownList>
                                    </label>
                                </div>

                                <div class="medium-3 columns">
                                    <label>
                                        <asp:TextBox runat="server" ID="txtAnioF" placeholder="Año"></asp:TextBox>
                                    </label>
                                </div>

                                <div class="medium-3 columns">
                                    <label>
                                        &nbsp;
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- 
                    <div class="row">
                        <div class="large-12 columns">
                            <div class="large-9 columns">

                                <div class="large-6 columns">
                                    <label>
                                        Estado Pago
                                <asp:DropDownList runat="server" ID="ddlEstado"></asp:DropDownList>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                        -->

                    <div class="row">
                        <div class="large-12 columns">
                            <div class="large-6 columns">
                                <label></label>
                                <asp:Button Style="margin-left: 10px;" runat="server" Text="Filtrar" ID="btnFiltrar"
                                    OnClick="btnFiltrar_Click" CssClass="button success" />
                            </div>

                            <!-- 
                            <div class="large-6 columns">
                                <label></label>
                                <asp:Button Style="margin-left: 10px;" runat="server" Text="Pagar" ID="btnPagar"
                                    OnClick="btnPagar_Click" CssClass="button success" />
                            </div>
-->
                        </div>
                    </div>

                    <hr />

                    <div class="box-body">
                        <!-- row -->
                        <div class="row">
                            <div class="large-12 columns">
                                <div class="row">
                                    <div class="large-12 columns">
                                        <asp:GridView runat="server" ID="gvDatos" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" HorizontalAlign="Left">
                                            <Columns>
                                                <asp:BoundField HeaderText="Concepto" DataField="nombreconcepto">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="Importe" DataField="importe">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="$ Descuento" DataField="descuento">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="% Descuento" DataField="pctdescuento">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="Total" DataField="total">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="Fecha Movimiento" DataField="fechamov">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="Pagado" DataField="pagadoTxt">
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
            <div class="box-body " style="display: block; background-color: #ffffff">
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
