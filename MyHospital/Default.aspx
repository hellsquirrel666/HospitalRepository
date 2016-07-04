<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="MyHospital._Default" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="Server">
    <link rel="stylesheet" href='<%= Page.ResolveUrl("~/Content/calendar.min.css")%>'>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/Scripts/underscore.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/Scripts/calendar-es-MX.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/Scripts/calendar.min.js")%>'></script>
  
        <form id="Form1" runat="server" class="right_col" role="main">
        <div class="page-title">
            <div class="title_left">
                <h3>Bienvenido</h3>
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
                    <h2>Agenda (En construccion)</h2>
                    <div class="clearfix"></div>
                    <div class="x_content">

                    <div id="calendar"></div>

                        <div class="pull-right form-inline">
                            <div class="btn-group">
                                <button type="button" class="btn btn-primary" data-calendar-nav="prev"><< Ant</button>
                                <button type="button" class="btn" data-calendar-nav="today">Hoy</button>
                                <button type="button" class="btn btn-primary" data-calendar-nav="next">Sig >></button>
                            </div>
                            <div class="btn-group">
                                <button type="button" class="btn btn-warning" data-calendar-view="month">Mes</button>
                                <button type="button" class="btn btn-warning active" data-calendar-view="week">Semanal</button>
                                <button type="button" class="btn btn-warning" data-calendar-view="day">Dia</button>
                            </div>
                        </div>    
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>