<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Performance.aspx.cs" Inherits="Market_Visit_Portal.Performance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<style type="text/css">
        .auto-style1 {
            height: 35px;
        }
    </style>--%>


    <%--    <script>
        var donut = new Morris.Donut({
            element: 'sales-chart',
            resize: true,
            colors: ["#3c8dbc", "#f56954", "#00a65a"],
            data: [
              { label: "Download Sales", value: 12 },
              { label: "In-Store Sales", value: 30 },
              { label: "Mail-Order Sales", value: 20 }
            ],
            hideHover: 'auto'
        });
    </script>--%>
    <!-- Bootstrap -->
    <!-- Bootstrap DatePicker -->
    <!-- Bootstrap 3.3.7 -->
    <!-- Font Awesome -->
    
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
                    <h3 style="margin-top: 50px; color: darkred">Top Market Visitors/Areas</h3>


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
                                        <%-- <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>                
                           <asp:ListItem Text="Baluchistan" Value="Baluchistan"></asp:ListItem>
                                <asp:ListItem Text="Central" Value="Central"></asp:ListItem>
                                <asp:ListItem Text="North" Value="North"></asp:ListItem>
                                <asp:ListItem Text="South" Value="South"></asp:ListItem>--%>
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
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_TMO">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div2" >
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" Visible="false" class="form-control" ID="DropDownList_SE">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="text-right" style="font-size: 12px; margin-top: 15px; margin-right: 50px">

                                <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-facebook" OnClick="Submit_Click2" />

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <asp:Panel runat="server" ID="Panel3">
                            <div class="col-md-4">
                                <!-- MAP & BOX PANE -->
                                <div class="box box-success">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">Top Visitors </h3>

                                        <div class="box-tools pull-right">
                                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                <i class="fa fa-minus"></i>
                                            </button>

                                        </div>
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body no-padding">
                                        <div class="row" style="margin: 5px">

                                            <div class="pad">

                                                <asp:GridView ID="GridView_Visitors" Class="table table-striped table-bordered 
                "
                                                    EmptyDataText="There are no data records to display."
                                                    runat="server" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView_Visitors_OnRowCommand"
                                                    AutoGenerateColumns="false"
                                                    RowStyle-CssClass="GridRowStyle" RowStyle-HorizontalAlign="Left" RowStyle-Wrap="true"
                                                    HeaderStyle-Wrap="true" HeaderStyle-ForeColor="White" ForeColor="#333333">
                                                    <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                    <PagerStyle ForeColor="Black" HorizontalAlign="Right"
                                                        BackColor="White"></PagerStyle>
                                                    <HeaderStyle Width="20px" Wrap="true" Font-Size="12px" BorderColor="#DEDFDE" ForeColor="White" Font-Bold="True"
                                                        BackColor="#00a65a" HorizontalAlign="Center"></HeaderStyle>
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
                                                        <asp:BoundField DataField="Visitor_Name" HeaderText="Visitor Name" />
                                                        <asp:BoundField DataField="Total" HeaderText="Visits" />

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btndetails"  runat="server"
                                                                    Text='Details' CommandName="Details" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>


                                            </div>


                                        </div>
                                        <!-- /.col -->

                                        <!-- /.col -->

                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.box-body -->

                                <%--<div class="box-footer">

                                    <br />

                                    <!-- /.row -->
                                </div>--%>
                            </div>
                            <!-- /.box -->
                            <div class="col-md-4">
                                <!-- MAP & BOX PANE -->
                                <div class="box box-info">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">Most Frequent Visited Areas </h3>

                                        <div class="box-tools pull-right">
                                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                <i class="fa fa-minus"></i>
                                            </button>

                                        </div>
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body no-padding">
                                        <div class="row" style="margin: 5px">

                                            <div class="pad">

                                                <asp:GridView ID="GridView_Visitors_City" Class="table table-striped table-bordered 
                "
                                                    EmptyDataText="There are no data records to display."
                                                    runat="server" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView_TopAreas_OnRowCommand"
                                                    AutoGenerateColumns="false"
                                                    RowStyle-CssClass="GridRowStyle" RowStyle-HorizontalAlign="Left" RowStyle-Wrap="true"
                                                    HeaderStyle-Wrap="true" HeaderStyle-ForeColor="White" ForeColor="#333333">
                                                    <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                    <PagerStyle ForeColor="Black" HorizontalAlign="Right"
                                                        BackColor="White"></PagerStyle>
                                                    <HeaderStyle Width="20px" Wrap="true" Font-Size="12px" BorderColor="#DEDFDE" ForeColor="White" Font-Bold="True"
                                                        BackColor="#0083ef" HorizontalAlign="Center"></HeaderStyle>
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
                                                        <asp:BoundField DataField="City" HeaderText="City" />
                                                        <asp:BoundField DataField="Total" HeaderText="Visits" />

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btndetails"  runat="server"
                                                                    Text='Details' CommandName="Details" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>


                                            </div>


                                        </div>
                                        <!-- /.col -->

                                        <!-- /.col -->

                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.box-body -->

                                <%-- <div class="box-footer">
                  
                   <br />
                   
              <!-- /.row -->
            </div>--%>
                            </div>
                            <!-- /.row -->
                            <div class="col-md-4">
                                <!-- MAP & BOX PANE -->
                                <div class="box box-danger">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">Least Visited Areas </h3>

                                        <div class="box-tools pull-right">
                                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                <i class="fa fa-minus"></i>
                                            </button>

                                        </div>
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body no-padding">
                                        <div class="row" style="margin: 5px">

                                            <div class="pad">

                                                <asp:GridView ID="GridView_LeastAreas" Class="table table-striped table-bordered 
                "
                                                    EmptyDataText="There are no data records to display."
                                                    runat="server" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView_LeastAreas_OnRowCommand"
                                                    AutoGenerateColumns="false"
                                                    RowStyle-CssClass="GridRowStyle" RowStyle-HorizontalAlign="Left" RowStyle-Wrap="true"
                                                    HeaderStyle-Wrap="true" HeaderStyle-ForeColor="White" ForeColor="#333333">
                                                    <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                    <PagerStyle ForeColor="Black" HorizontalAlign="Right"
                                                        BackColor="White"></PagerStyle>
                                                    <HeaderStyle Width="20px" Wrap="true" Font-Size="12px" BorderColor="#DEDFDE" ForeColor="White" Font-Bold="True"
                                                        BackColor="#b01a07" HorizontalAlign="Center"></HeaderStyle>
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
                                                        <asp:BoundField DataField="City" HeaderText="City" />
                                                        <asp:BoundField DataField="Total" HeaderText="Visits" />

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btndetails"  runat="server"
                                                                    Text='Details' CommandName="Details" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>


                                            </div>


                                        </div>
                                        <!-- /.col -->

                                        <!-- /.col -->

                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.box-body -->


                            </div>
                             </asp:Panel>
                        <!-- /.col -->
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
                                        <div class="row">



                                            <%--        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="fa fa-check"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Approved</span>
              <span class="info-box-number" runat="server" id="approve_count">0</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-aqua"><i class="fa fa-plus"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">New</span>
              <span class="info-box-number" runat="server" id="new_count">0</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-retweet"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Halted</span>
              <span class="info-box-number" runat="server" id="holted_count">0</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-close"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Rejected</span>
              <span class="info-box-number" runat="server" id="reject_count">0</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->--%>
                                        </div>
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
