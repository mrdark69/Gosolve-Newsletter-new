<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
              <div class="row">
                <div class="col-lg-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Server Setting <small></small></h5>
                            <div class="ibox-tools">
                                <%--<a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#">Config option 1</a>
                                    </li>
                                    <li><a href="#">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>--%>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div  class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Server Type</label>

                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ST" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ST_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Standard</asp:ListItem>
                                        <asp:ListItem Value="2">MailGun</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                            </div>
                             <div class="hr-line-dashed"></div>
                            <div  class="form-horizontal">


                                <div class="form-group" runat="server" id="option_1" visible="false"><label class="col-sm-2 control-label">APIKEY</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="APIKEY" placeholder="api-xxxxxxxx" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="APIKEY" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                     
                                        <span class="help-block m-b-none">KEY ที่ได้จากระบบหลังบ้านของ เมล์ server</span>
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>

                           
                                
                                <div class="form-group" runat="server" id="option_2" visible="false"><label class="col-sm-2 control-label">Domain</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="Domain" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Domain" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <span class="help-block m-b-none">โดเมน ที่ mail server อนุญาติให้ใช้ หรือใช้ในการ สมัคร</span>
                                    </div>
                                     
                                </div>
                                <div class="hr-line-dashed"></div>


                               
                                
                                <div class="form-group"><label class="col-sm-2 control-label">MailName</label>
                                    <div class="col-sm-10">
                                         <asp:TextBox ID="MailName" runat="server" placeholder="Gosolv.co.th & marketing team" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="MailName" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <span class="help-block m-b-none">ชื่อหรือบริษัท ที่จะแสดงให้ผู้รับเห็น</span>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"></div>
                                
                                <div class="form-group"><label class="col-sm-2 control-label">MailAddress</label>
                                    <div class="col-sm-10">
                                            <asp:TextBox ID="MailAddress" runat="server" placeholder="xxxx@mailbox.com" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="MailAddress" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <span class="help-block m-b-none">ชื่ออีเมล์ ที่จะแสดงให้ผู้รับเห็น หรือ ให้สามารถตอบกลับมา</span>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"></div>
                                
                                <div class="form-group" runat="server" id="option_3"><label class="col-sm-2 control-label">MailServer</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="MailServer" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="MailServer" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <%--<span class="help-block m-b-none">ชื่ออีเมล์ ที่จะแสดงให้ผู้รับเห็น หรือ ให้สามารถตอบกลับมา</span>--%>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"> </div>
                            <div class="form-group" runat="server" id="option_4"><label class="col-sm-2 control-label">MailServerUser</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="MailServerUser" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="MailServerUser" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <%--<span class="help-block m-b-none">ชื่ออีเมล์ ที่จะแสดงให้ผู้รับเห็น หรือ ให้สามารถตอบกลับมา</span>--%>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="option_5"><label class="col-sm-2 control-label">MailServerPass</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="MailServerPass" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="MailServerPass" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                         <%--   <span class="help-block m-b-none">ชื่ออีเมล์ ที่จะแสดงให้ผู้รับเห็น หรือ ให้สามารถตอบกลับมา</span>--%>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"></div>
                               <div class="form-group"><label class="col-sm-2 control-label">Port</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="Port" runat="server" placeholder="465, 587" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Port" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <span class="help-block m-b-none">ชื่ออีเมล์ ที่จะแสดงให้ผู้รับเห็น หรือ ให้สามารถตอบกลับมา</span>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"></div>
                                <div class="form-group"><label class="col-sm-2 control-label">use SSL</label>
                                    <div class="col-sm-10">
                                       <asp:DropDownList ID="IsSSL" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                        <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"></div>



                                <div class="form-group">
                                    <div class="col-sm-4 col-sm-offset-2">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save changes" CssClass="btn btn-primary" />
                                        <%--<button class="btn btn-white" type="submit">Cancel</button>
                                        <button class="btn btn-primary" type="submit">Save changes</button>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
   
</asp:Content>
