<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="VerPacientes.aspx.cs" Inherits="MyHospital.Pacientes.VerPacientes" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="Form1" runat="server">
        <h2>    
            <asp:Label ID="lblTitle" CssClass="h2" runat="server">
                Ver pacientes
            </asp:Label>
        </h2>
    </form>
</asp:Content>