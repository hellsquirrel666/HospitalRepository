<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="MyHospital.Usuarios.VerUsuarios" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="Form1" runat="server" class="right_col" role="main">
        <div class="page-title">
            <div class="title_left">
                <h3>Ver Usuarios</h3>
            </div>
            <div class="title_right">
                <h3></h3>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Usuarios</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <asp:GridView runat="server" ID="gvPacientes" CssClass="table table-hover" ItemType="MyHospital.Modelo.USUARIOS" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre de usuario" DataField="sUsuario" />
                                <asp:BoundField HeaderText="Nombre" DataField="sPrimerApellido" />
                                <asp:BoundField HeaderText="Nombre" DataField="sSegundoApellido" />
                                <asp:BoundField HeaderText="Apellido" DataField="SNombre" />
                                <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                                    <ItemTemplate>
                                        <div class="dropdown" style="cursor: pointer;">
                                            <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                            <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Editar" 
                                                        PostBackUrl='<%# string.Format("~/Usuarios/AgregarUsuario.aspx?Usuario={0}", Item.nIdUsuario) %>'/>
                                                </li>
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Historia Clínica" 
                                                        PostBackUrl='<%# string.Format("~/HistoriasClinicas/VerHistorial.aspx?Paciente={0}", Item.nIdUsuario) %>'/>
                                                </li>
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton5" runat="server" Text="Agendar Cita" 
                                                        PostBackUrl='<%# string.Format("~/Citas/AgendarCita.aspx?Paciente={0}", Item.nIdUsuario) %>'/>
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