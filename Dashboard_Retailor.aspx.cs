using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training_Solution;

namespace Market_Visit_Portal
{
    public partial class Dashboard_Retailor : System.Web.UI.Page
    {
        static string from, to, regio = "", subreg = "", role = "", user = "";
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

                                //regional_counts.Visible = false;

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

                        regional_counts.Visible = false;

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
        [WebMethod()]
        public static List<employeeDetails> GetChartData()
        {
            List<employeeDetails> dataList; dataList = new List<employeeDetails>();

            try
            {
                DataTable dt = new DataTable();
                //dt = new Procedures().GetRegional_Counts(from, to, regio, subreg, user);

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
        public static List<employeeDetails> GetTop_RetailorVisits()
        {
            List<employeeDetails> dataList; dataList = new List<employeeDetails>();

            try
            {
                DataTable dt = new DataTable();

                dt = new Procedures().GetTop_RetailorVisits(from, to, regio, subreg, "ALL", "ALL", user);
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
                dt = new Procedures().GetLeast_Retailor(from, to, regio, subreg, "ALL", "ALL", user);
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
        //[WebMethod()]
        //public static List<employeeDetails> GetBarData_City()
        //{
        //    List<employeeDetails> dataList; dataList = new List<employeeDetails>();

        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = new Procedures().GetTopArea_Visits(from, to, regio, subreg, "ALL", "ALL", user);
        //        foreach (DataRow dtrow in dt.Rows)
        //        {
        //            employeeDetails details = new employeeDetails();
        //            details.EmployeeCity = dtrow[1].ToString();
        //            details.Total = Convert.ToInt32(dtrow[2]);
        //            dataList.Add(details);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return dataList;
        //}
        //[WebMethod()]
        //public static List<employeeDetails> Get_Complaints()
        //{
        //    List<employeeDetails> dataList; dataList = new List<employeeDetails>();

        //    try
        //    {
        //        DataTable dt = new DataTable();

        //        dt = new Procedures().Get_Complaints(from, to, regio, subreg, "ALL", "ALL", user);
        //        foreach (DataRow dtrow in dt.Rows)
        //        {
        //            employeeDetails details = new employeeDetails();
        //            details.EmployeeCity = dtrow[0].ToString();
        //            details.Total = Convert.ToInt32(dtrow[1]);
        //            dataList.Add(details);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return dataList;
        //}
        public class employeeDetails
        {
            public string EmployeeCity { get; set; }
            public int Total { get; set; }
        }
        protected void DropDownList_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            //region = DropDownList_Region.SelectedValue;
            //regional_counts.Visible = false;

            //Panel3.Visible = false;
            //DropDownList_SubRegion.DataSource = new Procedures().SubRegion(DropDownList_Region.SelectedValue);
            DropDownList_SubRegion.DataTextField = "SubRegion";
            DropDownList_SubRegion.DataValueField = "SubRegion";
            DropDownList_SubRegion.DataBind();
            DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "ALL"));


        }
        protected void DropDownList_SubRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //subreg = DropDownList_SubRegion.SelectedValue;
            //regional_counts.Visible = false;
            //Panel3.Visible = false;

            DropDownList_TMO.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "TMO");
            DropDownList_TMO.DataTextField = "TMO";
            DropDownList_TMO.DataValueField = "TMO";
            DropDownList_TMO.DataBind();
            DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));

            DropDownList_SE.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "SE");
            DropDownList_SE.DataTextField = "SE_Name";
            DropDownList_SE.DataValueField = "SE_Name";
            DropDownList_SE.DataBind();
            DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));

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
                        if (role.Equals("1") == true || role.Equals("2") == true || role.Equals("3") == true)
                            regio = DropDownList_Region.SelectedValue.ToString();

                       subreg = DropDownList_SubRegion.SelectedValue.ToString();
                       regional_counts.Visible = true;
                       Panel3.Visible = true;
                      //  UpdateCounts();
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