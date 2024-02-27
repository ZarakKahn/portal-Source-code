<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Market_Visit_Portal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="single-page-title">
    <div class="container text-center">
        <h2></h2>
    </div>
</section>
<!-- .page-title -->
    

<section class="about-text ptb-100">
    <section class="section-title">
         
        <div class="container text-center">
            <div class="text-right" style="margin-top:40px;">
        <span class="badge" runat="server" id="user_name" style="padding-left:10px;padding-right:10px;padding-top:4px;padding-bottom:4px;background-color:darkred"></span>
       <span class="badge" runat="server" id="user_region" style="padding-left:10px;padding-right:10px;padding-top:4px;padding-bottom:4px;background-color:darkred"></span> 
 
</div>
             <div class="row col-md-12">

           <h3  style="margin-top:50px;color:darkred">LOGIN</h3>
                 
         <div class="box box-danger with-border">
            
            <!-- /.box-header -->
            <!-- form start -->
              <div class="col-md-3">
                  </div>
            
              <div class="col-md-8">
            
              <div class="box-body">
                   <br />
                   <asp:Panel runat="server" ID="login">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label">Email</label>

                  <div class="col-sm-6">
                    <input type="email" class="form-control" id="inputEmail3" runat="server" placeholder="Email">
                  </div>
                </div>
                  <br />
                  <br />
                <div class="form-group">
                  <label for="inputPassword3" class="col-sm-2 control-label">Password</label>

                  <div class="col-sm-6">
                    <input type="password" class="form-control" id="inputPassword3"  runat="server" placeholder="Password">
                  </div>
                </div>

                
                 </asp:Panel>
                  <asp:Panel runat="server" Visible="false" ID="reset">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label">Email</label>

                  <div class="col-sm-6">
                    <input type="email" class="form-control" id="Email1" runat="server" placeholder="Email">
                  </div>
                </div>
                      <br />
                <br />
                     <%-- <div class="form-group">
                  <label for="inputPassword3" class="col-sm-2 control-label">Old Password</label>

                  <div class="col-sm-6">
                    <input type="password" class="form-control" id="old"  runat="server" placeholder="Password">
                  </div>
                </div>--%>
                  
                <div class="form-group">
                  <label for="inputPassword3" class="col-sm-2 control-label"> New Password</label>

                  <div class="col-sm-6">
                    <input type="password" class="form-control" id="new_pass"  runat="server" placeholder="Password">
                  </div>
                </div>

                
                 </asp:Panel>
              </div>
              <!-- /.box-body -->
              <div class="box-footer">
               
                  <asp:Button Id="Button1" runat="server" Text="Sign in"  class="btn btn-danger" OnClick="Submit_Click"  />
                  <asp:Button Id="Button2" runat="server" Text="Update Password"  class="btn btn-danger" OnClick="Update_Click" Visible="false" />
                   <div class="row" style="margin-top:20px;margin-right:15px">
                  <div class="col-sm-6 text-left"  >
                     
                   <asp:LinkButton ID="LinkButton1" runat="server" EnableTheming="True" 
        style="z-index: 1; position: center" Visible="false"
        >Forgot Password</asp:LinkButton>
                     
                        
                        </div>
                       <div class="col-sm-6 text-right"  >
                     
                   <asp:LinkButton ID="LinkButton2" runat="server" EnableTheming="True" 
        style="z-index: 1; position: center" OnClick="change_pass"
        >Change Password</asp:LinkButton>
                     
                      
                        </div>
                      </div>
                  
              </div>
              <!-- /.box-footer -->
            
                  </div>
              <div class="col-md-3">
                  </div>
          </div>
   </div>
           
     
                 
            </div>
        </section>
    </section>
</asp:Content>
