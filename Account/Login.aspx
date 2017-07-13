<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.User.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>

                <h1 class="logo-name">M+</h1>

            </div>
            <h3>Welcome to Newsletter</h3>
           <%-- <p>Perfectly designed and precisely prepared admin theme with over 50 pages with extra new web app views.
                <!--Continually expanded and constantly improved Inspinia Admin Them (IN+)-->
            </p>--%>
            <%--<p>Login in. To see it in action.</p>--%>
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
             <div  role="form"  >
                <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-3 control-label">User name</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                 </div>
                <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-3 control-label">Password</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                 </div>
                 <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                 <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-primary block full-width m-b" />
                        </div>
                    </div>
               

               <%-- <a href="#"><small>Forgot password?</small></a>
                <p class="text-muted text-center"><small>Do not have an account?</small></p>
                <a class="btn btn-sm btn-white btn-block" href="register.html">Create an account</a>--%>
            </div>

            
            <%--<p class="m-t"> <small>Inspinia we app framework base on Bootstrap 3 &copy; 2014</small> </p>--%>
        </div>
    </div>

                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have a local account.
                </p>
        <div class="col-md-4" style="display:none">
            <section id="socialLoginForm">
                <uc:openauthproviders runat="server" id="OpenAuthLogin" />
            </section>
        </div>
    
</asp:Content>

