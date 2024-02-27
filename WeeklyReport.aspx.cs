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
    public partial class WeeklyReport : System.Web.UI.Page
    {
        static string from, to, role, user, reg, subreg;

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

                                DropDownList_Region.Items.Insert(0, new ListItem("Central", "Central"));
                                DropDownList_Region.Items.Insert(1, new ListItem("North", "North"));
                                DropDownList_Region.Items.Insert(2, new ListItem("South & Baluchistan", "South"));

                                DropDownList_SubRegion.Items.Insert(0, new ListItem("January", "1"));
                                DropDownList_SubRegion.Items.Insert(1, new ListItem("February", "2"));
                                DropDownList_SubRegion.Items.Insert(2, new ListItem("March", "3"));
                                DropDownList_SubRegion.Items.Insert(3, new ListItem("April", "4"));
                                DropDownList_SubRegion.Items.Insert(4, new ListItem("May", "5"));
                                DropDownList_SubRegion.Items.Insert(5, new ListItem("June", "6"));
                                DropDownList_SubRegion.Items.Insert(6, new ListItem("July", "7"));
                                DropDownList_SubRegion.Items.Insert(7, new ListItem("August", "8"));
                                DropDownList_SubRegion.Items.Insert(8, new ListItem("September", "9"));
                                DropDownList_SubRegion.Items.Insert(9, new ListItem("October", "10"));
                                DropDownList_SubRegion.Items.Insert(10, new ListItem("November", "11"));
                                DropDownList_SubRegion.Items.Insert(11, new ListItem("December", "12"));

                            }
                        }
                        else
                        {

                            Response.Redirect("Login.aspx");
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
        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string count = e.Row.Cells[0].Text;
                    if (count.Contains("Sub Total") || count.Contains("Grand Total"))
                    {
                        //e.Row.BackColor = System.Drawing.Color.FromName("#21488F");
                        //e.Row.ForeColor = System.Drawing.Color.White;
                        //e.Row.Style["font-weight"] = "bold";
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
        protected void Submit_Click2(object sender, EventArgs e)
        {
            try
            {
                DataTable d = new Procedures().GetWeekly_Visits(DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue);
                if (d.Rows.Count < 10)
                {

                }
                GridView1.DataSource = d;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
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
        protected void DropDownList_Region_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ShowAlert(string msg)
        {
            string alertmessage = "alert('" + msg + "')";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", alertmessage, true);  // "alert('Complaint has been registered successfully.')"
        }
    }
}