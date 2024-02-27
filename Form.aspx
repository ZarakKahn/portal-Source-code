<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Market_Visit_Portal.Form" %>
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
         
        <div class="container">
            <div class="text-right" style="margin-top:50px;">
        <span class="badge" runat="server" id="user_name" style="padding-left:10px;padding-right:10px;padding-top:4px;padding-bottom:4px;background-color:darkred">Iqra Iqbal</span>

<asp:Button Id="Button2" runat="server" Text="Logout"  class="btn-danger" OnClick="Logout_Click"  />

</div>
             <div class="text-center">
           <h3  style="margin-top:50px;color:darkred">VISITS PLANNER</h3>
   
     <div class="box box-default collapsed-box" style="padding-left:20px;padding-bottom:10px">
               <div class="box-header">
              <h3 class="box-title"> Bulk Upload Plane</h3>

             
              <!-- /.box-tools -->
            </div>
            
             <div class="text-left" >
                   <asp:FileUpload ID="Bulk_Project" class="btn btn-danger" runat="server" />
                <asp:Button ID="Button5" runat="server" class="btn btn-warning"   Text="Upload File"   />
                <div style="padding:10px;overflow:scroll">
                   <asp:GridView ID="Project_Bulk" runat="server" EmptyDataText="There are no data records to display." 
                       Class="table table-striped table-bordered table-condensed" CellPadding="4"  
                     AutoGenerateColumns="true"  HeaderStyle-BackColor="#CA0003" 
                     RowStyle-CssClass="GridRowStyle" RowStyle-HorizontalAlign="Left" 
                     HeaderStyle-Wrap="true" HeaderStyle-ForeColor="White" ForeColor="#333333" >
                        <AlternatingRowStyle BackColor="White" />
                    
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

                        <HeaderStyle Wrap="True" BackColor="#990000" ForeColor="White" Font-Bold="True"></HeaderStyle>

                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />

                        <RowStyle HorizontalAlign="Left" CssClass="GridRowStyle" BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>  
                 </div>   
                 <asp:Button Id="Button6" runat="server" Text="Submit"  class="btn btn-success"   />     
             </div>
                </div>
          </div>
            </div>
        </section>
    </section>
</asp:Content>
