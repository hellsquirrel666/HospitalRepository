<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DatosPaciente.aspx.cs" Inherits="MyHospital.Paciente.DatosPaciente" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
        <script type="text/javascript">
            function txNombres() {

                if ((event.keyCode != 8) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122)
                    )
                    event.returnValue = false;
            }

            //Función que permite solo Números
            function ValidaSoloNumeros() {
                if ((event.keyCode != 8) && (event.keyCode < 48) && (event.keyCode != 9) || (event.keyCode > 57))
                    event.returnValue = false;
            }

    </script>


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
			                        <asp:TextBox runat="server" ID="txtApellidoPaterno" onkeydown="return txNombres(event);" CssClass="form-control" />
                                </td>
                                <td style="width: 18px">
                                    <asp:RequiredFieldValidator id="rfvFirstName" ControlToValidate="txtApellidoPaterno" Display="Dynamic" Runat="server" ValidationGroup="Validators"
                                        ForeColor="Red">*</asp:RequiredFieldValidator>
		                        </td>
		                        <td>
			                        Apellido materno
			                        <asp:TextBox runat="server" ID="txtApellidoMaterno" onkeydown="return txNombres(event);" CssClass="form-control" />
		                        </td>
                                <td style="width: 18px">

                                </td>
		                        <td>
			                        Nombre (s)
			                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" onkeydown="return txNombres(event);"/>
                                </td>
		                        <td style="width: 18px">
                                    <asp:RequiredFieldValidator id="rfvNombre" ForeColor="Red"
                                        ControlToValidate="txtNombre" Display="Dynamic" Runat="server" ValidationGroup="Validators">*</asp:RequiredFieldValidator>
		                        </td>
	                        </tr>
                            <tr>
                                <td>
			                        Fecha de nacimiento
			                        <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" Type="Date"/>
                                 </td>
		                        <td style="width: 18px">
                                    <asp:RequiredFieldValidator id="rfvFechaNacieniento" 
                                        ControlToValidate="txtFechaNacimiento" Display="Dynamic" Runat="server" ValidationGroup="Validators" ForeColor="Red">*</asp:RequiredFieldValidator>
		                        </td>
                                <td>
			                        Sexo
			                        <asp:DropdownList runat="server" ID="ddlSexo" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-- Seleccione una opcion -- "></asp:ListItem>
                                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                        </asp:DropdownList>
                                </td>
		                        <td >
                                    <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ForeColor="Red"
                                        InitialValue="-- Seleccione una opcion -- " ValidationGroup="Validators">*</asp:RequiredFieldValidator>
		                        </td>
		                       <td>
			                        Grupo sanguineo
			                        <asp:DropdownList runat="server" ID="ddlGpoSanguineo" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Text="-- Seleccione una opcion -- "></asp:ListItem>
                                    </asp:DropdownList>
                                </td>
		                        <td  style="width: 18px">
                                    <asp:RequiredFieldValidator ID="rfvGpoSanguineo" runat="server" ControlToValidate="ddlGpoSanguineo" ForeColor="Red"  
                                        ValidationGroup="Validators" InitialValue="-- Seleccione una opcion -- ">*</asp:RequiredFieldValidator>
		                        </td>
                            </tr>
                            <tr>
                                 
                                <td>
			                        N.S.S.
			                        <asp:TextBox runat="server" ID="txtNSS" CssClass="form-control" onkeydown="return ValidaSoloNumeros(event);"/>
		                        </td>
                                <td>

                                </td>
                                <td>
			                        Telefono
			                        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"  onkeydown="return ValidaSoloNumeros(event);" />
                                </td>
		                        <td>
                                    <asp:RequiredFieldValidator id="rfvTelefono" ForeColor="Red"
                                        ControlToValidate="txtTelefono" Display="Dynamic" Runat="server" ValidationGroup="Validators">*</asp:RequiredFieldValidator>
		                        </td>
                                <td>
			                        Celular
			                        <asp:TextBox runat="server" ID="txtCel" CssClass="form-control" onkeydown="return ValidaSoloNumeros(event);" />
                                </td>
                                <td>

                                </td>

                            </tr>
                            <tr>
                                 <td>
			                        Correo electronico
			                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
		                        </td>
                                <td>

                                </td>
		                        <td>
                                    Calle:
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCalle"></asp:TextBox>
                                </td>
		                        <td>
                                    <asp:RequiredFieldValidator id="rfvCalle" ForeColor="Red"
                                        ControlToValidate="txtCalle" Display="Dynamic" Runat="server" ValidationGroup="Validators">*</asp:RequiredFieldValidator>
                                </td>
                          
                                <td>
                                    No. Ext.:
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNoExt"></asp:TextBox> 
                                 </td>
		                        <td style="width: 27px">
                                    <asp:RequiredFieldValidator id="rfvNoExt" ForeColor="Red" ControlToValidate="txtNoExt" Display="Dynamic" Runat="server" ValidationGroup="Validators">*</asp:RequiredFieldValidator>
                                   
                                </td>
                                

                            </tr>
                            <tr>
                                <td>
                                    No. Int.:
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNoInt"></asp:TextBox>
                                 </td>
                                <td>

                                </td>
                                <td>
			                        Codigo postal
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCP" AutoPostBack="true" CausesValidation="true" ValidationGroup="Validators"
                                        OnTextChanged="txtCP_TextChanged" MaxLength="5"></asp:TextBox>
                                 </td>
		                        <td>
                                    <asp:RequiredFieldValidator id="rfvCP" ForeColor="Red"
                                        ControlToValidate="txtCP" Display="Dynamic" Runat="server" ValidationGroup="Validators">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    Colonia:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlColonia"></asp:DropDownList>
                                </td>
                                <td>

                                </td>
                            </tr>
                            <tr>
                                 <td>
                                    Delegacion / Municipio:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDelegacion"></asp:DropDownList>
                                </td>
                                <td>

                                </td>
                                <td style="width: 27px">
                                    Ciudad:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCiudad"></asp:DropDownList>
                                </td>
                                <td>

                                </td>
                                <td>
                                    Estado:
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado"></asp:DropDownList>
                                </td>
                                <td>

                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary id="RequiredFieldValidator1" HeaderText="Los campos marcados con asterisco * son obligatorios"
                                 ForeColor="Red" ControlToValidate="txtObservaciones" Display="Dynamic" Runat="server" ValidationGroup="Validators" />

                        <div class="form-group" style="text-align:right">
                            <asp:button runat="server" ID="btnGuardar" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" 
                                CausesValidation="true" ValidationGroup="Validators" /> &nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:button runat="server" ID="btnCancelar" class="btn btn-danger" OnClick="btnCancelar_Click" Text="Cancelar"/>
                        </div>
                        <br />
                    </div>
                     
                </div>
            </div>
        </div>
    </form>
</asp:Content>
