<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="MyHospital.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet"/>

    <!-- Custom Theme Style -->
    <link href="../Content/css/custom.min.css" rel="stylesheet">

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LogIn ID="LogInUser" runat="server">
            <LayoutTemplate>
                <div class="container">
                    <div class="row text-center ">
                        <div class="col-md-12">
                            <br /><br />
                            <h2> Iniciar sesión</h2>
                            <h5></h5>
                            <br />
                        </div>
                    </div>
                    <div class="row ">
                        <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <strong>   Ingresar usuario y contraseña </strong>  
                                </div>
                                <div class="panel-body">
                                    <form role="form">
                                    <br />
                                     <div class="form-group input-group">
                                        <span class="input-group-addon"><i class="fa fa-tag"  ></i></span>
                               
                                        <asp:TextBox ID="UserName" runat="server" class="form-control" placeholder="Usuario"></asp:TextBox>
                                     </div>
                                     <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LogIn">*</asp:RequiredFieldValidator>
                                    
                                    <div class="form-group input-group">
                                        <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                  
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control" placeholder="Contraseña"></asp:TextBox>
                                     </div>
                                     <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LogIn">*</asp:RequiredFieldValidator>
                                 
                                     
                                     <div class="form-group">    
                                            <label class="checkbox-inline">

                                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </label>
                                     </div>
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LogIn"  OnClick="LoginButton_Click" />
                                     </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                
            </LayoutTemplate>

        </asp:LogIn>
    </div>
    </form>
</body>
</html>
