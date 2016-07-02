<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DatosPaciente.aspx.cs" Inherits="MyHospital.Paciente.DatosPaciente" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
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
        <asp:HiddenField runat="server" ID="hfIdPaciente" Visible="false" />
        <asp:HiddenField runat="server" ID="hfIdDireccion" Visible="false" />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Datos del paciente</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <table class="table" style="table-layout:fixed;">
	                        <tr>
		                        <td>
			                        Apellido paterno
			                        <asp:TextBox runat="server" ID="txtApellidoPaterno" CssClass="form-control" />
		                        </td>
		                        <td>
			                        Apellido materno
			                        <asp:TextBox runat="server" ID="txtApellidoMaterno" CssClass="form-control" />
		                        </td>
		                        <td colspan="2">
			                        Nombre (s)
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
		                        </td>
	                        </tr>
                            <tr>
                                <td>
			                        Fecha de nacimiento
			                        <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" />
		                        </td>
                                <td>
			                        Sexo
			                        <asp:DropdownList runat="server" ID="ddlSexo" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-- Seleccione una opcion --  "></asp:ListItem>
                                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                        </asp:DropdownList>
		                        </td>
		                        <td>
			                        Grupo sanguineo
			                        <asp:DropdownList runat="server" ID="ddlGpoSanguineo" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Text="-- Seleccione una opcion --  "></asp:ListItem>
                                        </asp:DropdownList>
		                        </td>
                                <td>
			                        N.S.S.
			                        <asp:TextBox runat="server" ID="txtNSS" CssClass="form-control" />
		                        </td>
                            </tr>
                            <tr>
                                <td>
			                        Telefono
			                        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
		                        </td>
                                <td>
			                        Celular
			                        <asp:TextBox runat="server" ID="txtCel" CssClass="form-control" />
                                </td>
                                <td colspan="2">
			                        Correo electronico
			                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
		                        </td>
<%--                                <td>
			                        Seguro Médico
		                        </td>
		                        <td colspan="2">
			                        <asp:DropdownList runat="server" ID="ddlSeguroMedico" CssClass="form-control" AppendDataBoundItems="true">
                                        </asp:DropdownList>
		                        </td>
                            </tr>
                            <tr>
		                        <td>
			                        Número de póliza
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtNoPoliza" CssClass="form-control" />
		                        </td>
		                        <td>
			                        Número de tarjeta
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtNoTarjeta" CssClass="form-control" />
		                        </td>--%>
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
                                <td>
			                        Codigo postal
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCP" AutoPostBack="true" OnTextChanged="txtCP_TextChanged" MaxLength="5" ></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    Colonia:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlColonia"></asp:DropDownList>
                                </td>
                            
                                <td>
                                    Delegacion / Municipio:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDelegacion"></asp:DropDownList>
                                </td>
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
                            <asp:button runat="server" ID="btnGuardar" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" /> &nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:button runat="server" ID="btnCancelar" class="btn btn-danger" OnClick="btnCancelar_Click" Text="Cancelar"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
