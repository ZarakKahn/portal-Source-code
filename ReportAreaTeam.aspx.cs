using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training_Solution;

namespace Market_Visit_Portal
{
    public partial class ReportAreaTeam : System.Web.UI.Page
    {
        static string from, to, role, user, reg, subreg;
        static int totalvisits = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
//                    Panel1.Visible = false;

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

                                DropDownList_TMO.DataSource = new Procedures().Team("All", user, "TSO");
                                DropDownList_TMO.DataTextField = "TSO";
                                DropDownList_TMO.DataValueField = "TSO";
                                DropDownList_TMO.DataBind();
                                DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));

                                //DropDownList_SE.DataSource = new Procedures().Team("All", user, "SE");
                                //DropDownList_SE.DataTextField = "SE_Name";
                                //DropDownList_SE.DataValueField = "SE_Name";
                                //DropDownList_SE.DataBind();
                                //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));

                                DropDownList_Area.DataSource = new Procedures().Areas("ALL", "ALL", user);
                                DropDownList_Area.DataTextField = "city";
                                DropDownList_Area.DataValueField = "city";
                                DropDownList_Area.DataBind();
                                DropDownList_Area.Items.Insert(0, new ListItem("ALL", "ALL"));

                                DropDownList_Retailor.DataSource = new Procedures().Retailors("ALL", "ALL", user);
                                DropDownList_Retailor.DataTextField = "custname";
                                DropDownList_Retailor.DataValueField = "custname";
                                DropDownList_Retailor.DataBind();
                                DropDownList_Retailor.Items.Insert(0, new ListItem("ALL", "ALL"));

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

                                DropDownList_TMO.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue, user, "TSO");
                                DropDownList_TMO.DataTextField = "TSO";
                                DropDownList_TMO.DataValueField = "TSO";
                                DropDownList_TMO.DataBind();
                                DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));

                                //DropDownList_SE.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue, user, "SE");
                                //DropDownList_SE.DataTextField = "SE_Name";
                                //DropDownList_SE.DataValueField = "SE_Name";
                                //DropDownList_SE.DataBind();
                                //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));


                                DropDownList_Area.DataSource = new Procedures().Areas(DropDownList_Region.SelectedValue, "ALL", user);
                                DropDownList_Area.DataTextField = "city";
                                DropDownList_Area.DataValueField = "city";
                                DropDownList_Area.DataBind();
                                DropDownList_Area.Items.Insert(0, new ListItem("ALL", "ALL"));

                                DropDownList_Retailor.DataSource = new Procedures().Retailors(DropDownList_Region.SelectedValue, "ALL", user);
                                DropDownList_Retailor.DataTextField = "custname";
                                DropDownList_Retailor.DataValueField = "custname";
                                DropDownList_Retailor.DataBind();
                                DropDownList_Retailor.Items.Insert(0, new ListItem("ALL", "ALL"));

                            }
                            
                            Div1.Visible = false;
                            Div2.Visible = false;
                            Div3.Visible = false;
                            Div4.Visible = false;

                            regional_counts.Visible = false;
                            area_counts.Visible = false;

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
            DropDownList_SubRegion.DataValueField = "Handler";
            DropDownList_SubRegion.DataTextField = "Handler";
            DropDownList_SubRegion.DataBind();
            DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));


            DropDownList_TMO.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue, user, "TSO");
            DropDownList_TMO.DataTextField = "TSO";
            DropDownList_TMO.DataValueField = "TSO";
            DropDownList_TMO.DataBind();
            DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));

            //DropDownList_SE.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue, user, "SE");
            //DropDownList_SE.DataTextField = "SE_Name";
            //DropDownList_SE.DataValueField = "SE_Name";
            //DropDownList_SE.DataBind();
            //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));
           

            DropDownList_Area.DataSource = new Procedures().Areas(DropDownList_Region.SelectedValue, "ALL", user);
            DropDownList_Area.DataTextField = "city";
            DropDownList_Area.DataValueField = "city";
            DropDownList_Area.DataBind();
            DropDownList_Area.Items.Insert(0, new ListItem("ALL", "ALL"));

            DropDownList_Retailor.DataSource = new Procedures().Retailors(DropDownList_Region.SelectedValue, "ALL", user);
            DropDownList_Retailor.DataTextField = "custname";
            DropDownList_Retailor.DataValueField = "custname";
            DropDownList_Retailor.DataBind();
            DropDownList_Retailor.Items.Insert(0, new ListItem("ALL", "ALL"));

            UpdateGrid();

        }
        protected void DropDownList_SubRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_TMO.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "TSO");
            DropDownList_TMO.DataTextField = "TSO";
            DropDownList_TMO.DataValueField = "TSO";
            DropDownList_TMO.DataBind();
            DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));

            //DropDownList_SE.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "SE");
            //DropDownList_SE.DataTextField = "SE_Name";
            //DropDownList_SE.DataValueField = "SE_Name";
            //DropDownList_SE.DataBind();
            //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));
            
            DropDownList_Area.DataSource = new Procedures().Areas("", DropDownList_SubRegion.SelectedValue, user);
            DropDownList_Area.DataTextField = "city";
            DropDownList_Area.DataValueField = "city";
            DropDownList_Area.DataBind();
            DropDownList_Area.Items.Insert(0, new ListItem("ALL", "ALL"));

            DropDownList_Retailor.DataSource = new Procedures().Retailors("", DropDownList_SubRegion.SelectedValue, user);
            DropDownList_Retailor.DataTextField = "custname";
            DropDownList_Retailor.DataValueField = "custname";
            DropDownList_Retailor.DataBind();
            DropDownList_Retailor.Items.Insert(0, new ListItem("ALL", "ALL"));

            UpdateGrid();
        }
        protected void DropDownList_TMO_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        protected void DropDownList_SE_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        protected void DropDownList_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        protected void DropDownList_Retailor_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        protected void Submit_Click2(object sender, EventArgs e)
        {
            try
            {
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


                    from = datepicker_from.Value;
                    to = datepicker_to.Value;
                    if (role != null)
                    {
                        //if (role.Equals("1") == true || role.Equals("2") == true || role.Equals("3") == true)
                        //    reg = DropDownList_Region.SelectedValue.ToString();
                        //else
                        //    reg = DropDownList_SubRegion.SelectedValue.ToString();
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

        private void UpdateGrid()
        {
            if (Area.Checked == true)
            {
                GridView_area.Visible = true;
                GridView3.Visible = false;
                DataTable d = new Procedures().GetArea_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_Area.SelectedValue, user);

                GridView_area.DataSource = d;
                GridView_area.DataBind();
                area_counts.Visible = true;
                title.InnerText = "AREA VISITS DETAILS";
                //if (DropDownList_SubRegion.SelectedValue.Equals("ALL") && DropDownList_Area.SelectedValue.Equals("ALL"))
               
            }
            if (Team.Checked == true)
            {
                GridView_area.Visible = false;
                GridView3.Visible = true;
                DataTable d = new Procedures().GetTeam_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue,"ALL", user);
                title.InnerText = "TEAM VISITS DETAILS";
                GridView3.DataSource = d;
                GridView3.DataBind();
                area_counts.Visible = true;
            }
            if(Summary.Checked==true)
            {
                DataTable regionl = new Procedures().GetArea_RegionalVisits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_Area.SelectedValue, user);

                GridView2.DataSource = regionl;
                GridView2.DataBind();

                regional_counts.Visible = true;
            }

        }

        protected void GridView2_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string count = e.Row.Cells[1].Text;
                    if (count.Contains("Total") || count.Contains("Grand Total"))
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#becadf");
                        e.Row.ForeColor = System.Drawing.Color.FromName("#21488F");
                        e.Row.Style["font-weight"] = "bold";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView3_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string count = e.Row.Cells[1].Text;
                    if (count.Contains("Total") || count.Contains("Grand Total"))
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#becadf");
                        e.Row.ForeColor = System.Drawing.Color.FromName("#21488F");
                        e.Row.Style["font-weight"] = "bold";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void GridViewArea_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string count = e.Row.Cells[1].Text;
                    if (count.Contains("TOTAL"))
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#becadf");
                        e.Row.ForeColor = System.Drawing.Color.FromName("#21488F");
                        e.Row.Style["font-weight"] = "bold";
                    }
                }
            }
            catch (Exception ex)
            {

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
        protected void Area_CheckedChanged(Object sender, EventArgs args)
        {
            Team.Checked = false;
            Retailor.Checked = false;
            Summary.Checked = false;

            Div1.Visible = false;
            Div2.Visible = false;
            Div3.Visible = true;
            Div4.Visible = false;

            GridView_area.Visible = false;
           regional_counts.Visible = false;
            area_counts.Visible = false;
            //CheckBox linkedItem = sender as CheckBox;

        }
        protected void Team_CheckedChanged(Object sender, EventArgs args)
        {
                Area.Checked = false;
                Retailor.Checked = false;
                Summary.Checked = false;
            Div3.Visible = false;
            Div1.Visible = true;
            Div2.Visible = true;
            Div4.Visible = false;
            GridView_area.Visible = false;
            regional_counts.Visible = false;
            area_counts.Visible = false;
            //CheckBox linkedItem = sender as CheckBox;

        }
        protected void Retailor_CheckedChanged(Object sender, EventArgs args)
        {
            Area.Checked = false;
            Team.Checked = false;
            Summary.Checked = false;

            Div4.Visible = true;
            Div3.Visible = false;
            Div1.Visible = false;
            Div2.Visible = false;

            GridView_area.Visible = false;
            regional_counts.Visible = false;
            area_counts.Visible = false;
            //CheckBox linkedItem = sender as CheckBox;

        }
        protected void Summary_CheckedChanged(Object sender, EventArgs args)
        {
            Area.Checked = false;
            Retailor.Checked = false;
            Team.Checked = false;

            Div4.Visible = false;
            Div3.Visible = false;
            Div1.Visible = false;
            Div2.Visible = false;

            GridView_area.Visible = false;
            regional_counts.Visible = false;
            area_counts.Visible = false;
            //CheckBox linkedItem = sender as CheckBox;

        }
        
        protected void ShowAlert(string msg)
        {
            string alertmessage = "alert('" + msg + "')";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", alertmessage, true);  // "alert('Complaint has been registered successfully.')"
        }
    }
}