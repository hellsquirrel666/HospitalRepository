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
        <asp:HiddenField runat="server" ID="hfIdUsuario" Visible="false" />
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
			                        <asp:TextBox runat="server" ID="txtApellidoPaterno" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ID="rfvPaterno" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtApellidoPaterno" ValidationGroup="desc" ErrorMessage="Apellido paterno es obligatorio"  />
		                        </td>
		                        <td>
			                        Apellido materno
			                        <asp:TextBox runat="server" ID="txtApellidoMaterno" CssClass="form-control" />
		                        </td>
		                        <td>
			                        Nombre (s)
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtNombre" ValidationGroup="desc" ErrorMessage="Nombre es obligatorio"  />
		                        </td>
	                        </tr>
                            <tr>
                                <td>
			                        Tipo de usuario
			                        <asp:DropDownList runat="server" ID="ddlRoles" CssClass="form-control" />
		                        </td>
                                <td>
			                        Foto
		                            <asp:FileUpload ID="fuImagen" runat="server" />
		                        </td>
                            </tr>
                            <tr>
                                <td>
			                        Usuario
			                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ID="rfvUsuario" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtUsuario" ValidationGroup="desc" ErrorMessage="Usuario es obligatorio"  />
		                        </td>
                                <td>
			                        Contraseña
			                        <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" TextMode="Password" />
                                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtApellidoPaterno" ValidationGroup="desc" ErrorMessage="Contraseña es obligatoria"  />

		                        </td>
                                <td>
			                        Confirmar contraseña
			                        <asp:TextBox runat="server" ID="txtConfirmaConstraseña" CssClass="form-control" TextMode="Password" />
		                        </td>
	                        
                        </table>
                        <div class="form-group" style="text-align:right">
                            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click"/>
                            <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" class="btn btn-danger" OnClick="btnCancelar_Click"/>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        </form>
</asp:Content>
