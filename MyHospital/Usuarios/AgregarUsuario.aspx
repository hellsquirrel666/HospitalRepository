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
                            <col style="width:33%;"/>
                            <col style="width:1%;"/>
                            <col style="width:33%;"/>
                            <col style="width:1%;"/>
	                        <tr>
		                        <td>
			                        Apellido paterno
			                        <asp:TextBox runat="server" ID="txtApellidoPaterno" CssClass="form-control" />
                                </td>
                                <td style="width: 23px">
                                    <asp:RequiredFieldValidator runat="server" ID="rfvPaterno" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtApellidoPaterno" ValidationGroup="desc">*</asp:RequiredFieldValidator>
		                        </td>
		                        <td style="width: 440px">
			                        Apellido materno
			                        <asp:TextBox runat="server" ID="txtApellidoMaterno" CssClass="form-control" />
		                        </td>
		                        <td colspan="2">
			                        Nombre (s)
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                                </td>
                                <td style="width: 23px">
                                    <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtNombre" ValidationGroup="desc" >*</asp:RequiredFieldValidator>
		                        </td>
	                        </tr>
                            <tr>
                                <td>
			                        Tipo de usuario
			                        <asp:DropDownList runat="server" ID="ddlRoles" CssClass="form-control" />
                                     </td>
                                <td style="width: 23px">
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="ddlRoles" ValidationGroup="desc"  InitialValue="--Seleccionar--">*</asp:RequiredFieldValidator>
		                        </td>
                                <td colspan="3">
			                        Foto
		                            <asp:FileUpload ID="fuImagen" runat="server" accept=".png,.jpg,.jpeg,.gif"/>
		                        </td>
                            </tr>
                            <tr>
                                <td>
			                        Usuario
			                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
                                </td>
                                <td style="width: 23px">
                                    <asp:RequiredFieldValidator runat="server" ID="rfvUsuario" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtUsuario" ValidationGroup="desc" >*</asp:RequiredFieldValidator>
		                        </td>
                                <td style="width: 440px">
			                        Contraseña
			                        <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" TextMode="Password" />
                                </td>
                                <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtContraseña" ValidationGroup="desc">*</asp:RequiredFieldValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="txtContraseña" 
                                        ErrorMessage="** La contraseña debe tener como minimo de 6 digitos y al menos un número.<br />" 
                                        ForeColor="Red" Display="Dynamic" 
                                        ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,12})$" 
                                        ValidationGroup="desc"> **</asp:RegularExpressionValidator>
		                        </td>
                                <td>
			                        Confirmar contraseña
			                        <asp:TextBox runat="server" ID="txtConfirmaConstraseña" CssClass="form-control" TextMode="Password" />
                                             
                                </td>
                                <td style="width: 23px">
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtConfirmaConstraseña" ValidationGroup="desc">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator id="comparePasswords" runat="server"  ControlToCompare="txtContraseña" ControlToValidate="txtConfirmaConstraseña"
                                        ErrorMessage="*** Las contraseñas introducidas no son iguales.  <br />" Type="String" ForeColor="Red" ValidationGroup="desc">***</asp:CompareValidator>
	                          
		                        </td>
                               
                        </table>
                         <asp:ValidationSummary id="RequiredFieldValidator1" HeaderText="Los campos marcados con asterisco * son obligatorios. <br />"
                                 ForeColor="Red" Display="Dynamic" Runat="server" ValidationGroup="desc" DisplayMode="SingleParagraph"/>
   
                        <div class="form-group" style="text-align:right">
                            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" ValidationGroup="desc"/>
                            <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" class="btn btn-danger" OnClick="btnCancelar_Click"/>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        </form>
</asp:Content>
