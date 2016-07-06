<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="MyHospital.Paciente.Consulta" %>
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
        <asp:HiddenField runat="server" ID="hfIdPaciente" Visible="false" />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Consulta
                        <asp:Label runat="server" ID="NombrePaciente"/>
                    </h2>

                    <div class="clearfix"></div>
                    <div class="x_content">
                        <table class="table" style="table-layout:fixed;">
	                        <tr>
                                <td>
                                    Numero de consulta:
                                    <asp:TextBox runat="server" ID="txtNoConsulta" CssClass="form-control" Enabled="false"/>
                                </td>
                                <td>
                                   
                                </td>
		                        <td>
			                        Fecha
			                        <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" type="date"/>
		                        </td>
	                        </tr>
                            <tr>
		                        <td colspan="3">
			                        Diagnostico
			                        <asp:TextBox runat="server" ID="txtDiagnostico" onkeydown="return txNombres(event);" CssClass="form-control"/>
		                        </td>
	                        </tr>
                            <tr>
                                <td colspan="3">
                                     <asp:GridView runat="server" ID="gvMedicamentos" CssClass="table table-hover" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField HeaderText="Cantidad" DataField="nUnidades" />
                                            <asp:BoundField HeaderText="Medicamento Prescrito" DataField="sNombre" />
                                            <asp:BoundField HeaderText="Dosis/Modo empleo" DataField="sObservaciones" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                     Observaciones Adicionales
			                        <asp:TextBox runat="server" ID="txtObservaciones" onkeydown="return txNombres(event);" CssClass="form-control"/>

                                </td>
                            </tr>
                            </table>  
                           <div class="form-group" style="text-align:right">
                            <asp:button runat="server" ID="btnAgregarMedicamento" class="btn btn-primary" Text="Agregar Medicamento" 
                                CausesValidation="true" ValidationGroup="Validators" OnClick="btnAgregarMedicamento_Click" /> &nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:button runat="server" ID="btnGuardar" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" 
                                CausesValidation="true" ValidationGroup="Validators" /> &nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:button runat="server" ID="btnCancelar" class="btn btn-danger" OnClick="btnCancelar_Click" Text="Cancelar"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
