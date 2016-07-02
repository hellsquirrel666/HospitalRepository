<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DatosClinica.aspx.cs" Inherits="MyHospital.Administar.DatosClinica" %>
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
                    <h2>Datos del hospital</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <table class="table" style="table-layout:fixed;">
	                        <tr>
		                        <td colspan="3">
			                       Nombre
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
		                        </td>
	                        </tr>
                            <tr>
                                <td>
			                        Logo
			                        <asp:FileUpload ID="fuLogo" runat="server"/>
		                        </td>
		           
                            </tr>
                            <tr>
                                <td>
			                        Telefono 1
			                        <asp:TextBox runat="server" ID="txtTel1" CssClass="form-control" />
		                        </td>
                               
                                <td>
			                        Telefono 2
			                        <asp:TextBox runat="server" ID="txtxTel2" CssClass="form-control" />
		                        </td>
                                <td>
                                    Correo Electronico
			                        <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" />
		                        </td>
	                        </tr>
                            <tr>
		                        <td>
                                    Calle:
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCalle"></asp:TextBox>
                                </td>
                                 <td>
                                    No. Ext.:
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNoExt"></asp:TextBox>
                                </td>
                                <td>
                                    No. Int.:
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNoInt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td>
			                        Codigo postal
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCP" AutoPostBack="true" OnTextChanged="txtCP_TextChanged" TextMode="Number" ></asp:TextBox>
                                </td>
                                <td>
                                    Colonia:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlColonia"></asp:DropDownList>
                                </td>
                                <td>
                                    Delegacion / Municipio:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDelegacion"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ciudad:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCiudad"></asp:DropDownList>
                                </td>
                                <td>
                                    Estado:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado"></asp:DropDownList>
                                </td>
                            </tr>
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
