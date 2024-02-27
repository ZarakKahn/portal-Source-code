<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Market_Visit_Portal.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="http://code.jquery.com/jquery-1.8.2.js"></script>  
    
    <script type="text/javascript">
        function ShowPopup() {
            $(document).ready(function () { 
              
                $("#ContentPlaceHolder1_btnShowPopup").click();
            });
             }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section class="single-page-title">
    <div class="container text-center">
        <h2></h2>
    </div>
</section>
<!-- .page-title -->
    <div class="container text-right"  style="margin-top:40px;">
 <span class="badge" runat="server" id="user_name" style="padding-left:10px;padding-right:10px;padding-top:4px;padding-bottom:4px;background-color:darkred">Iqra Iqbal</span>

</div>
<section class="about-text ptb-100">
        <section class="section-title">
        <div class="container text-center text-navy">
              <h3  style="margin-top:50px;color:darkred">USER MANAGEMENT</h3>
            
      <div class="box box-warning collapsed-box">
          
         <div class="row">
              <div class="col-md-3" runat="server" id="main_region">
                        <div class="form-group">
                <label> Region</label>
                           <asp:DropDownList id="DropDownList_Region"  class="form-control" runat="server">
                            <%-- <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>                
                           <asp:ListItem Text="Baluchistan" Value="Baluchistan"></asp:ListItem>
                                <asp:ListItem Text="Central" Value="Central"></asp:ListItem>
                                <asp:ListItem Text="North" Value="North"></asp:ListItem>
                                <asp:ListItem Text="South" Value="South"></asp:ListItem>--%>
                              </asp:DropDownList>                           
                           </div>
                         </div>
             <div class="col-md-3" runat="server" id="subregion"   visible="false"  >
                        <div class="form-group">
                <label>Sub Region</label>
                           <asp:DropDownList runat="server" class="form-control" Id="DropDownList_SubRegion">

                           </asp:DropDownList>                         
                           </div>
                         </div>
                      <div class="col-md-3">
                         <label>User</label>
                           <asp:DropDownList id="Trainer_Search"  class="form-control" runat="server">
                             <asp:ListItem Text="SE" Value="SE"></asp:ListItem>
                                <asp:ListItem Text="TMO" Value="TMO"></asp:ListItem>     
                              </asp:DropDownList>                           
                           
                         </div>
                         
                    <div class="text-right" style="font-size:12px; margin-top:35px;margin-right:10px;margin-right:50px" >
           
              <asp:Button Id="Button2" runat="server" Text="Search"  class="btn btn-facebook" OnClick="Search_User"   />
                 
      </div>
                           </div>
          
          </div>    
        
     <%--<div style="height:500px;overflow:scroll;padding-top:3%">--%>
              <br />
            <%--</div>--%>
    <br />
           
             <asp:GridView ID="SE_Grid" Visible="true" Class="table table-striped table-bordered table-condensed" EmptyDataText="There are no data records to display." 
               CellPadding="6"  runat="server"   OnRowCommand="SE_Grid_OnRowCommand" 
                 AutoGenerateColumns="false"  HeaderStyle-BackColor="#CA0003" 
                 RowStyle-CssClass="GridRowStyle" RowStyle-HorizontalAlign="Left" 
                 HeaderStyle-Wrap="true" HeaderStyle-ForeColor="White" ForeColor="#333333"  >
               <FooterStyle BackColor="#CCCC99"></FooterStyle>
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" 
                                BackColor="White"></PagerStyle>
                            <HeaderStyle  Width="20px" Wrap="true" Font-Size="12px" BorderColor="#DEDFDE" ForeColor="#CA0003" Font-Bold="True" 
                                BackColor="#FAFAFA"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
               
                            <SelectedRowStyle ForeColor="White" Font-Bold="True" 
                                    BackColor="#CE5D5A"></SelectedRowStyle>
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />

            <RowStyle BackColor="White"></RowStyle>
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />

                <Columns>  
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                                <div class="form-group">
                                
                                  <asp:Button ID="btnEdit" CssClass="btn-facebook " runat="server" 
                                   Text='Edit'  CommandName="EditC"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                
                                </div>
                        </ItemTemplate>
                              
</asp:TemplateField>
                   
                       <%-- <asp:BoundField DataField="ID" Visible="false" HeaderText="S.No." />
                      --%>
<%--                        <asp:BoundField DataField="PROJECTS" HeaderText="PROJECTS"   />  --%>
                  <%--  <asp:TemplateField HeaderText="PROJECTS">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lbtnBOLNo" runat="server" Text='<%# Eval("PROJECTS") %>' OnClick="PROJECTS_Click"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>--%> 
                       <asp:BoundField DataField="Region" HeaderText="Region" />  
                        <asp:BoundField DataField="SubRegion" HeaderText="Sub Region" /> 
                        <asp:BoundField DataField="Country_Head" HeaderText="Country Head" /> 
                        <asp:BoundField DataField="RSM" HeaderText="RSM" /> 
                        <asp:BoundField DataField="DM" HeaderText="DM"/> 
                        <asp:BoundField DataField="ASM" HeaderText="ASM" />  
                        <asp:BoundField DataField="TMO" HeaderText="TMO" />  
                    <asp:BoundField DataField="SE_Name" HeaderText="SE Name" />
                     <asp:BoundField DataField="SE_Num" HeaderText="SE Number" />  
                        <asp:BoundField DataField="DMS_Dist_Name" HeaderText="Distributor" /> 
                        <asp:BoundField DataField="City" HeaderText="City"  /> 
                
                  </Columns> 
       
           </asp:GridView>
            <asp:GridView ID="TMO_Grid" Visible="false" Class="table table-striped table-bordered table-condensed" EmptyDataText="There are no data records to display." 
               CellPadding="6"  runat="server"   OnRowCommand="TMO_Grid_OnRowCommand" 
                 AutoGenerateColumns="false"  HeaderStyle-BackColor="#CA0003" 
                 RowStyle-CssClass="GridRowStyle" RowStyle-HorizontalAlign="Left" 
                 HeaderStyle-Wrap="true" HeaderStyle-ForeColor="White" ForeColor="#333333"  >
               <FooterStyle BackColor="#CCCC99"></FooterStyle>
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" 
                                BackColor="White"></PagerStyle>
                            <HeaderStyle  Width="20px" Wrap="true" Font-Size="12px" BorderColor="#DEDFDE" ForeColor="#CA0003" Font-Bold="True" 
                                BackColor="#FAFAFA"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
               
                            <SelectedRowStyle ForeColor="White" Font-Bold="True" 
                                    BackColor="#CE5D5A"></SelectedRowStyle>
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />

            <RowStyle BackColor="White"></RowStyle>
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />

                <Columns>  
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                                <div class="form-group">
                                
                                  <asp:Button ID="btnEdit" CssClass="btn-facebook" runat="server" 
                                   Text='Edit'  CommandName="EditC"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                
                                </div>
                        </ItemTemplate>
                              
</asp:TemplateField>
                   
                       <%-- <asp:BoundField DataField="ID" Visible="false" HeaderText="S.No." />
                      --%>
<%--                        <asp:BoundField DataField="PROJECTS" HeaderText="PROJECTS"   />  --%>
                  <%--  <asp:TemplateField HeaderText="PROJECTS">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lbtnBOLNo" runat="server" Text='<%# Eval("PROJECTS") %>' OnClick="PROJECTS_Click"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>--%> 
                       <asp:BoundField DataField="Region" HeaderText="Region" />  
                        <asp:BoundField DataField="SubRegion" HeaderText="Sub Region" /> 
                        <asp:BoundField DataField="Country_Head" HeaderText="Country Head" /> 
                        <asp:BoundField DataField="RSM" HeaderText="RSM" /> 
                        <asp:BoundField DataField="DM" HeaderText="DM"/> 
                        <asp:BoundField DataField="ASM" HeaderText="ASM" />  
                        <asp:BoundField DataField="TMO" HeaderText="TMO Name" />  
                     <asp:BoundField DataField="TMO_Num" HeaderText="TMO Number" />  
                     <asp:BoundField DataField="SE_Name" HeaderText="SE Name" />
                     <asp:BoundField DataField="SE_Num" HeaderText="SE Number" />
                        <asp:BoundField DataField="DMS_Dist_Name" HeaderText="Distributor" /> 
                        <asp:BoundField DataField="City" HeaderText="City"  /> 
                
                  </Columns> 
       
           </asp:GridView>

            <div class="modal fade" id="modal-default">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Edit User Details</h4>
              </div>
              <div class="modal-body text-left">
     <div class="box box-warning collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"></h3>

             
              <!-- /.box-tools -->
            </div>
            <!-- /.box-header -->
           
                     <div class="row">
                        <div class="col-md-4">
                          <asp:Label ID="CustomerName_Label" runat="server"  Text="Name :"></asp:Label>
                           <asp:TextBox ID="Name_Text" runat="server" class="form-control" Enabled="false" ></asp:TextBox>
                        </div>
                    
                         <div class="col-md-4">
                           <asp:Label ID="Label1"  runat="server"  Text="Number :"></asp:Label>
                          <asp:TextBox ID="TextBox_number" runat="server" class="form-control" ></asp:TextBox>
                          </div>
                          <div class="col-md-4">
                       
                         <asp:Label ID="St1_Label"  runat="server"  Text="Type :"></asp:Label>
                           <asp:DropDownList id="Type_DropDown"  class="form-control" runat="server">
                                         
                           </asp:DropDownList>                           
                           
                         </div>
                     
                    </div>
                         <br />
                    <div class="row">
                    
                         <div class="col-md-3">
                           <asp:Label ID="Label3"  runat="server"  Text="Month :"></asp:Label>
                          <asp:DropDownList id="Month_DropDown" class="form-control" AppendDataBoundItems="true" runat="server">    
                          <asp:ListItem Text="Select" Value="Select"></asp:ListItem>                
                          
                          </asp:DropDownList>
                          </div>
               
                        <div class="col-md-3">
                         <asp:Label ID="Label4"  runat="server"  Text="Trainer :"></asp:Label>
                           <asp:DropDownList id="Trainer_DropDown"  class="form-control" runat="server">
                             <asp:ListItem Text="Select" Value="Select"></asp:ListItem>     
                              </asp:DropDownList>                           
                           
                         </div>
                                 <div class="col-md-3">
                       
                         <asp:Label ID="Label5"  runat="server"  Text="Initiation"></asp:Label>
                           <asp:DropDownList id="Intiation_DropDown"  class="form-control" runat="server">
                             <asp:ListItem Text="Select" Value="Select"></asp:ListItem>     
                             <asp:ListItem Text="Requested" Value="Requested"></asp:ListItem>
                             <asp:ListItem Text="Self" Value="Self"></asp:ListItem>
                                             
                           </asp:DropDownList>                           
                           
                         </div>
                    
                         <div class="col-md-3">
                           <asp:Label ID="Label6"  runat="server"  Text="Participants/Modules/Videos :"></asp:Label>
              <input id="Participants_Text" runat="server" name='Participants_Text' class="form-control input input-sm" 
                 type="number" />
                    </div>
                     
                  
                    </div>
                         <br />
                   
                            
                         <br />
                         <div class="row col-md-12" >

                    <asp:Label ID="Lable_ID" runat="server"  Text="" Visible="false"></asp:Label>
                  <div class="text-right">
                       
                  
                        
                   </div>
                  </div>
          
       </div>
              </div>
              <div class="modal-footer">
                <asp:Button Id="Update_Btn" runat="server" Text="Update"  class="btn btn-success" />
                   <asp:Button Id="Button1" runat="server" Text="Clear"  class="btn btn-danger"  />
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
             <button type="button" runat="server" style="display: none;"   id="btnShowPopup" class="btn btn-primary btn-lg"
                data-toggle="modal" data-target="#modal-default">
               
            </button>
    </div>
    </section>

    </section>
    
</asp:Content>
