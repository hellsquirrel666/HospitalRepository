<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="VerMedicamentos.aspx.cs" Inherits="MyHospital.Medicamento.VerMedicamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="Form1" runat="server" class="right_col" role="main">
        <div class="page-title">
            <div class="title_left">
                <h3>Ver medicamentos</h3>
            </div>
            <div class="title_right">
                <h3></h3>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <%--<h2>Datos del medicamento</h2>--%>
                    <div class="clearfix"></div>
                    <div class="x_content">
                        <asp:GridView runat="server" ID="gvMedicamentos" CssClass="table table-hover"  AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="IdMedicamento" DataField="nIdMedicamento" />
                                <asp:BoundField HeaderText="Nombre" DataField="sNombre" />
                                <asp:BoundField HeaderText="Laboratorio" DataField="sLaboratorio" />
                                <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                                    <ItemTemplate>
                                         <asp:LinkButton ID="lnkDetalle" runat="server" Text="Detalle"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar"/>
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
