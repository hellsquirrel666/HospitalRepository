<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="VerHistorial.aspx.cs" Inherits="MyHospital.Paciente.VerHistorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
 <script type="text/javascript">
     function OpenPopup() {
         var str = '<%= Request.QueryString["Paciente"]%>';
            window.open('AgregarEnfermedad.aspx?Paciente=' + str, '', 'width=600,height=400');

        };
</script>

</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="Form1" runat="server" class="right_col" role="main">
        <div class="page-title">
            <div class="title_left">
                <h3>Ver pacientes</h3>
            </div>
            <div class="title_right">
                <h3></h3>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Historial clinico del paciente</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <asp:GridView runat="server" ID="gvCampos" CssClass="table table-hover"
                             AutoGenerateColumns="false" >
                            <Columns>
                                <asp:BoundField HeaderText="Id Campo" DataField="nIdCampoHistClin"/>
                                <asp:BoundField HeaderText="Campo" DataField="sDescripcion" />
                                <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtObservaciones" Text='<%# Bind("sObservaciones") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <div class="form-group" style="text-align:right">
                            <input type="button"  ID="btnAgregar_Enfermedad" value="Agregar Enfermedad" class="btn btn-primary"  runat="server" onclick="javascript: return OpenPopup()" />
                            <asp:button runat="server" ID="btnGuardar" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" /> &nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:button runat="server" ID="btnCancelar" class="btn btn-danger" OnClick="btnCancelar_Click" Text="Cancelar"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
    </form>
    </asp:Content>
