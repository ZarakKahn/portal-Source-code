<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportAreaTeam.aspx.cs" Inherits="Market_Visit_Portal.ReportAreaTeam" %>
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
    var GridId = "<%=GridView_area.ClientID %>";
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
<script type = "text/javascript">
    var GridId = "<%=GridView3.ClientID %>";
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

    <style>
        .daysCheckbox1{
zoom:1;

}
.daysCheckbox2{
zoom:1.5;

}
.daysCheckbox3{
zoom:2;

}
.daysCheckbox4{
zoom:2.5;

}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"   >
     <section class="about-text ptb-100">
        <section class="section-title">

            <div class="container">
                <div class="text-right" style="margin-top: 70px;">
                    <span class="badge" runat="server" id="user_name" style="padding-left: 10px; padding-right: 10px; padding-top: 4px; padding-bottom: 4px; background-color: darkred">Iqra Iqbal</span>

                    <asp:Button ID="Button2" runat="server" Text="Logout" class="btn-default" OnClick="Logout_Click" />

                </div>
                <div class="text-center">
                    <h3 style="margin-top: 50px; color: darkred">MV STATUS REPORT</h3>


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
                                    <label>TSO</label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_TMO" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_TMO_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div2" >
                                <div class="form-group">
                                    <label ></label>
                                    <asp:DropDownList runat="server" Visible="false" class="form-control" ID="DropDownList_SE" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_SE_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div3" >
                                <div class="form-group">
                                    <label>Area</label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_Area" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_Area_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                             <div class="col-md-2" runat="server" id="Div4" >
                                <div class="form-group">
                                    <label>Retailer</label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_Retailor" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_Retailor_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            </div>
                            <div class="row text-right" style="font-size: 12px; margin: 5px; margin-right: 50px">
                                <label style="margin-right:10px">
                  <asp:CheckBox ID="Summary" runat="server"
     Checked="true" CssClass="daysCheckbox2" AutoPostBack="true" OnCheckedChanged="Summary_CheckedChanged" />
               SUMMARY
                            </label>
                       <label style="margin-right:10px">
                  <asp:CheckBox ID="Area" runat="server" AutoPostBack="true"
     Checked="false" CssClass="daysCheckbox2" OnCheckedChanged="Area_CheckedChanged"/>
               AREA WISE
                            </label>
                <label style="margin-right:10px">
                  <asp:CheckBox ID="Team" runat="server"  AutoPostBack="true"
     Checked="false" CssClass="daysCheckbox2" OnCheckedChanged="Team_CheckedChanged"/>
               TEAM WISE
                     </label>
                         <label style="margin-right:10px">
                  <asp:CheckBox ID="Retailor" runat="server"  AutoPostBack="true"
     Checked="false" CssClass="daysCheckbox2" OnCheckedChanged="Retailor_CheckedChanged"/>
               RETAILER WISE
                     </label>      
    
               <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-facebook" OnClick="Submit_Click2" />
                               
                             </div> 

                    </div>
                       
                        </div>
                <asp:Panel runat="server" ID="regional_counts">
                             <h3  style="margin-top:1px;color:darkred">REGIONAL SUMMARY</h3>
                      <asp:GridView ID="GridView2"  Class="table table-striped table-bordered 
                " EmptyDataText="There are no data records to display." 
                runat="server"   OnRowDataBound="GridView2_OnRowDataBound"
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
                    <asp:BoundField HeaderText="Handler"  DataField="Handler" ItemStyle-Width="50" /> 
                    <asp:BoundField HeaderText="Cities"  DataField="cities" ItemStyle-Width="50" />     
                    <asp:BoundField HeaderText="Visited Days" DataField="Visited Days" ItemStyle-Width="50" />  
                        <asp:BoundField HeaderText="Visits" DataField="Visits" ItemStyle-Width="40" /> 
                     <asp:BoundField HeaderText="Avg PD" DataField="Avg PD" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="Retailer" DataField="Retailor" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="Existing Retailers" DataField="Existing Retailor" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="New Retailers" DataField="New Retailor" ItemStyle-Width="40" /> 
                     <asp:BoundField HeaderText="Recovery" DataField="Recovery" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="SalesVolume" DataField="Sales" ItemStyle-Width="40" /> 
                </Columns> 
       
           </asp:GridView>
           
        </asp:Panel>
                <asp:Panel runat="server" ID="area_counts">
         <h3 runat="server" id="title" style="margin-top:1px;color:darkred">AREA SUMMARY</h3>
                 <div runat="server" style="overflow:auto;height:400px">
                <asp:GridView ID="GridView_area"  Class="table table-striped table-bordered 
                " EmptyDataText="There are no data records to display." 
                runat="server"  OnRowDataBound="GridViewArea_OnRowDataBound" 
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
                        <asp:BoundField HeaderText="Area"  DataField="City" ItemStyle-Width="50" /> 
                    <asp:BoundField HeaderText="Visitor"  DataField="Visitor_Name" ItemStyle-Width="50" />     
                    <asp:BoundField HeaderText="Visited Days" DataField="Visited Days" ItemStyle-Width="50" />  
                        <asp:BoundField HeaderText="Visits" DataField="Visits" ItemStyle-Width="40" /> 
                     <asp:BoundField HeaderText="Avg PD" DataField="Avg PD" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="Retailers" DataField="Retailor" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="Existing Retailers" DataField="Existing Retailor" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="New Retailers" DataField="New Retailor" ItemStyle-Width="40" /> 
                </Columns> 
       
           </asp:GridView>
     <asp:GridView ID="GridView3"  Class="table table-striped table-bordered 
                " EmptyDataText="There are no data records to display." 
                runat="server"  OnRowDataBound="GridView3_OnRowDataBound"
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
                       <asp:BoundField HeaderText="Region"  DataField="region" ItemStyle-Width="50" /> 
                    <asp:BoundField HeaderText="Visitor"  DataField="Visitor_Name" ItemStyle-Width="50" /> 
                      <asp:BoundField HeaderText="Area"  DataField="Cities" ItemStyle-Width="50" />     
                    <asp:BoundField HeaderText="Visited Days" DataField="Visited Days" ItemStyle-Width="50" />  
                        <asp:BoundField HeaderText="Visits" DataField="Visits" ItemStyle-Width="40" /> 
                     <asp:BoundField HeaderText="Avg PD" DataField="Avg PD" ItemStyle-Width="40" /> 
                      <asp:BoundField HeaderText="Recovery"  DataField="Recovery" ItemStyle-Width="50" />
                      <asp:BoundField HeaderText="Sale Volume"  DataField="Sales" ItemStyle-Width="50" />  
                    <asp:BoundField HeaderText="Retailers" DataField="Retailor" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="Existing Retailers" DataField="Existing Retailor" ItemStyle-Width="40" /> 
                    <asp:BoundField HeaderText="New Retailers" DataField="New Retailor" ItemStyle-Width="40" /> 
                </Columns> 
       
           </asp:GridView>
                      
                 </div>
                    </asp:Panel>
                       <br />
      
                 </div>
             
            </section>
         </section>
</asp:Content>
