<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OMC.aspx.cs" Inherits="Market_Visit_Portal.OMC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


      <script src="http://code.jquery.com/jquery-1.8.2.js"></script>  

   
    <script type="text/javascript">


        $(function () {
            $('#ContentPlaceHolder1_datepicker_from').datepicker({
                autoclose: true,

            }).data(new Date())

            $('#ContentPlaceHolder1_datepicker_to').datepicker({
                autoclose: true
            })

        })

    </script>
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
                <div class="text-right" style="margin-top: 50px;">
                    <span class="badge" runat="server" id="user_name" style="padding-left: 10px; padding-right: 10px; padding-top: 4px; padding-bottom: 4px; background-color: darkred">Iqra Iqbal</span>

                    <asp:Button ID="Button2" runat="server" Text="Logout" class="btn-default" OnClick="Logout_Click" />

                </div>
                <div class="text-center">
                    <h3 style="margin-top: 50px; color: darkred">OMC Secondary Sales Data Uploader</h3>


                    <div class="box box-warning collapsed-box">

                        <div class="row" style="padding: 5px">
                           
                            <div class="col-md-3">

                                <div class="form-group">
                                    <label>Date:</label>

                                    <div class="input-group date">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" autocomplete="off" class="form-control pull-right" id="datepicker_to" />
                                    </div>
                                    <!-- /.input group -->
                                </div>

                            </div>
                            <div class="col-md-3" runat="server" id="region">
                                <div class="form-group">
                                    <label>Dealer Name</label>
                                      <asp:DropDownList ID="DropDownList_Dealers" class="form-control" runat="server" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_Dealers_SelectedIndexChanged">
                         
                                    </asp:DropDownList>
                                

                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="subregion" >
                                <div class="form-group">
                                    <label>Finance Type</label>
                                     <input type="text" class="form-control" id="Text_type"  runat="server" readonly  placeholder="Enter">
                                  
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div1" >
                                <div class="form-group">
                                    <label>Sales Person</label>
                                     <input type="text" class="form-control" id="Text_salesperson"  runat="server" readonly  placeholder="Enter">
                                  
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div2" >
                                <div class="form-group">
                                    <label>Region</label>
                                    <input type="text" class="form-control" id="Text_region"  runat="server" readonly  placeholder="Enter">
                                  
                                </div>
                            </div>

                            
                        </div>
                         <div class="row" style="padding: 5px">
                           
                            <div class="col-md-3">

                                <div class="form-group">
                                    <label>Petroleum Motor Gasoline - PMG:</label>
                                      <input type="text" class="form-control" id="PMG"  runat="server" placeholder="Enter">
                                   
                                    <!-- /.input group -->
                                </div>

                            </div>
                            <div class="col-md-3" runat="server" id="Div3">
                                <div class="form-group">
                                    <label>Hi-Speed Diesel - HSD</label>
                                      <input type="text" class="form-control" id="HSD"  runat="server" placeholder="Enter">
                                    <%--<asp:DropDownList ID="DropDownList_Region" class="form-control" runat="server" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_Region_SelectedIndexChanged">
                         
                                    </asp:DropDownList>
                                --%>

                                </div>
                            </div>
                            <div class="col-md-3" runat="server" id="Div4" >
                                <div class="form-group">
                                    <label>HOBC</label>
                                      <input type="text" class="form-control" id="HOBC"  runat="server" placeholder="Enter">
                                </div>
                            </div>
                            

                            
                        </div>
                           <div class="row" style="padding: 5px">
                        <div class="text-right" style="font-size: 12px; margin-top: 15px; margin-right: 50px">

                                <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-facebook" OnClick="Submit_Click2" />
                            <asp:Button ID="Button4" runat="server" Text="Update" class="btn btn-facebook" OnClick="Update_Click" Visible="false"/>
                            <asp:Button ID="Button3" runat="server" Text="Show" class="btn btn-facebook" OnClick="Show_Click" />
                            </div>
                               </div>
                        <div class="row" style="padding: 5px">
                            <asp:GridView ID="OMC_Sales_Grid" Class="table table-striped table-bordered 
                "
                                                EmptyDataText="There are no data records to display."
                                                runat="server"  OnRowCommand="GridView_Visitors_OnRowCommand" OnRowDataBound="OnRowDataBound"
                                                AutoGenerateColumns="false"
                                                RowStyle-CssClass="GridRowStyle" RowStyle-HorizontalAlign="Left" RowStyle-Wrap="true"
                                                HeaderStyle-Wrap="true" HeaderStyle-ForeColor="White" ForeColor="#333333">
                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                <PagerStyle ForeColor="Black" HorizontalAlign="Right"
                                                    BackColor="White"></PagerStyle>
                                                <HeaderStyle
                                                    Width="20px" Wrap="true"
                                                    Font-Size="12px" BorderColor="#DEDFDE" ForeColor="White" Font-Bold="True"
                                                    BackColor="#005384" HorizontalAlign="Center"></HeaderStyle>
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


                                                    <asp:BoundField DataField="ID"  HeaderText="S.No." />
                                                    <asp:BoundField DataField="Dealer" HeaderText="Dealer Name" ItemStyle-Width="200" />
                                                    <asp:BoundField DataField="Financetype" HeaderText="Finance Type" ItemStyle-Width="200" />
                                                    <asp:BoundField DataField="Salesperson" HeaderText="Sales Person" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="Region" HeaderText="Region" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="PMG" HeaderText="PMG" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="HSD" HeaderText="HSD" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="HOBC" HeaderText="HOBC" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="50" />
                                                  
                                                     <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btndelete"  runat="server"
                                                                    Text='Delete' CommandName="DeleteRow" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnedit"  runat="server"
                                                                    Text='Edit' CommandName="EditRow" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>


                            </div>
                    </div>
</div>
                </div>
            </section>
        </section>
    
</asp:Content>
