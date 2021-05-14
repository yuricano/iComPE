<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno.master" AutoEventWireup="true" CodeFile="Aviso.aspx.cs" Inherits="app_Perfiles_Aviso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class=" fondo-oscuro padding">
        <h3 class="texto-blanco center padding20">Aviso de privacidad</h3>

        <div id="aviso" class="fondo-oscuro padding">
            <div class="grid-x grid-padding-x">
                <div class="large-12 medium-4 small-12 cell">
                    <object data="../../assets/legal/AvisoPrivacidad.pdf" type="application/pdf" width="100%" height="650px">
                        <iframe src="https://docs.google.com/viewer?url=your_url_to_pdf&embedded=true"></iframe>
                    </object>
                </div>

                <br />

                <div class="large-12 medium-4 small-12 cell">
                    <div class="center">
                        <a target="_blank" href="../../assets/legal/AvisoPrivacidad.pdf" class="button">Descargar Aviso de privacidad</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
