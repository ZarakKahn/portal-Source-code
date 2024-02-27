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
    public partial class AreaMapping : System.Web.UI.Page
    {
        static string from, to, regions = "", subreg = "", role = "", user = "";

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


                                DropDownList_SubRegion.DataSource = new Procedures().SubRegion("All");
                                DropDownList_SubRegion.DataTextField = "SubRegion";
                                DropDownList_SubRegion.DataValueField = "SubRegion";
                                DropDownList_SubRegion.DataBind();
                                DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));



                            }
                            else if (role.Equals("3") == true)
                            {
                                DropDownList_Region.DataSource = new Procedures().Region(user);
                                DropDownList_Region.DataTextField = "region";
                                DropDownList_Region.DataValueField = "region";
                                DropDownList_Region.DataBind();

                                DropDownList_SubRegion.DataSource = new Procedures().SubRegion(DropDownList_Region.SelectedValue);
                                DropDownList_SubRegion.DataTextField = "SubRegion";
                                DropDownList_SubRegion.DataValueField = "SubRegion";
                                DropDownList_SubRegion.DataBind();
                                DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));
                            }
                            else if (role.Equals("4") == true || role.Equals("5") == true)
                            {
                                ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                                myContent.FindControl("region").Visible = false;
                                myContent.FindControl("subregion").Visible = true;

                                //this is not working 
                                DropDownList_SubRegion.DataSource = new Procedures().Region(user);
                                DropDownList_SubRegion.DataTextField = "region";
                                DropDownList_SubRegion.DataValueField = "region";
                                DropDownList_SubRegion.DataBind();
                                DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));
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
            regions = DropDownList_Region.SelectedValue;
            DropDownList_SubRegion.DataSource = new Procedures().SubRegion(DropDownList_Region.SelectedValue);
            DropDownList_SubRegion.DataTextField = "SubRegion";
            DropDownList_SubRegion.DataValueField = "SubRegion";
            DropDownList_SubRegion.DataBind();
            DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));


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

                    //     Panel3.Visible = true;
                    from = datepicker_from.Value;
                    to = datepicker_to.Value;
                    if (role != null)
                    {
                        if (role.Equals("1") == true || role.Equals("2") == true || role.Equals("3") == true)
                            regions = DropDownList_Region.SelectedValue.ToString();

                        subreg = DropDownList_SubRegion.SelectedValue.ToString();

                      //  Response.Redirect("~/mAP.aspx?to=" + to + "&from=" + from + "&region=" + regions + "&user=" + user);
                        Response.Write("<script>window.open ('mAP.aspx?to=" + to + "&from=" + from + "&region=" + regions + "&subregion=" + subreg + "&user=" + user + "','_blank');</script>");

                        // UpdateGrid();
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

        public string ConvertDataTabletoString()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=192.168.0.12;Initial Catalog=PowerBI;User Id=powerbi;Password=powerbi"))
            {
                using (SqlCommand cmd = new SqlCommand("select top 100 title=Cust_Name,lat=latitude,lng=longitude,description=Distributor from VisitDetails order by V_ID desc", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
            }
        }
    }
}
