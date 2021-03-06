﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="VerMedicamentos.aspx.cs" Inherits="MyHospital.Medicamento.VerMedicamentos" %>
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

                        <asp:GridView runat="server" ID="gvMedicamentos"  Cssclass="table table-striped table-bordered dt-responsive nowrap"  AutoGenerateColumns="false"  AllowPaging="true" PageSize="10" OnPageIndexChanging="gvMedicamentos_PageIndexChanging" ItemType="MyHospital.Modelo.Medicamentos"  OnRowCommand = "GridView1_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="IdMedicamento" DataField="nIdMedicamento" />
                                <asp:BoundField HeaderText="Nombre" DataField="sNombre" />
                                <asp:BoundField HeaderText="Laboratorio" DataField="sLaboratorio" />
                                <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                                    <ItemTemplate>
                                        <div class="dropdown" style="cursor: pointer;">
                                            <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                            <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Editar" 
                                                        PostBackUrl='<%# string.Format("~/Medicamento/AgregarMedicamento.aspx?Medicamento={0}", Item.nIdMedicamento) %>'/>
                                                </li>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField>
                                     <HeaderStyle Width="10px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnDelete" runat="server"  CommandArgument=<%# Item.nIdMedicamento %> ImageUrl="~/ImagesUsuarios/incorrect-294245_960_720.png" ToolTip="Click para eliminar" AlternateText="Click para eliminar"  Width="10px" Height="10px" OnClientClick="return confirm('¿Esta seguro de eliminar el medicamento?')"/>                            
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
