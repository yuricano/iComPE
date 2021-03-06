<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeFile="AdminAlumnoView.aspx.cs"
    Inherits="app_Administracion_AdminAlumnoView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Administración de cuenta del alumno</h2>

        <div class="box no-shadow ">
            <div class="box-body">
                <div class="box-header bg-transparent">
                    <h3 class="box-title">
                        <span>Alumno</span>
                    </h3>
                </div>

                <div class="row">
                    <div class="large-12 columns">
                        <div class="row">
                            <div class="medium-4 columns">
                                <label>
                                    Carrera
                                        <asp:DropDownList runat="server" ID="DdlCarrera" Enabled="false"></asp:DropDownList>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    Periodo                                       
                                    <asp:DropDownList runat="server" ID="DdlPeriodo" Enabled="false"></asp:DropDownList>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    &nbsp;
                                </label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="medium-4 columns">
                                <label>
                                    Nombre
                                        <asp:TextBox runat="server" ID="txtNombre" Enabled="false"></asp:TextBox>
                                </label>
                            </div>

                            <div class="medium-4 columns">
                                <label>Matrícula</label>
                                <h3>
                                    <asp:TextBox runat="server" ID="txtMatricula" placeholder="00000" Enabled="false"></asp:TextBox>
                                </h3>
                            </div>

                            <div class="medium-4 columns">
                                <label>
                                    &nbsp;
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="box no-shadow ">
            <div class="box-header bg-transparent">
                <h3 class="box-title">
                    <span>Conceptos</span>
                </h3>
            </div>

            <div class="box-body">
                <!-- row -->
                <div class="row">
                    <div class="large-12 columns">
                        <div class="medium-4 columns">
                            <label>
                                Ingreso / Egreso
                                    <asp:DropDownList runat="server" ID="DdlIngresoEgreso"
                                        AutoPostBack="true"
                                        AppendDataBoundItems="false"
                                        OnSelectedIndexChanged="DdlIngresoEgreso_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </label>
                        </div>
                    </div>

                    <div class="large-12 columns">
                        <div class="medium-6 columns">
                            <label>
                                Concepto
                                    <asp:DropDownList runat="server" ID="DdlConcepto"
                                        AutoPostBack="true"
                                        AppendDataBoundItems="false" OnSelectedIndexChanged="DdlConcepto_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-6 columns">
                            <label>
                                Descuento
                                    <asp:DropDownList runat="server" ID="DdlDescuento"
                                        AutoPostBack="true"
                                        AppendDataBoundItems="false"
                                        OnSelectedIndexChanged="DdlDescuento_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </label>
                        </div>
                    </div>

                    <div class="large-12 columns">
                        <div class="medium-3 columns">
                            <label>
                                Importe
                                    <asp:TextBox runat="server" ID="txtImporte" placeholder="$0.00" Enabled="false"></asp:TextBox>
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                Descuento $
                                    <asp:TextBox runat="server" ID="txtDescuentoMoneda" placeholder="$0.00" Enabled="false"></asp:TextBox>
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                Descuento %
                                    <asp:TextBox runat="server" ID="txtDescuentoPorcentaje" placeholder="0" Enabled="false"></asp:TextBox>
                            </label>
                        </div>
                    </div>

                    <div class="large-12 columns">
                        <div class="medium-3 columns">
                        </div>

                        <div class="medium-3 columns">
                        </div>

                        <div class="medium-3 columns">
                        </div>

                        <div class="large-3 columns">
                            <label>
                                Total
                                    <asp:TextBox runat="server" ID="txtTotal" placeholder="$0.00" Enabled="false"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    
                    <div class="large-12 columns">
                        <div class="medium-3 columns">
                            <label>
                                Tipo de transferencia
                                <asp:DropDownList runat="server" ID="DdlTipoTransferrencia">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        <asp:ListItem Value="1">Pago con TC/TD</asp:ListItem>
                                        <asp:ListItem Value="2">Depósito Bancario</asp:ListItem>
                                        <asp:ListItem Value="3">Depósito Tienda Conveniencia</asp:ListItem>
                                        <asp:ListItem Value="3">Otro</asp:ListItem>
                                    </asp:DropDownList>
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                Número de TC/TD
                                    <asp:TextBox runat="server" ID="TxtTCTD" 
                                        Enabled="true"></asp:TextBox>
                            </label>
                        </div>

                        <div class="medium-3 columns">
                            <label>
                                Fecha de vencimiento
                                    <asp:TextBox runat="server" ID="TxtVencimiento" placeholder="00/00" 
                                        Enabled="true"></asp:TextBox>
                            </label>
                        </div>
                        
                        <div class="medium-3 columns">
                            <label>
                                CVV
                                    <asp:TextBox runat="server" ID="TxtCVV" placeholder="000" 
                                        Enabled="true"></asp:TextBox>
                            </label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="large-12 columns">

                            <asp:Button runat="server" Text="Regresar" ID="BtnRegresar" OnClick="BtnRegresar_Click"
                                CssClass="button palette-Deep-Purple-700 bg" />

                            <asp:Button runat="server" Text="Guardar" ID="BtnGUardar" OnClick="BtnGuardar_Click"
                                CssClass="button palette-Deep-Purple-700 bg" />
                        </div>
                    </div>
                </div>
            </div>

            <hr />

            <div class="box no-shadow ">
                <div class="box-header bg-transparent">
                    <h3 class="box-title">
                        <span>Historico</span>
                    </h3>
                </div>

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
