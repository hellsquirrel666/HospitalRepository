<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AgregarMedicamento.aspx.cs" Inherits="MyHospital.Medicamento.AgregarMedicamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="Form1" runat="server" class="right_col" role="main">
        <div class="page-title">
            <div class="title_left">
                <h3>Registrar datos</h3>
            </div>
            <div class="title_right">
                <h3>.</h3>
            </div>
        </div>

        <div class="clearfix"></div>
        
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Datos del medicamento</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <table class="table" style="table-layout:fixed;">
	                        <tr>
		                        <td>
			                        Nombre Medicamento:
		                        </td>
		                        <td colspan="5">
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
		                        </td>
	                        </tr>
                            <tr>
                                <td>
			                       Laboratorio:
		                        </td>
		                        <td colspan="2">
			                        <asp:TextBox runat="server" ID="txtLaboratorio" CssClass="form-control" />
		                        </td>
                                <td>
			                        Compartido:
		                        </td>
		                        <td colspan="2">
			                        <asp:DropdownList runat="server" ID="ddlSexo" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Text="-- Seleccione una opcion --  "></asp:ListItem>
                                        <asp:ListItem Text="Masculino" Value="Si"></asp:ListItem>
                                        <asp:ListItem Text="Femenino" Value="No"></asp:ListItem>
                                        </asp:DropdownList>
		                        </td>
                            </tr>
                            <tr>
                                <td>
			                        Composición:
		                        </td>
		                        <td colspan="5">
			                        <asp:TextBox runat="server" ID="txtComposicion" CssClass="form-control" TextMode="MultiLine" />
		                        </td>
                            </tr>
                            <tr>
		                        <td>
			                        Posologia
		                        </td>
		                        <td colspan="5">
			                        <asp:TextBox runat="server" ID="txtNoPoliza" CssClass="form-control" TextMode="MultiLine"/>
		                        </td>
                            <tr>
                                <td>
			                        Indicaciones:
		                        </td>
		                        <td colspan="5">
			                        <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" TextMode="MultiLine"/>
		                        </td>
                            </tr>
                            <tr>
                                <td>
			                        Contraindicaciones:
		                        </td>
		                        <td colspan="5">
			                        <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" TextMode="MultiLine"/>
		                        </td>
                            </tr>
                        </table>
                        <div class="form-group" style="text-align:right">
                            <button type="btnGuardar" class="btn btn-primary">Guardar</button> &nbsp&nbsp&nbsp&nbsp&nbsp
                            <button type="btnCancelar" class="btn btn-danger">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
