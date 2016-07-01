<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="VerPacientes.aspx.cs" Inherits="MyHospital.Paciente.VerPacientes" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">

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
                    <h2>Datos del paciente</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <asp:GridView runat="server" ID="gvPacientes" CssClass="table table-hover" OnRowCommand="gvPacientes_RowCommand" ItemType="MyHospital.Modelo.Pacientes"
                             AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="IdPaciente" DataField="nIdPaciente" />
                                <asp:BoundField HeaderText="Nombre" DataField="sPrimerApellido" />
                                <asp:BoundField HeaderText="Apellido" DataField="SNombre" />
                                <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                                    <ItemTemplate>
                                        <div class="dropdown" style="cursor: pointer;">
                                            <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                            <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Editar" 
                                                        PostBackUrl='<%# string.Format("~/Clientes/Detalle/?{0}={1}", "Paciente", "Item.IdPaciente") %>'/>
                                                </li>
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Historia Clínica" 
                                                        PostBackUrl='<%# string.Format("~/Clientes/Empleados/?{0}={1}", "Paciente", "Item.IdPaciente") %>'/>
                                                </li>
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton5" runat="server" Text="Agendar Cita" 
                                                        PostBackUrl='<%# string.Format("~/Empresas/Cuentas/Balance?{0}={1}&{2}={3}", "Paciente", "Item.IdPaciente",
                                                    "Core.Utils.Constants.QueryStringNames.ReturnURL", Request.RawUrl) %>'/>
                                                </li>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
    </form>
</asp:Content>