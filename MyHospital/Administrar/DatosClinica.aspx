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
        <asp:HiddenField runat="server" ID="hfIdDireccion" Visible="false" />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Datos del hospital</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <table class="table" style="table-layout:fixed;">
                             <col style="width:33%;"/>
                            <col style="width:1%;"/>
                            <col style="width:33%;"/>
                            <col style="width:1%;"/>
	                        <tr>
		                        <td colspan="4">
			                       Nombre
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator id="rfvNombre" ForeColor="Red" ControlToValidate="txtNombre" Display="Dynamic" Runat="server" ValidationGroup="Validators">*</asp:RequiredFieldValidator>
		                        </td>
	                        </tr>
                            <tr>
                                <td colspan="5">
			                        Logo
			                        <asp:FileUpload ID="fuLogo" runat="server" accept=".png,.jpg,.jpeg,.gif"/>
		                        </td>
		           
                            </tr>
                            <tr>
                                <td>
			                        Telefono 1
			                        <asp:TextBox runat="server" ID="txtTel1" CssClass="form-control" />
                                 </td>
                                <td style="width: 9px">
                                    <asp:RequiredFieldValidator id="rfvTelefono" ForeColor="Red" ControlToValidate="txtTel1" Display="Dynamic" Runat="server" ValidationGroup="Validators" >*</asp:RequiredFieldValidator>
		                        </td>
                               
                                <td>
			                        Telefono 2
			                        <asp:TextBox runat="server" ID="txtxTel2" CssClass="form-control" />
		                        </td>
                                <td colspan="2">
                                    Correo Electronico
			                        <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" />
		                        </td>
	                        </tr>
                            <tr>
		                        <td>
                                    Calle:
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCalle"></asp:TextBox>
                                </td>
                                <td style="width: 9px">
                                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtCalle" Display="Dynamic" Runat="server" ValidationGroup="Validators" >*</asp:RequiredFieldValidator>
                                </td>
                                 <td>
                                    No. Ext.:
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNoExt"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator id="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtNoExt" Display="Dynamic" Runat="server" ValidationGroup="Validators" >*</asp:RequiredFieldValidator>
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
                                <td style="width: 9px">
                                   <asp:RequiredFieldValidator id="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtCP" Display="Dynamic" Runat="server" ValidationGroup="Validators" >*</asp:RequiredFieldValidator>

                                </td>
                                <td>
                                    Colonia:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlColonia"></asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    Delegacion / Municipio:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDelegacion"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ciudad:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCiudad"></asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    Estado:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                          <asp:ValidationSummary id="ValidationSummary1" HeaderText="Los campos marcados con asterisco * son obligatorios. <br />"
                                 ForeColor="Red" Display="Dynamic" Runat="server" ValidationGroup="Validators"/>
                        <div class="form-group" style="text-align:right">
                            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" ValidationGroup="Validators"/>
                            <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" class="btn btn-danger" OnClick="btnCancelar_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
