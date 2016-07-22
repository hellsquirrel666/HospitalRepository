<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="MyHospital.Paciente.Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <script type="text/javascript">
        function OpenPopup() {
            var str = '<%= txtNoConsulta.Text%>';
            window.open('AgregarMedicamento.aspx?Consulta=' + str, '', 'width=600,height=400');

        };

        function ImprimirReceta() {
            window.open('../Reporte/ImprimirReporte.aspx', 'width=600,height=400');
        };
</script>

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
                                    <asp:RequiredFieldValidator runat="server" ID="rfvFecha" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtFecha" ValidationGroup="desc" ErrorMessage="Fecha es obligatorio"  />

		                        </td>
	                        </tr>
                            <tr>
		                        <td colspan="3">
			                        Diagnostico
			                        <asp:TextBox runat="server" ID="txtDiagnostico" onkeydown="return txNombres(event);" CssClass="form-control"/>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvDiagnostico" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtDiagnostico" ValidationGroup="desc" ErrorMessage="Diagnostico es obligatorio"  />
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
                                    <asp:RequiredFieldValidator runat="server" ID="rfvObservaciones" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtObservaciones" ValidationGroup="desc" ErrorMessage="Observaciones es obligatorio"  />

                                </td>
                            </tr>
                            </table>  
                           <div class="form-group" style="text-align:right">
                               
                           <input type="button"  ID="btnVistPrevia" value="Vista Previa" class="btn btn-primary"  runat="server" onclick="javascript: return ImprimirReceta()" />
                           <input type="button"  ID="btnAgregar_Med" value="Agregar Medicamento" class="btn btn-primary"  runat="server" onclick="javascript: return OpenPopup()" />
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
