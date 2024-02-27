<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard_Retailor.aspx.cs" Inherits="Market_Visit_Portal.Dashboard_Retailor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>


    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });

        google.charts.setOnLoadCallback(drawChart);
        google.charts.setOnLoadCallback(drawbar);
        google.charts.setOnLoadCallback(drawbar_city);

    </script>
    <style type="text/css">
        .FixedHeader {
            font-weight: bold;
            position: absolute;
            background-color: blue;
        }
    </style>
    <script type="text/javascript">


        $(function () {
            $('#ContentPlaceHolder1_datepicker_from').datepicker({
                autoclose: true,

            }).data(new Date())

            $('#ContentPlaceHolder1_datepicker_to').datepicker({
                autoclose: true
            })
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Dashboard_Retailor.aspx/GetChartData',
                data: '{}',
                success:
                function (response) {
                    drawchart(response.d);
                },

                error: function () {
                    alert("Error loading data!");
                }
            });
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Dashboard_Retailor.aspx/GetTop_RetailorVisits',
                data: '{}',
                success:
                function (response) {
                    drawbar(response.d);
                },

                error: function () {
                    alert("Error loading data!");
                }
            });
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Dashboard_Retailor.aspx/GetData_Least',
                data: '{}',
                success:
                function (response) {
                    drawbar_least(response.d);
                },

                error: function () {
                    alert("Error loading data!");
                }
            });
        //    $.ajax({
        //        type: 'POST',
        //        dataType: 'json',
        //        contentType: 'application/json',
        //        url: 'Dashboard_Retailor.aspx/GetBarData_City',
        //        data: '{}',
        //        success:
        //        function (response) {
        //            drawbar_city(response.d);
        //        },

        //        error: function () {
        //            alert("Error loading data!");
        //        }
        //    });
        //    $.ajax({
        //        type: 'POST',
        //        dataType: 'json',
        //        contentType: 'application/json',
        //        url: 'Dashboard_Retailor.aspx/Get_Complaints',
        //        data: '{}',
        //        success:
        //        function (response) {
        //            drawbar_com(response.d);
        //        },

        //        error: function () {
        //            alert("Error loading data!");
        //        }
        //    });
        })
        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].EmployeeCity, dataValues[i].Total]);
            }

            var options = {
                width: 500,
                height: 200,
                title: 'MARKET VISIT REGIONAL REPORT',
                is3D: true,
            };

            new google.visualization.PieChart(document.getElementById('myChartDiv')).
            draw(data, options);
        }

        function drawbar(dataValues) {

            var data = new google.visualization.DataTable();
            data.addColumn('string', '');
            data.addColumn('number', 'Visits');
            data.addColumn({ type: 'string', role: 'style' });
            data.addColumn({ type: 'number', role: 'annotation' });
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].EmployeeCity, dataValues[i].Total, 'color: #00a65a', dataValues[i].Total]);
            }
            new google.visualization.BarChart(document.getElementById('myBarDiv')).
            draw(data, { width: 500, height: 250, min: 0, title: 'Top Retailors' });
        }
        function drawbar_least(dataValues) {

            var data = new google.visualization.DataTable();
            data.addColumn('string', '');
            data.addColumn('number', 'Visits');
            data.addColumn({ type: 'string', role: 'style' });
            data.addColumn({ type: 'number', role: 'annotation' });
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].EmployeeCity, dataValues[i].Total, 'color: #d33724', dataValues[i].Total]);
            }
            new google.visualization.BarChart(document.getElementById('myBarDiv_least')).
            draw(data, { width: 500, height: 250, min: 0, title: 'Least Retailors' });
        }
        function drawbar_city(dataValues) {

            var data = new google.visualization.DataTable();
            data.addColumn('string', '');
            data.addColumn('number', 'Visits');
            data.addColumn({ type: 'number', role: 'annotation' });
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].EmployeeCity, dataValues[i].Total, dataValues[i].Total]);
            }

            new google.visualization.BarChart(document.getElementById('myBarDiv2')).
            draw(data, { width: 500, height: 250, min: 0, title: 'Top Visited Areas' });
        }
        function drawbar_com(dataValues) {

            var data = new google.visualization.DataTable();
            data.addColumn('string', '');
            data.addColumn('number', 'Visits');
            data.addColumn({ type: 'string', role: 'style' });
            data.addColumn({ type: 'number', role: 'annotation' });
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].EmployeeCity, dataValues[i].Total, 'color: #f39c12', dataValues[i].Total]);
            }

            new google.visualization.BarChart(document.getElementById('myBarDiv_com')).
            draw(data, { width: 500, height: 250, min: 0, title: 'Top Complaints' });
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


    <section class="about-text ptb-100">
        <section class="section-title">

            <div class="container">
                <div class="text-right" style="margin-top: 50px;">
                    <span class="badge" runat="server" id="user_name" style="padding-left: 10px; padding-right: 10px; padding-top: 4px; padding-bottom: 4px; background-color: darkred">Iqra Iqbal</span>

                    <asp:Button ID="Button2" runat="server" Text="Logout" class="btn-default" OnClick="Logout_Click" />

                </div>
                <div class="text-center">
                    <h3 style="margin-top: 30px; color: darkred">Retailor DASHBOARD</h3>


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
                                    <label>Sub Region</label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_SubRegion" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" onselectedindexchanged="DropDownList_SubRegion_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div1" >
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_TMO" Visible="false">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div2" >
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_SE" Visible="false">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="text-right" style="font-size: 12px; margin-top: 15px; margin-right: 50px">

                                <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-facebook" OnClick="Submit_Click2" />
                                <asp:Button ID="Button3" runat="server" Text="Clear"  class="btn btn-danger" OnClick="Submit_Click2" />
                            </div>
</div>                            
                        </div>

                    <asp:Panel runat="server" ID="regional_counts">

                             <div class="row">
                                            <div class="col-md-5 text-center">
                                                <div class="pad">
                                                    <!-- Map will be created here -->
                                                    <%-- <div class="chart" id="sales-chart" style="height: 300px; position: relative;"></div>
                   --%>
                                                    <div id="myChartDiv"></div>
                                                </div>
                                            </div>
                                 
                                           <div class="col-xs-4 bg-blue-active " style="margin-top: 10px;width:14%;margin-left:5px" >
                                                <div class="description-block border-right ">
                                                    <h5 class="description-header">TOTAL VISITS</h5>
                                                    <span class="description-text " runat="server" id="TOTALVISITS"></span>
                                                </div>
                                                <!-- /.description-block -->


                                            </div>
                                        
                                            <!-- /.col -->
                                            <div class="col-xs-4 bg-red-active" style="margin-top: 10px;margin-left:5px;width:9%" runat="server" id="Cen">
                                                <div class="description-block border-right ">

                                                    <h5 class="description-header">CENTRAL</h5>
                                                    <span class="description-text text-bold" runat="server" id="Central"></span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                            <!-- /.col -->

                                            <div class="col-xs-4 bg-yellow" style="margin-top: 10px;margin-left:5px;width:9%" runat="server" id="Nor">
                                                <div class="description-block border-right ">

                                                    <h5 class="description-header">NORTH</h5>
                                                    <span class="description-text text-bold" runat="server" id="North"></span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                            <!-- /.col -->
                                            <div class="col-xs-6 bg-green" style="margin-top: 10px;margin-left:5px;width:8%" runat="server" id="Sou">
                                                <div class="description-block border-right ">

                                                    <h5 class="description-header">SOUTH</h5>
                                                    <span class="description-text text-bold" runat="server" id="South"></span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                 <div class="col-xs-4 bg-blue"  style="margin-top: 10px;width:11%;margin-left:5px" runat="server" id="Bal">
                                                <div class="description-block border-right  ">

                                                    <h5 class="description-header" >BALUCHISTAN</h5>
                                                    <span class="description-text text-bold" runat="server" id="Baluchista"></span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>

                                 <div class="col-xs-4 bg-green"  style="margin-top: 30px;width:12%;margin-left:5px" runat="server" id="Div3">
                                                <div class="description-block border-right  ">

                                                    <h5 class="description-header" >Total Recovery</h5>
                                                    <span class="description-text text-bold" runat="server" id="Span1">123455</span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                 <div class="col-xs-4 bg-navy"  style="margin-top: 30px;width:13%;margin-left:5px" runat="server" id="Div4">
                                                <div class="description-block border-right  ">

                                                    <h5 class="description-header" >Total Sale</h5>
                                                    <span class="description-text text-bold" runat="server" id="Span2">123445</span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                 <%--<div class="col-xs-4 bg-green"  style="margin-top: 30px;width:13%;margin-left:5px" runat="server" id="Div5">
                                                <div class="description-block border-right  ">

                                                    <h5 class="description-header" > Exisiting Shops</h5>
                                                    <span class="description-text text-bold" runat="server" id="Span3">455</span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                 <div class="col-xs-4 bg-navy"  style="margin-top: 30px;width:13%;margin-left:5px" runat="server" id="Div6">
                                                <div class="description-block border-right  ">

                                                    <h5 class="description-header" >New Shops</h5>
                                                    <span class="description-text text-bold" runat="server" id="Span4">123</span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>--%>
                         <%--        <div class="col-sm-2 col-xs-4 bg-blue-active" style="margin-top: 10px" >
                                                <div class="description-block border-right ">
                                                    <h5 class="description-header">TOTAL VISITS</h5>
                                                    <span class="description-text " runat="server" id="Span1"></span>
                                                </div>
                                                <!-- /.description-block -->


                                            </div>
                                        <div class="col-sm-2 col-xs-2 bg-blue" style="margin-top: 10px" runat="server" id="Div3">
                                                <div class="description-block border-right  ">

                                                    <h5 class="description-header" >BALUCHISTAN</h5>
                                                    <span class="description-text text-bold" runat="server" id="Span2"></span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                            <!-- /.col -->
                                            <div class="col-sm-1 col-xs-4 bg-red-active" style="margin-top: 10px" runat="server" id="Div4">
                                                <div class="description-block border-right ">

                                                    <h5 class="description-header">CENTRAL</h5>
                                                    <span class="description-text text-bold" runat="server" id="Span3"></span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                            <!-- /.col -->

                                            <div class="col-sm-1 col-xs-4 bg-yellow-active" style="margin-top: 10px" runat="server" id="Div5">
                                                <div class="description-block border-right ">

                                                    <h5 class="description-header">NORTH</h5>
                                                    <span class="description-text text-bold" runat="server" id="Span4"></span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>
                                            <!-- /.col -->
                                            <div class="col-sm-1 col-xs-6 bg-green-active" style="margin-top: 10px" runat="server" id="Div6">
                                                <div class="description-block border-right ">

                                                    <h5 class="description-header">SOUTH</h5>
                                                    <span class="description-text text-bold" runat="server" id="Span5"></span>
                                                </div>
                                                <!-- /.description-block -->
                                            </div>--%>

                                            <!-- /.col -->

                                            <!-- /.col -->
                                 </div>
                                            <!-- /.col -->
                              </asp:Panel>
                                        <div class="row">

                        <asp:Panel runat="server" ID="Panel3">
                            <div class="col-md-6">
                                     
                                        <div id="myBarDiv" style="width: 500px; height: 250px;"></div>

                           
                            </div>
                            <!-- /.box -->
                             <div class="col-md-6">
                                <!-- MAP & BOX PANE -->
                           
                                        <div id="myBarDiv_least" style="width: 500px; height: 250px;"></div>

                            </div>
                             <!-- /.box -->
                            <%--<div class="col-md-6">
                                        <div id="myBarDiv2" style="width: 500px; height: 250px;"></div>
                           
                            </div>
                            <!-- /.row -->
                            <div class="col-md-6">
                                        <div id="myBarDiv_com" style="width: 500px; height: 250px;"></div>

                                
                            </div>--%>
                        </asp:Panel>
                        <!-- /.col -->
                    </div>

          </div>
            </div>
        </section>

    </section>

</asp:Content>
