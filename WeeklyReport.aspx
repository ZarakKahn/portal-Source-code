<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WeeklyReport.aspx.cs" Inherits="Market_Visit_Portal.WeeklyReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="about-text ptb-100">
        <section class="section-title">

            <div class="container">
                <div class="text-right" style="margin-top: 70px;">
                    <span class="badge" runat="server" id="user_name" style="padding-left: 10px; padding-right: 10px; padding-top: 4px; padding-bottom: 4px; background-color: darkred">Iqra Iqbal</span>

                    <asp:Button ID="Button2" runat="server" Text="Logout" class="btn-default" OnClick="Logout_Click" />

                </div>
                <div class="text-center">
                    <h3 style="margin-top: 50px; color: darkred">WEEKLY STATUS REPORT</h3>


                    <div class="box box-warning collapsed-box">

                        <div class="row" style="padding: 5px">
                            <div class="col-md-2" runat="server" id="region">
                                <div class="form-group">
                                    <label>Region</label>
                                    <asp:DropDownList ID="DropDownList_Region" class="form-control" runat="server" ViewStateMode="Enabled" EnableViewState="true" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="subregion" >
                                <div class="form-group">
                                    <label>Sub Region</label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_SubRegion" ViewStateMode="Enabled" EnableViewState="true" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                           <div class="text-right" style="font-size: 12px; margin-top: 15px; margin-right: 50px">
                                
               <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-facebook" OnClick="Submit_Click2" />
                               
                            </div>
                       
                            </div>
     </div>
                    </div>
                     <asp:GridView ID="GridView1"  Class="table table-striped table-bordered 
                " EmptyDataText="There are no data records to display." 
                runat="server"   OnRowDataBound="GridView1_OnRowDataBound"
                 AutoGenerateColumns="false" 
                 RowStyle-CssClass="GridRowStyle" RowStyle-HorizontalAlign="Left"  RowStyle-Wrap="true"
                 HeaderStyle-Wrap="true" HeaderStyle-ForeColor="White" ForeColor="#333333" >
               <FooterStyle BackColor="#CCCC99"></FooterStyle>
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" 
                                BackColor="White"></PagerStyle>
                            <HeaderStyle  Width="20px" Wrap="true" Font-Size="12px"  BorderColor="#DEDFDE" ForeColor="White" Font-Bold="True" 
                                BackColor="#990000" HorizontalAlign="Center"></HeaderStyle>
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
                     
                    
                        <asp:BoundField HeaderText="Sub Region"  DataField="Sub Region" ItemStyle-Width="100" /> 
                        <asp:BoundField HeaderText="Visitor Name" DataField="Visitor_Name" ItemStyle-Width="50" />  
                        <asp:BoundField HeaderText="Desigantion" DataField="Desigantion" ItemStyle-Width="40" /> 
                        <asp:BoundField HeaderText="CITY" DataField="CITY" ItemStyle-Width="40" />
                    <asp:BoundField HeaderText="Using App" DataField="Using App" ItemStyle-Width="40" />    
                        <asp:BoundField HeaderText="MTD" DataField="MTD" ItemStyle-Width="40" />  
                     <asp:BoundField HeaderText="Week 1" DataField="Week 1" ItemStyle-Width="50" />  
                     <asp:BoundField HeaderText="Week 2" DataField="Week 2" ItemStyle-Width="50" />  
                     <asp:BoundField HeaderText="Week 3" DataField="Week 3" ItemStyle-Width="50" />  
                     <asp:BoundField HeaderText="Week 4" DataField="Week 4" ItemStyle-Width="50" />  
                        <asp:BoundField HeaderText="Week 5" DataField="Week 5" ItemStyle-Width="50" />  

                </Columns> 
       
           </asp:GridView>
           

              </div>
            </section>
        </section>  
</asp:Content>
