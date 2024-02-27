<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Visits.aspx.cs" Inherits="Market_Visit_Portal.Visits" %>
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
    <script type = "text/javascript">
    var GridId = "<%=GridView1.ClientID %>";
    var ScrollHeight = 300;
    window.onload = function () {
        var grid = document.getElementById(GridId);
        var gridWidth = grid.offsetWidth;
        var gridHeight = grid.offsetHeight;
        var headerCellWidths = new Array();
        for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
            headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
        }
        grid.parentNode.appendChild(document.createElement("div"));
        var parentDiv = grid.parentNode;
 
        var table = document.createElement("table");
        for (i = 0; i < grid.attributes.length; i++) {
            if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
            }
        }
        table.style.cssText = grid.style.cssText;
        table.style.width = gridWidth + "px";
        table.appendChild(document.createElement("tbody"));
        table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
        var cells = table.getElementsByTagName("TH");
 
        var gridRow = grid.getElementsByTagName("TR")[0];
        for (var i = 0; i < cells.length; i++) {
            var width;
            if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                width = headerCellWidths[i];
            }
            else {
                width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
            }
            cells[i].style.width = parseInt(width - 3) + "px";
            gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
        }
        parentDiv.removeChild(grid);
 
        var dummyHeader = document.createElement("div");
        dummyHeader.appendChild(table);
        parentDiv.appendChild(dummyHeader);
        var scrollableDiv = document.createElement("div");
        if(parseInt(gridHeight) > ScrollHeight){
             gridWidth = parseInt(gridWidth) + 17;
        }
        scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
        scrollableDiv.appendChild(grid);
        parentDiv.appendChild(scrollableDiv);
    }
</script>
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
                    <h3 style="margin-top: 50px; color: darkred">MV DETAILED REPORT</h3>


                    <div class="box box-warning collapsed-box">

                        <div class="row" style="padding: 5px">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>From Date:</label>

                                    <div class="input-group date">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" autocomplete="off" class="form-control pull-right" id="datepicker_from" />
                                    </div>
                                    <!-- /.input group -->
                                </div>

                            </div>
                            <div class="col-md-2">

                                <div class="form-group">
                                    <label>To Date:</label>

                                    <div class="input-group date">
                                        <div class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </div>
                                        <input type="text" runat="server" autocomplete="off" class="form-control pull-right" id="datepicker_to" />
                                    </div>
                                    <!-- /.input group -->
                                </div>

                            </div>
                            <div class="col-md-2" runat="server" id="region">
                                <div class="form-group">
                                    <label>Region</label>
                                    <asp:DropDownList ID="DropDownList_Region" class="form-control" runat="server" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_Region_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="subregion" >
                                <div class="form-group">
                                    <label>Handler</label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_SubRegion" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_SubRegion_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div1" >
                                <div class="form-group">
                                    <label>Team</label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_TMO" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_TMO_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div2" >
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" Visible="false" class="form-control" ID="DropDownList_SE" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_SE_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="text-right" style="font-size: 12px; margin-top: 15px; margin-right: 50px">
                                
               <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-facebook" OnClick="Submit_Click2" />
                               
                            </div>
                       
                        </div>
                    </div>
              
                    <div class="row">
        
       <div class="row">
<div class="container text-right">
            
               <asp:Button Id="Button4" runat="server" Visible="false" Text="Export into Excel"  class="btn btn-success"   />
             
      </div>
                                        </div>
        <h3  style="margin-top:5px;color:darkred"></h3>
                 <div runat="server" style="padding:10px;overflow:auto;height:400px">
                <asp:GridView ID="GridView1"  Class="table table-striped table-bordered 
                " EmptyDataText="There are no data records to display." 
                runat="server"   OnRowDataBound="GridView1_OnRowDataBound" OnRowCommand="GridView1_OnRowCommand"
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
                     
                    
                        <asp:BoundField DataField="ID" Visible="false" HeaderText="S.No." />  
                        <asp:BoundField HeaderText="Region"  DataField="Region" ItemStyle-Width="50" /> 
                        <asp:BoundField HeaderText="Handler"  DataField="Sub_Region" ItemStyle-Width="50" /> 
                        <asp:BoundField HeaderText="RSM Name" DataField="RSM" ItemStyle-Width="50" />  
                        <asp:BoundField HeaderText="DM Name" DataField="DM" ItemStyle-Width="40" /> 
                        <asp:BoundField HeaderText="ASM Name" DataField="ASM" ItemStyle-Width="40" />
                        <asp:BoundField HeaderText="TSO" DataField="Visitor_Name" ItemStyle-Width="40" />  
                     <asp:BoundField HeaderText="Visits Counts" DataField="Visits_Counts" ItemStyle-Width="50" />  

                    <asp:TemplateField HeaderText=""  ItemStyle-Width="50">
                        <ItemTemplate>
                            <asp:Button ID="btndetails" CssClass="btn-success" runat="server" 
                                   Text='Details' CommandName="Details"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
       
</asp:TemplateField>
                       
                </Columns> 
       
           </asp:GridView>
           
                    </div>
                       <br />
      
                 </div>
               <div class="row">
                        <asp:Panel runat="server" ID="Panel1">
                            <h3 style="color: darkred">VISITOR DETAIL REPORT</h3>


                            <div class="col-md-12">
                                <!-- MAP & BOX PANE -->
                                <div class="box box-danger">
                                    <div class="box-header with-border">
                                        <div class="row col-md-12">
                                            
                                            <div class="col-md-3 col-sm-6 col-xs-12">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-aqua"><i class="ion ion-stats-bars"></i></span>

                                                    <div class="info-box-content">
                                                        <span class="info-box-text" style="margin-top: 10px">Sales Volume</span>
                                                        <span class="info-box-number" runat="server" id="SalesVolume" style="margin-top: 10px">0</span>
                                                    </div>
                                                    <!-- /.info-box-content -->
                                                </div>
                                                <!-- /.info-box -->
                                            </div>
                                            <!-- /.col -->
                                            <div class="col-md-3 col-sm-6 col-xs-12">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-green"><i class="fa fa-star-o"></i></span>

                                                    <div class="info-box-content">
                                                        <span class="info-box-text" style="margin-top: 10px">Recovery</span>
                                                        <span class="info-box-number" runat="server" id="Recovery" style="margin-top: 10px">0</span>
                                                    </div>
                                                    <!-- /.info-box-content -->
                                                </div>
                                                <!-- /.info-box -->
                                            </div>
                                            <!-- /.col -->
                                            <div class="col-md-3 col-sm-6 col-xs-12">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-yellow"><i class="ion ion-person-add"></i></span>

                                                    <div class="info-box-content">
                                                        <span class="info-box-text" style="margin-top: 10px">New Shop Visits</span>
                                                        <span class="info-box-number" runat="server" id="New_shop" style="margin-top: 10px">0</span>
                                                    </div>
                                                    <!-- /.info-box-content -->
                                                </div>
                                                <!-- /.info-box -->
                                            </div>
                                            <!-- /.col -->
                                            <div class="col-md-3 col-sm-6 col-xs-12">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-red"><i class="ion ion-pie-graph"></i></span>

                                                    <div class="info-box-content">
                                                        <span class="info-box-text" style="margin-top: 10px">Existing Shop Visits</span>
                                                        <span class="info-box-number" runat="server" id="Existing_Shops" style="margin-top: 10px">0</span>
                                                    </div>
                                                    <!-- /.info-box-content -->
                                                </div>
                                                <!-- /.info-box -->
                                            </div>
                                            <!-- /.col -->
                                        </div>
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body no-padding">
                                        <div style="padding: 10px; overflow: auto; height: 400px">
                                            <asp:GridView ID="Projects_Grid" Class="table table-striped table-bordered 
                "
                                                EmptyDataText="There are no data records to display."
                                                runat="server" OnRowDataBound="OnRowDataBound"
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


                                                    <asp:BoundField DataField="ID" Visible="false" HeaderText="S.No." />
                                                    <%--<asp:HyperLinkField
								DataNavigateUrlFields="PROJECTS"
								DataNavigateUrlFormatString="Projects.aspx"
								DataTextField="PROJECTS"
								HeaderText="PROJECTS"
                           ControlStyle-ForeColor="White"
                          
								>
								<ItemStyle HorizontalAlign="Center" Width="50"></ItemStyle>
						   </asp:HyperLinkField>--%>
                                                    <asp:BoundField DataField="Cust_Name" HeaderText="SHOP" ItemStyle-Width="200" />
                                                    <asp:BoundField DataField="Distributor" HeaderText="Distributor" ItemStyle-Width="200" />
                                                    <asp:BoundField DataField="Visitor_Name" HeaderText="SE Name" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="Visitor_Num" HeaderText="SE Number" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="VisitType" HeaderText="Visit Type" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="Purpose" HeaderText="PURPOSE" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="Recovery" HeaderText="Recovery" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="SalesVolume" HeaderText="Sales Volume" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="Complaint" HeaderText="Complaints" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="VisitDatetime" HeaderText="DATE" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="Location" HeaderText="Location" Visible="false" ItemStyle-Width="50" />
                                                    <asp:TemplateField HeaderText="Location">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server"
                                                                Text='get location'
                                                                Target="_blank">
                                                            </asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TxnID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTxnID" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                        <br />
                                      </div>  
                                    </div>
                                </div>
                           
                        </asp:Panel>
                    </div>
                </div>
                </div>
            </section>
         </section>
</asp:Content>
