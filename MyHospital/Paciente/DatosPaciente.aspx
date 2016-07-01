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
			                        Fecha de nacimiento
		                        </td>
		                        <td>
			                        <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" />
		                        </td>
                                <td>
			                        Sexo
		                        </td>
		                        <td colspan="2">
			                        <asp:DropdownList runat="server" ID="ddlSexo" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Text="-- Seleccione una opcion --  "></asp:ListItem>
                                        <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                                        <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                                        </asp:DropdownList>
		                        </td>
		                        <td>
			                        Grupo sanguineo
		                        </td>
		                        <td>
			                        <asp:DropdownList runat="server" ID="ddlGpoSanguineo" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Text="-- Seleccione una opcion --  "></asp:ListItem>
                                        </asp:DropdownList>
		                        </td>
                                <td>
			                        N.S.S.
		                        </td>
		                        <td>
			                        <asp:TextBox runat="server" ID="txtNSS" CssClass="form-control" />
		                        </td>
                            </tr>
                            <tr>
                                <td>
			                        Telefono
		                        </td>
		                        <td>
			                        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
		                        </td>
                                <td>
			                        Celular
		                        </td>
		                        <td>
			                        <asp:TextBox runat="server" ID="txtCel" CssClass="form-control" />
		                        </td>
                                <td>
			                        e-mail
		                        </td>
		                        <td>
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
		                        <td>
                                    Calle:
                                </td>
                                <td colspan="2">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCalle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    No. Ext.:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNoExt"></asp:TextBox>
                                </td>
                                <td>
                                    No. Int.:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNoInt"></asp:TextBox>
                                <td>
			                        Codigo postal
		                        </td>
		                        <td>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCP" AutoPostBack="true" OnTextChanged="txtCP_TextChanged" TextMode="Number" ></asp:TextBox>
                                </td>
                                <td>
                                    Colonia:
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlColonia"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Delegacion / Municipio:
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDelegacion"></asp:DropDownList>
                                </td>
                                <td>
                                    Ciudad:
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCiudad"></asp:DropDownList>
                                </td>
                                <td>
                                    Estado:
                                </td>
                                <td colspan="2">
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
