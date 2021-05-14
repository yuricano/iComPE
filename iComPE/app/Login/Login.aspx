<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login"
    ValidateRequest="false" EnableEventValidation="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="robots" content="index, follow" />
    <meta name="description" content="Nuestra modalidad facilita la accesibilidad académica, enriquece el aprendizaje tecnológico y favorece la internacionalización" />
    <meta name="abstract" content="En el Instituto nos caracterizamos por transmitir a nuestros estudiantes la pasión por su formación, y en su carrera, buscando potencializar su talento al máximo" />
    <meta name="keywords" content="iCom, universidad iCom, universidades en méxico, universidad en linea, universidad en línea, oferta educativa" />
    <meta name="Classification" content="education" />
    <meta name="designer" content="Yuri Cano" />
    <meta name="owner" content="iCom" />
    <meta name="category" content="education" />
    <meta name="coverage" content="Worldwide" />
    <meta name="distribution" content="Global" />
    <meta name="rating" content="General" />
    <meta name="revisit-after" content="7 days" />
    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta property="og:url" content="http://icom.education" />
    <meta property="og:title" content="iCom" />
    <meta name="google-site-verification" content="jMhpm59_pTQQXCTIrMqM81fGPDkfTgeA3Eg6UPKA-pQ" />
    <link rel="shortcut icon" type="image/x-icon" href="/logo.ico" />

    <title>iCom : Plataforma</title>

    <link rel="stylesheet" href="css/styleLogin.css">
</head>

<body>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

    <form id="frmLogin" runat="server" class="login-form">
        <div class="container">
            <div class="info">
                <h1>Inicio de sesión</h1>
                <span>Plataforma de Control Escolar y Enseñanza de iCom.</span>
            </div>
        </div>

        <div class="form">
            <div class="thumbnail">
                <img src="images/icons/hat.svg" />
            </div>

            <asp:Label ID="lblError" runat="server" Text="" CssClass="form-message" style="color:red !important;"  ></asp:Label>

            <div data-validate="Usuario">
                <asp:TextBox ID="txtUsuario" CssClass="input100" runat="server" placeholder="usuario"></asp:TextBox>
            </div>

            <div class="m-b-10">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="form-message"
                    runat="server" ErrorMessage="Usuario requerido!" ControlToValidate="txtUsuario">
                </asp:RequiredFieldValidator>
            </div>

            <div data-validate="Contrasena">
                <asp:TextBox ID="txtContrasena" CssClass="input100" runat="server" placeholder="contraseña" TextMode="Password">
                </asp:TextBox>
            </div>

            <div class="m-b-50">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="form-message" runat="server"
                    ErrorMessage="Contraseña requerida!" ControlToValidate="txtContrasena"></asp:RequiredFieldValidator>
            </div>
            
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" BackColor="#602F7E" 
                    style="color: white !important;"
                    CssClass="inputButton" />
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
                        <div class="large-12 columns alert-dark">
                            <div class="large-6 columns alert-dark">
                                <p class="align-content-center">
                                    <asp:Label runat="server" ID="lblMensaje"></asp:Label>
                                </p>
                                <asp:Button runat="server" Text="Cerrar" ID="btnClose" CssClass="button error" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>

    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="js/scriptLogin.js"></script>
</body>
</html>
