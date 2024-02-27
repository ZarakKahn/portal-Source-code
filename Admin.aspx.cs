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
    public partial class Admin : System.Web.UI.Page
    {
        static string from, search_user, region, role, user;
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
                                DropDownList_Region.Items.Insert(3, new ListItem("South", "South"));

                            }
                            else if (role.Equals("3") == true)
                            {
                                DropDownList_Region.DataSource = new Procedures().Region(user);
                                DropDownList_Region.DataTextField = "region";
                                DropDownList_Region.DataValueField = "region";
                                DropDownList_Region.DataBind();


                            }
                            else if (role.Equals("4") == true || role.Equals("5") == true)
                            {
                                //ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                                //myContent.FindControl("region").Visible = false;
                                //myContent.FindControl("region_counts").Visible = false; //this is not working 
                                //myContent.FindControl("subregion").Visible = true; //this is not working 
                                DropDownList_Region.DataSource = new Procedures().Region(user);
                                DropDownList_Region.DataTextField = "region";
                                DropDownList_Region.DataValueField = "region";
                                DropDownList_Region.DataBind();
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
        protected void Search_User(object sender, EventArgs e)
        {
            try
            {
                region = DropDownList_Region.SelectedValue.ToString();
                search_user = Trainer_Search.SelectedValue.ToString();
                if (search_user.Equals("SE"))
                {
                    SE_Grid.Visible = true;
                    TMO_Grid.Visible = false;
                    
                }
                else
                {
                    SE_Grid.Visible = false;
                    TMO_Grid.Visible = true;
                }
                UpdateGrid();
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }

        }
        protected void SE_Grid_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditC")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Popup", "ShowPopup()", true);
            }
        }
        protected void TMO_Grid_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        public void UpdateGrid()
        {
            try {
                DataTable d = new Procedures().GetUserHirarchy(region, search_user, user);
                if (search_user.Equals("SE"))
                {
                    SE_Grid.DataSource = d;
                    SE_Grid.DataBind();

                }
                else
                {
                    TMO_Grid.DataSource = d;
                    TMO_Grid.DataBind();

                }
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
            //DataLoad();

        }
        protected void ShowAlert(string msg)
        {
            string alertmessage = "alert('" + msg + "')";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", alertmessage, true);  // "alert('Complaint has been registered successfully.')"
        }
    }
}