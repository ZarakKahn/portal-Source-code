using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Training_Solution
{

    public partial class Dashboard : System.Web.UI.Page
    {
        static string from, to, region = "", subreg = "", role = "", user = "",team="";
        static int totalvisits = 0, totalrecovery = 0, totalsale = 0, exis_shop = 0, new_shop = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try {


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


                                DropDownList_SubRegion.DataSource = new Procedures().SubRegion_R(user,"ALL");
                                DropDownList_SubRegion.DataValueField = "Handler";
                                DropDownList_SubRegion.DataTextField = "Handler";
                                DropDownList_SubRegion.DataBind();
                                DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));

                                DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));
                                DropDownList_TMO.Items.Insert(1, new ListItem("TSO", "TSO"));
                                DropDownList_TMO.Items.Insert(2, new ListItem("ASM", "ASM"));

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

                                Bal.Style.Add("background-color", "#FF00FF");
                                Bal.Style.Add("background-color", "#FF00FF");
                                Bal.Style.Add("background-color", "#FF00FF");
                                Bal.Style.Add("background-color", "#FF00FF");

                            }
                           

                        }
                        else
                        {
                                                                                      
                            Response.Redirect("Login.aspx");
                        }
                        if (user.Equals("asim")) { 
                        this.Page.Master.FindControl("mainMenu").FindControl("test").Visible = true;
                        }
                        else
                        {
                            this.Page.Master.FindControl("mainMenu").FindControl("test").Visible = false;

                        }
                        regional_counts.Visible = false;

                        Panel3.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                } catch (Exception ex)
                {
                    ShowAlert(ex.Message);
                }

            }
        }

        [WebMethod()]
        public static List<employeeDetails> GetChartData()
        {
            List<employeeDetails> dataList; dataList = new List<employeeDetails>();

            try
            {
                DataTable dt = new DataTable();
                dt = new Procedures().GetRegional_Counts(from, to, region, subreg, user,team);

                foreach (DataRow dtrow in dt.Rows)
                {
                    employeeDetails details = new employeeDetails();
                    details.EmployeeCity = dtrow[0].ToString(); 
                    details.Total = Convert.ToInt32(dtrow[1]);
                    dataList.Add(details);
                }

            } catch (Exception ex)
            {

            }
            return dataList;
        }
        [WebMethod()]
        public static List<employeeDetails> GetBarData()
        {
            List<employeeDetails> dataList; dataList = new List<employeeDetails>();

            try
            {
                DataTable dt = new DataTable();

                dt = new Procedures().GetTop_Visits(from, to, region, subreg, team, user);
                foreach (DataRow dtrow in dt.Rows)
                {
                    employeeDetails details = new employeeDetails();
                    details.EmployeeCity = dtrow[0].ToString();
                    details.Total = Convert.ToInt32(dtrow[1]);
                    dataList.Add(details);

                }
            }
            catch (Exception ex)
            {

            }
            return dataList;
        }
        [WebMethod()]
        public static List<employeeDetails> GetData_Least()
        {
            List<employeeDetails> dataList; dataList = new List<employeeDetails>();

            try
            {
                DataTable dt = new DataTable();
                dt = new Procedures().GetLeast_Visits(from, to, region, subreg, team, user);
                foreach (DataRow dtrow in dt.Rows)
                {
                    employeeDetails details = new employeeDetails();
                    details.EmployeeCity = dtrow[0].ToString();
                    details.Total = Convert.ToInt32(dtrow[1]);
                    dataList.Add(details);

                }
            }
            catch (Exception ex)
            {

            }
            return dataList;
        }
        [WebMethod()]
        public static List<employeeDetails> GetBarData_City()
        {
            List<employeeDetails> dataList; dataList = new List<employeeDetails>();

            try
            {
                DataTable dt = new DataTable();
                dt = new Procedures().GetTopArea_Visits(from, to, region, subreg, "ALL", user);
                foreach (DataRow dtrow in dt.Rows)
                {
                    employeeDetails details = new employeeDetails();
                    details.EmployeeCity = dtrow[1].ToString();
                    details.Total = Convert.ToInt32(dtrow[2]);
                    dataList.Add(details);

                }

            }
            catch (Exception ex)
            {
            }
            return dataList;
        }
        [WebMethod()]
        public static List<employeeDetails> Get_Complaints()
        {
            List<employeeDetails> dataList; dataList = new List<employeeDetails>();

            try
            {
                DataTable dt = new DataTable();

                dt = new Procedures().Get_Complaints(from, to, region, subreg, "ALL", user);
                foreach (DataRow dtrow in dt.Rows)
                {
                    employeeDetails details = new employeeDetails();
                    details.EmployeeCity = dtrow[0].ToString();
                    details.Total = Convert.ToInt32(dtrow[1]);
                    dataList.Add(details);

                }

            }
            catch (Exception ex)
            {
            }
            return dataList;
        }
        public class employeeDetails
        {
            public string EmployeeCity { get; set; }
            public int Total { get; set; }
        }
        protected void DropDownList_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            region = DropDownList_Region.SelectedValue;
            regional_counts.Visible = false;
            
            Panel3.Visible = false;
            DropDownList_SubRegion.DataSource = new Procedures().SubRegion_R(user,DropDownList_Region.SelectedValue);
            DropDownList_SubRegion.DataTextField = "Handler";
            DropDownList_SubRegion.DataValueField = "Handler";
            DropDownList_SubRegion.DataBind();
            DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));


        }
        protected void DropDownList_SubRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            subreg = DropDownList_SubRegion.SelectedValue;
            regional_counts.Visible = false;
            Panel3.Visible = false;

            //DropDownList_TMO.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "TMO");
            //DropDownList_TMO.DataTextField = "TMO";
            //DropDownList_TMO.DataValueField = "TMO";
            //DropDownList_TMO.DataBind();
            //DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));

            //DropDownList_SE.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "SE");
            //DropDownList_SE.DataTextField = "SE_Name";
            //DropDownList_SE.DataValueField = "SE_Name";
            //DropDownList_SE.DataBind();
            //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));

        }
        public void UpdateCounts()
        {
            Baluchista.InnerText = "0";
            Central.InnerText = "0";
            North.InnerText = "0";
            South.InnerText = "0";
            totalvisits = 0;
            totalrecovery = 0;
            totalsale = 0;
            new_shop = 0;
            exis_shop = 0;
            DataTable dt = new DataTable();
            dt = new Procedures().GetRegional_Counts(from, to, region, subreg, user,team);

            foreach (DataRow item in dt.Rows)
            {
                try
                {

                if (item[0].ToString() == "Baluchistan")
                {
                    Baluchista.InnerText = item[1].ToString();
                }
                if (item[0].ToString() == "Central")
                {
                    Central.InnerText = item[1].ToString();
                }
                if (item[0].ToString() == "North")
                {
                    North.InnerText = item[1].ToString();
                }
                if (item[0].ToString() == "South")
                {
                    South.InnerText = item[1].ToString();
                }

                totalvisits = totalvisits + Convert.ToInt32(item[1].ToString());
                totalrecovery = totalrecovery + Convert.ToInt32(item[2].ToString());
                totalsale = totalsale + Convert.ToInt32(item[3].ToString());
                exis_shop = exis_shop + Convert.ToInt32(item[4].ToString());
                new_shop = new_shop + Convert.ToInt32(item[5].ToString());

                }
                catch (Exception e)
                {

                }
            }

            TOTALVISITS.InnerText = totalvisits.ToString();
            recovery.InnerText = totalrecovery.ToString();
            sales.InnerText = totalsale.ToString();
            exis_shops.InnerText = exis_shop.ToString();
            new_shops.InnerText = new_shop.ToString();

            if ((role.Equals("1") == true || role.Equals("2") == true) && region.Equals("ALL")==true && subreg.Equals("ALL") == true)
            {
                Bal.Attributes["class"] = "col-xs-6 bg-blue";
               
                Nor.Attributes["class"] = "col-xs-6 bg-yellow";
                
                Sou.Attributes["class"] = "col-xs-6 bg-green";
               

                Cen.Attributes["class"] = "col-xs-6 bg-red";
                
            }
            else
            {
                Bal.Attributes["class"] = "col-xs-6";
                Bal.Style.Add("background-color", "#FFFFFF");
                Bal.Style.Add("color", "#FFFFFF");

                Nor.Attributes["class"] = "col-xs-6";
                Nor.Style.Add("background-color", "#FFFFFF");
                Nor.Style.Add("color", "#FFFFFF");

                Sou.Attributes["class"] = "col-xs-6";
                Sou.Style.Add("background-color", "#FFFFFF");
                Sou.Style.Add("color", "#FFFFFF");

                Cen.Attributes["class"] = "col-xs-6";
                Cen.Style.Add("background-color", "#FFFFFF");
                Cen.Style.Add("color", "#FFFFFF");


            }
        }
        
        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string count = e.Row.Cells[8].Text;
                    if(count.Equals("0"))
                    {
                        Button btnEdit = (Button)e.Row.FindControl("btndetails");

                        btnEdit.Visible = false;
                    }
                }
                } catch(Exception ex)
            {

            }
       }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (Label)e.Row.FindControl("lblTxnID");
                    string status = lbl.Text;
                    if(status.Equals("0.0,0.0"))
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
            catch(Exception ex)
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
              
                Panel3.Visible = false;
                
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
                        //if (role.Equals("1") == true || role.Equals("2") == true || role.Equals("3") == true || role.Equals("4") == true || role.Equals("5") == true)
                            region = DropDownList_Region.SelectedValue.ToString();
                        //else 
                          //  region = "";
                        subreg = DropDownList_SubRegion.SelectedValue.ToString();
                        team = DropDownList_TMO.SelectedValue.ToString();

                        regional_counts.Visible = true;
                        Panel3.Visible = true;
                        UpdateCounts();
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
    }
}