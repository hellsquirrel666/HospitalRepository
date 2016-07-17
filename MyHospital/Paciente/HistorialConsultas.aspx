<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="HistorialConsultas.aspx.cs" Inherits="MyHospital.Paciente.HistorialConsultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
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
                          <div class="title_right">
                            <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                              <div class="input-group">
                                <asp:TextBox Id="txtFiltro" runat="server" type="text" class="form-control" placeholder="Buscar"/>
                                <span class="input-group-btn">
                                  <asp:Button ID="buscar" runat="server" class="btn btn-default" type="button" Text="Go!" OnClick="buscar_Click" />
                                </span>
                              </div>
                            </div>
                          </div>
                        <asp:GridView runat="server" ID="gvPacientes"  Cssclass="table table-striped table-bordered dt-responsive nowrap" ItemType="MyHospital.Modelo.Consulta"
                             AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvConsultas_PageIndexChanging" >
                            <Columns>
                                <asp:BoundField HeaderText="IdConsulta" DataField="nIdConsulta" />
                                <asp:BoundField HeaderText="Fecha" DataField="fecha" />
                                <asp:BoundField HeaderText="Diagnostico" DataField="sDiagnostico" />
                                <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                                    <ItemTemplate>
                                        <div class="dropdown" style="cursor: pointer;">
                                            <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                            <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Ver" 
                                                        PostBackUrl='<%# string.Format("~/Paciente/Consulta.aspx?Consulta={0}", Item.nIdConsulta) %>'/>
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
                                  </span>
    </form>
                                  </span>
    </form>
</asp:Content>
