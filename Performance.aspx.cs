using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training_Solution;

namespace Market_Visit_Portal
{
    public partial class Performance : System.Web.UI.Page
    {
        static string from, to, role, user,reg, subreg;
        static int totalvisits = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {


                    if (Session["user"] != null)
                    {
                        user = Session["user"].ToString();
                        user_name.InnerText = "MASGROUP\\" + user;
                        //Response.Write(user);
                        DataTable dt = new Procedures().GetUserIdentity(user);

                        if (dt.Rows.Count != 0)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                role = item["roleid"].ToString();
                                // NT = item["username"].ToString();
                            }
                            if (role.Equals("1") == true || role.Equals("2") == true)
                            {

                                DropDownList_Region.Items.Insert(0, new ListItem("ALL", "ALL"));
                                DropDownList_Region.Items.Insert(1, new ListItem("Baluchistan", "Baluchistan"));
                                DropDownList_Region.Items.Insert(2, new ListItem("Central", "Central"));
                                DropDownList_Region.Items.Insert(3, new ListItem("North", "North"));
                                DropDownList_Region.Items.Insert(4, new ListItem("South", "South"));

                                DropDownList_SubRegion.DataSource = new Procedures().SubRegion_R(user, "ALL");
                                DropDownList_SubRegion.DataTextField = "Handler";
                                DropDownList_SubRegion.DataValueField = "Handler";
                                DropDownList_SubRegion.DataBind();
                                DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));

                                DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));
                                DropDownList_TMO.Items.Insert(1, new ListItem("TSO", "TSO"));
                                DropDownList_TMO.Items.Insert(2, new ListItem("ASM", "ASM"));

                                /*DropDownList_TMO.DataSource = new Procedures().Team("All",user, "TSO");
                                DropDownList_TMO.DataTextField = "TSO";
                                DropDownList_TMO.DataValueField = "TSO";
                                DropDownList_TMO.DataBind();
                                DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));
*/
                                //DropDownList_SE.DataSource = new Procedures().Team("All",user, "SE");
                                //DropDownList_SE.DataTextField = "SE_Name";
                                //DropDownList_SE.DataValueField = "SE_Name";
                                //DropDownList_SE.DataBind();
                                //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));

                            }
                            else 
                            {
                                DropDownList_Region.DataSource = new Procedures().GetRegion_hierarchy(user);
                                DropDownList_Region.DataTextField = "region";
                                DropDownList_Region.DataValueField = "region";
                                DropDownList_Region.DataBind();
                                DropDownList_Region.Items.Insert(0, new ListItem("ALL", "ALL"));


                                DropDownList_SubRegion.DataSource = new Procedures().SubRegion_R(user, DropDownList_Region.SelectedValue);
                                DropDownList_SubRegion.DataValueField = "Handler";
                                DropDownList_SubRegion.DataTextField = "Handler";
                                DropDownList_SubRegion.DataBind();
                                DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));

                                DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));
                                DropDownList_TMO.Items.Insert(1, new ListItem("TSO", "TSO"));
                                DropDownList_TMO.Items.Insert(2, new ListItem("ASM", "ASM"));

                                /*DropDownList_TMO.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue,user, "TSO");
                                DropDownList_TMO.DataTextField = "TSO";
                                DropDownList_TMO.DataValueField = "TSO";
                                DropDownList_TMO.DataBind();
                                DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));
*/
                                //DropDownList_SE.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue,user, "SE");
                                //DropDownList_SE.DataTextField = "SE_Name";
                                //DropDownList_SE.DataValueField = "SE_Name";
                                //DropDownList_SE.DataBind();
                                //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));

                            }
                            

                        }
                        else
                        {

                            Response.Redirect("Login.aspx");
                        }
                        if (user.Equals("asim"))
                        {
                            this.Page.Master.FindControl("mainMenu").FindControl("test").Visible = true;
                        }
                        else
                        {
                            this.Page.Master.FindControl("mainMenu").FindControl("test").Visible = false;

                        }

                        Panel1.Visible = false;
                        Panel3.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                catch (Exception ex)
                {
                    ShowAlert(ex.Message);
                }

            }
        }

        protected void DropDownList_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_SubRegion.DataSource = new Procedures().SubRegion_R(user, DropDownList_Region.SelectedValue);
            DropDownList_SubRegion.DataTextField = "Handler";
            DropDownList_SubRegion.DataValueField = "Handler";
            DropDownList_SubRegion.DataBind();
            DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));

/*            DropDownList_TMO.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue,user, "TSO");
            DropDownList_TMO.DataTextField = "TSO";
            DropDownList_TMO.DataValueField = "TSO";
            DropDownList_TMO.DataBind();
            DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));
*/
            //DropDownList_SE.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue,user, "SE");
            //DropDownList_SE.DataTextField = "SE_Name";
            //DropDownList_SE.DataValueField = "SE_Name";
            //DropDownList_SE.DataBind();
            //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));

            UpdateGrid();
        }
        protected void DropDownList_SubRegion_SelectedIndexChanged(object sender, EventArgs e)
        {

           /* DropDownList_TMO.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "TSO");
            DropDownList_TMO.DataTextField = "TSO";
            DropDownList_TMO.DataValueField = "TSO";
            DropDownList_TMO.DataBind();
            DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));
*/
            //DropDownList_SE.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "SE");
            //DropDownList_SE.DataTextField = "SE_Name";
            //DropDownList_SE.DataValueField = "SE_Name";
            //DropDownList_SE.DataBind();
            //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));
            //UpdateGrid();
        }
        public void UpdateGrid()
        {
            //DataTable d = new Procedures().GetHierarchy_Visits(datepicker_from.Value, datepicker_to.Value, reg, user);
            //if (d.Rows.Count < 10)
            //{

            //}
            //GridView1.DataSource = d;
            //GridView1.DataBind();
            DataTable dtt = new Procedures().GetTop_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue, user);
            GridView_Visitors.DataSource = dtt;
            GridView_Visitors.DataBind();

            DataTable d = new Procedures().GetTopArea_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue, user);
            GridView_Visitors_City.DataSource = d;
            GridView_Visitors_City.DataBind();

            DataTable dt_area = new Procedures().GetLeastArea_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue, user);

            GridView_LeastAreas.DataSource = dt_area;
            GridView_LeastAreas.DataBind();

            //if (DropDownList_SubRegion.SelectedValue.Equals("ALL") & DropDownList_TMO.SelectedValue.Equals("ALL") & DropDownList_SE.SelectedValue.Equals("ALL"))
            //{
            //    //DataTable dt = new Procedures().GetTopVisitors(datepicker_from.Value, datepicker_to.Value, reg, user);

                
                
            //    DataTable dt_toparea = new Procedures().GetTopVisitors_BYArea(datepicker_from.Value, datepicker_to.Value, reg, user);

            //    GridView_Visitors_City.DataSource = dt_toparea;
            //    GridView_Visitors_City.DataBind();

            //    DataTable dt_area = new Procedures().GetLeastVisitors_BYArea(datepicker_from.Value, datepicker_to.Value, reg, user);

            //    GridView_LeastAreas.DataSource = dt_area;
            //    GridView_LeastAreas.DataBind();
            //}
            //else if (DropDownList_TMO.SelectedValue.Equals("ALL") & DropDownList_SE.SelectedValue.Equals("ALL"))
            //{
            //    DataTable dt = new Procedures().GetTopVisitors_SubRegion(datepicker_from.Value, datepicker_to.Value, subreg);

            //    GridView_Visitors.DataSource = dt;
            //    GridView_Visitors.DataBind();

            //    DataTable dt_toparea = new Procedures().GetTopVisitors_BYArea_Sub(datepicker_from.Value, datepicker_to.Value, subreg);

            //    GridView_Visitors_City.DataSource = dt_toparea;
            //    GridView_Visitors_City.DataBind();

            //    DataTable dt_area = new Procedures().GetLeastVisitors_BYArea_Sub(datepicker_from.Value, datepicker_to.Value, subreg);

            //    GridView_LeastAreas.DataSource = dt_area;
            //    GridView_LeastAreas.DataBind();
            //}
            //else
            //{
            //    if (DropDownList_TMO.SelectedValue.Equals("ALL"))
            //    {
            //        DataTable dt = new Procedures().GetTopVisitors_Team(datepicker_from.Value, datepicker_to.Value, DropDownList_SE.SelectedValue);

            //        GridView_Visitors.DataSource = dt;
            //        GridView_Visitors.DataBind();
            //    }
            //    else
            //    {
            //        DataTable dt = new Procedures().GetTopVisitors_Team(datepicker_from.Value, datepicker_to.Value, DropDownList_TMO.SelectedValue);

            //        GridView_Visitors.DataSource = dt;
            //        GridView_Visitors.DataBind();
            //    }
            //}

            //DataLoad();

        }
        
        protected void GridView_Visitors_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Details")
            {
                GridViewRow row = GridView_Visitors.Rows[index];
                if (!row.Cells[0].Text.Equals("0"))
                {
                    string se = row.Cells[0].Text;
                    Projects_Grid.DataSource = new Procedures().GetAll_Visits(datepicker_from.Value, datepicker_to.Value, se, "iqra.iqbal");
                    Projects_Grid.DataBind();
                    DataTable dt = new Procedures().GetAll_VisitsCounts(datepicker_from.Value, datepicker_to.Value, se, "iqra.iqbal");

                    Panel1.Visible = true;
                    Panel1.Focus();
                    New_shop.InnerText = "0";
                    Existing_Shops.InnerText = "0";
                    Recovery.InnerText = "0";
                    SalesVolume.InnerText = "0";
                    foreach (DataRow item in dt.Rows)
                    {
                        New_shop.InnerText = item["New"].ToString();
                        Existing_Shops.InnerText = item["Existing"].ToString();
                        Recovery.InnerText = item["Recovery"].ToString();
                        SalesVolume.InnerText = item["SalesVolume"].ToString();

                    }
                }

            }
        }
        protected void GridView_TopAreas_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Details")
            {
                GridViewRow row = GridView_Visitors_City.Rows[index];
                if (!row.Cells[0].Text.Equals("0"))
                {
                    string area = row.Cells[0].Text;
                    Projects_Grid.DataSource = new Procedures().GetAll_Visits_Area(datepicker_from.Value, datepicker_to.Value, area,"ASC", "iqra.iqbal");
                    Projects_Grid.DataBind();
                    DataTable dt = new Procedures().GetAll_VisitsCounts_Area(datepicker_from.Value, datepicker_to.Value, area, "iqra.iqbal");

                    Panel1.Visible = true;
                    Panel1.Focus();
                    New_shop.InnerText = "0";
                    Existing_Shops.InnerText = "0";
                    Recovery.InnerText = "0";
                    SalesVolume.InnerText = "0";
                    foreach (DataRow item in dt.Rows)
                    {
                        New_shop.InnerText = item["New"].ToString();
                        Existing_Shops.InnerText = item["Existing"].ToString();
                        Recovery.InnerText = item["Recovery"].ToString();
                        SalesVolume.InnerText = item["SalesVolume"].ToString();

                    }
                }

            }
        }
        protected void GridView_LeastAreas_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Details")
            {
                GridViewRow row = GridView_LeastAreas.Rows[index];
                if (!row.Cells[0].Text.Equals("0"))
                {
                    string area = row.Cells[0].Text;
                    Projects_Grid.DataSource = new Procedures().GetAll_Visits_Area(datepicker_from.Value, datepicker_to.Value, area, "ASC", "iqra.iqbal");
                    Projects_Grid.DataBind();
                    DataTable dt = new Procedures().GetAll_VisitsCounts_Area(datepicker_from.Value, datepicker_to.Value, area, "iqra.iqbal");

                    Panel1.Visible = true;
                    Panel1.Focus();
                    New_shop.InnerText = "0";
                    Existing_Shops.InnerText = "0";
                    Recovery.InnerText = "0";
                    SalesVolume.InnerText = "0";
                    foreach (DataRow item in dt.Rows)
                    {
                        New_shop.InnerText = item["New"].ToString();
                        Existing_Shops.InnerText = item["Existing"].ToString();
                        Recovery.InnerText = item["Recovery"].ToString();
                        SalesVolume.InnerText = item["SalesVolume"].ToString();

                    }
                }

            }
        }
        

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string count = e.Row.Cells[8].Text;
                    if (count.Equals("0"))
                    {
                        Button btnEdit = (Button)e.Row.FindControl("btndetails");

                        btnEdit.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (Label)e.Row.FindControl("lblTxnID");
                    string status = lbl.Text;
                    if (status.Equals("0.0,0.0"))
                    {
                        HyperLink HyperLink1 = (HyperLink)e.Row.FindControl("HyperLink1");
                        HyperLink1.Text = "No location";
                    }
                    else
                    {
                        HyperLink HyperLink1 = (HyperLink)e.Row.FindControl("HyperLink1");
                        HyperLink1.NavigateUrl = "https://www.google.com/maps/search/" + status;
                        HyperLink1.Target = "_blank";
                    }


                }
            }
            catch (Exception ex)
            {
                //   ShowAlert(ex.Message);
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Session["user"] = null;
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }
        protected void Submit_Click2(object sender, EventArgs e)
        {
            try
            {
                Panel1.Visible = false;
                Panel3.Visible = false;
                from = "datepicker_from";
                if (datepicker_from.Value.Equals(""))
                {
                    ShowAlert("Kindly Select FROM Date !");
                }
                else if (datepicker_to.Value.Equals(""))
                {
                    ShowAlert("Kindly Select TO Date !");
                }
                else
                {

                    Panel3.Visible = true;
                    from = datepicker_from.Value;
                    to = datepicker_to.Value;
                    if (role != null)
                    {
                        reg = DropDownList_Region.SelectedValue.ToString();
                        subreg = DropDownList_SubRegion.SelectedValue.ToString();

                        //     regional_counts.Visible = true;
                        //   UpdateCounts();
                        UpdateGrid();
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");

                    }
                }

            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }

        }
        protected void ShowAlert(string msg)
        {
            string alertmessage = "alert('" + msg + "')";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", alertmessage, true);  // "alert('Complaint has been registered successfully.')"
        }
    }
}