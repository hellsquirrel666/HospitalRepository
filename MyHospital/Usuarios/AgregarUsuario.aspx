<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="MyHospital.Usuarios.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="Form1" runat="server" class="right_col" role="main">
        <div class="page-title">
            <div class="title_left">
                <h3>Registrar datos</h3>
            </div>
            <div class="title_right">
                <h3></h3>
            </div>
        </div>

        <div class="clearfix"></div>
        
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Datos del usuario</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <table class="table" style="table-layout:fixed;">
	                        <tr>
		                        <td>
			                        Apellido paterno
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtApellidoPaterno" CssClass="form-control" />
		                        </td>
		                        <td>
			                        Apellido materno
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtApellidoMaterno" CssClass="form-control" />
		                        </td>
		                        <td>
			                        Nombre (s)
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
		                        </td>
	                        </tr>
                            <tr>
                                <td>
			                        Tipo de usuario
		                        </td>
		                        <td colspan="2">
			                        <asp:DropDownList runat="server" ID="ddlRoles" CssClass="form-control" />
		                        </td>
                                <td>
			                        Foto
		                        </td>
		                        <td colspan="4">
		                            <asp:FileUpload ID="fuImagen" runat="server" />
		                        </td>
                            </tr>
                            <tr>
                                <td>
			                        Usuario
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
		                        </td>
                                <td>
			                        Contraseña
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" OnTextChanged="txtCel_TextChanged" />
		                        </td>
                                <td>
			                        Confirmar contraseña
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtConfirmaConstraseña" CssClass="form-control" />
		                        </td>
	                        
                        </table>
                        <div class="form-group" style="text-align:right">
                            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </form>
</asp:Content>
