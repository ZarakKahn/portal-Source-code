<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="Market_Visit_Portal.AreaMapping" %>
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
                    <h3 style="margin-top: 30px; color: darkred">LOCATIONS ON MAP</h3>


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
                                    <asp:DropDownList runat="server" class="form-control" ID="DropDownList_SubRegion" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            <div class="text-right" style="font-size: 12px; margin-top: 15px; margin-right: 50px">

                                <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-facebook" OnClick="Submit_Click2" />
                            </div>
</div>                            
                        </div>
                    </div>
                </div>
            </section>
        </section>

     </asp:Content>
