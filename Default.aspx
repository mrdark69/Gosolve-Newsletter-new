<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-12">
                    <div class="text-center m-t-lg">
                        <h1>
                            Welcome in Newsletter System
                        </h1>
                       <%-- <small>
                            It is an application skeleton for a typical web app. You can use it to quickly bootstrap your webapp projects and dev environment for these projects.
                        </small>--%>


                       <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                        <asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="CheckNow" />
                        <asp:Button ID="btnMX" runat="server" OnClick="btnMX_Click" Text="Find_MX" />

                         <asp:Label ID="lblret" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
   
</asp:Content>
