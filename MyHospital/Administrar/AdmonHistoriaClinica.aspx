<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AdmonHistoriaClinica.aspx.cs" Inherits="MyHospital.Administar.AdmonHistoriaClinica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="Form1" runat="server" class="right_col" role="main">
        <div class="page-title">
            <div class="title_left">
                <h3>Administrador</h3>
            </div>
            <div class="title_right">
                <h3></h3>
            </div>
        </div>

        <div class="clearfix"></div>
        <asp:HiddenField runat="server" ID="hfIdCampo" Visible="false" />
        <asp:HiddenField runat="server" ID="hfDescripcion" Visible="false" />
        <asp:HiddenField runat="server" ID="hfStatus" Visible="false" />

        
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <h2>Datos de la historia clinica</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">
                       <asp:GridView runat="server" ID="gvHistClin" CssClass="table table-hover" OnRowCommand="gvHistClin_RowCommand" ItemType="MyHospital.Modelo.CamposHistClin"
                             AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="IdCampo" DataField="nIdCampoHistClin" />
                                <asp:BoundField HeaderText="Descripcion" DataField="sDescripcion" />
                                <asp:BoundField HeaderText="Visible" DataField="bActivo" />
                                <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                                    <ItemTemplate>
                                        <div class="dropdown" style="cursor: pointer;">
                                            <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                            <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                                <li role="presentation">
                                                    <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="nIdCampoHistClin"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Activar/Desactivar" />
                                                </li>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <table class="table" style="table-layout:fixed;">
	                        <tr>
		                        <td>
			                        Ingresar nuevo campo
			                        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ID="rfvDescripcion" ForeColor="red" Display="Dynamic" 
                                        ControlToValidate="txtDescripcion" ValidationGroup="desc" ErrorMessage="El canpo descripcion no debe estar vacío"  />
		                        </td>
                         </table>
                        

                         <div class="form-group" style="text-align:right">
                             
                            <asp:button runat="server" ID="btnGuardar" class="btn btn-primary"  Text="Guardar" OnClick="btnGuardar_Click" 
                                ValidationGroup="desc" ValidateRequestMode="Enabled" CausesValidation="true" /> &nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:button runat="server" ID="btnCancelar" class="btn btn-danger" Text="Cancelar"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
