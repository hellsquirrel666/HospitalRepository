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
        <asp:HiddenField runat="server" ID="hfIdMedicamento" Visible="false" />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Datos del medicamento</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <table class="table" style="table-layout:fixed;">
                            <col style="width:44%;"/>
                            <col style="width:1%;"/>
                            <col style="width:44%;"/>
                            <col style="width:1%;"/>
	                        <tr>
		                        <td colspan="3">
			                        Nombre Medicamento:
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                                </td>
                                <td>  
                                    <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtNombre" ValidationGroup="desc">*</asp:RequiredFieldValidator>
		                        </td>
	                        </tr>
                            <tr>
                                <td>
			                       Laboratorio:
			                        <asp:TextBox runat="server" ID="txtLaboratorio" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvLaboratorio" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtLaboratorio" ValidationGroup="desc">*</asp:RequiredFieldValidator>
		                        </td>
                                <td>
			                        Compartido:
			                        <asp:DropdownList runat="server" ID="ddlCompartido" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Text="-- Seleccione una opcion --  "></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="True"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                        </asp:DropdownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvCompartido" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="ddlCompartido" ValidationGroup="desc" InitialValue="-- Seleccione una opcion --  ">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
			                        Composición:
			                        <asp:TextBox runat="server" ID="txtComposicion" CssClass="form-control" TextMode="MultiLine" />
		                        </td>
                            </tr>
                            <tr>
		                        <td colspan="4">
			                        Posologia

			                        <asp:TextBox runat="server" ID="txtPosologia" CssClass="form-control" TextMode="MultiLine"/>
		                        </td>
                            <tr>
                                <td colspan="4">
			                        Indicaciones:
			                        <asp:TextBox runat="server" ID="txtIndicaciones" CssClass="form-control" TextMode="MultiLine"/>
		                        </td>
                            </tr>
                            <tr>
                                <td colspan="4">
			                        Contraindicaciones:
			                        <asp:TextBox runat="server" ID="txtContraindicaciones" CssClass="form-control" TextMode="MultiLine"/>
		                        </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary id="RequiredFieldValidator1" HeaderText="Los campos marcados con asterisco * son obligatorios" ForeColor="Red" ControlToValidate="txtObservaciones" Display="Dynamic" Runat="server" ValidationGroup="desc" />
  
                        <div class="form-group" style="text-align:right">
                          
                            <asp:Button ID="LoginButton" runat="server" CommandName="Guardar" Text="Guardar" class="btn btn-primary"  OnClick="GuardarButton_Click" ValidationGroup="desc"/>
                             <asp:Button ID="btnCalcelar" runat="server" CommandName="Calcelar" Text="Cancelar" class="btn btn-danger" OnClick="btnCalcelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
