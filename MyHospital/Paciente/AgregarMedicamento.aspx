<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMedicamento.aspx.cs" Inherits="MyHospital.Paciente.AgregarMedicamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet nofollow"/>
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet"/>
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet nofollow"/>

    <!-- Custom Theme Style -->
    <link href="../Content/css/custom.min.css" rel="stylesheet nofollow"/>

    <script type="text/javascript">
        function CloseWindow() {
            window.opener.location.reload();
            window.close();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
            <LayoutTemplate>
                <div class="container">
                    <div class="row text-center ">
                        <div class="col-md-12">
                            <br /><br />
                            <h1> Agregar Medicamento</h1>
                            <h5></h5>
                            <br />
                        </div>
                    </div>
                    <div class="row ">
                        <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <asp:HiddenField runat="server" ID="hfIdConsulta" Visible="false" />
                                     <table class="table" style="table-layout:fixed;">
	                                    <tr>
		                                    <td>
                                                Medicamento
                                                <asp:DropDownList runat="server" ID="ddlMedicamento"></asp:DropDownList>
                                            </td>
                                        </tr>
                                         <tr>
                                             <td>
                                                Num. envases/ unidades:
                                                <asp:TextBox runat="server" ID="txtNumEnvases"></asp:TextBox>
                                            </td>
                                         </tr>
                                          <tr>
                                             <td>
                                               Dosis/Modo de Empleo:
                                                <asp:TextBox runat="server" ID="txtObservaciones"></asp:TextBox>
                                            </td>
                                         </tr>
                                    </table>
                                     <div class="form-group" style="text-align:right">
                                          <asp:Button runat="server" ID="btnGuardar" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" 
                                            CausesValidation="true" ValidationGroup="Validators" /> &nbsp&nbsp&nbsp&nbsp&nbsp
                                            <input type="button" value="Cerrar" class="btn btn-danger"  onclick="javascript: return CloseWindow();" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                
            </LayoutTemplate>

    </div>
    </form>
</body>
</html>
