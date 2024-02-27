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
    public partial class Visits : System.Web.UI.Page
    {
        static string from, to, role, user, reg,subreg;
        static int totalvisits = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Panel1.Visible = false;

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

                                DropDownList_SubRegion.DataSource = new Procedures().SubRegion_R(user, "ALL");
                                DropDownList_SubRegion.DataTextField = "Handler";
                                DropDownList_SubRegion.DataValueField = "Handler";
                                DropDownList_SubRegion.DataBind();
                                DropDownList_SubRegion.Items.Insert(0, new ListItem("ALL", "All"));

                                DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));
                                DropDownList_TMO.Items.Insert(1, new ListItem("TSO", "TSO"));
                                DropDownList_TMO.Items.Insert(2, new ListItem("ASM", "ASM"));


                                /* DropDownList_TMO.DataSource = new Procedures().Team("All",user, "TSO");
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

                                /* DropDownList_TMO.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue, user, "TSO");
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

            


            /*DropDownList_TMO.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue, user, "TSO");
            DropDownList_TMO.DataTextField = "TSO";
            DropDownList_TMO.DataValueField = "TSO";
            DropDownList_TMO.DataBind();
            DropDownList_TMO.Items.Insert(0, new ListItem("ALL", "ALL"));*/


            //DropDownList_SE.DataSource = new Procedures().Team(DropDownList_Region.SelectedValue,user, "SE");
            //DropDownList_SE.DataTextField = "SE_Name";
            //DropDownList_SE.DataValueField = "SE_Name";
            //DropDownList_SE.DataBind();
            //DropDownList_SE.Items.Insert(0, new ListItem("ALL", "ALL"));

            DataTable d = new Procedures().GetHierarchy_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue, user);
            if (d.Rows.Count < 10)
            {

            }
            GridView1.DataSource = d;
            GridView1.DataBind();

        }
        protected void DropDownList_SubRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*DropDownList_TMO.DataSource = new Procedures().TeamSubRegion(DropDownList_SubRegion.SelectedValue, "TSO");
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

            DataTable d = new Procedures().GetHierarchy_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue, user);
            if (d.Rows.Count < 10)
            {

            }
            GridView1.DataSource = d;
            GridView1.DataBind();

        }
        protected void DropDownList_TMO_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable d = new Procedures().GetHierarchy_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue, user);
            if (d.Rows.Count < 10)
            {

            }
            GridView1.DataSource = d;
            GridView1.DataBind();

        }
        protected void DropDownList_SE_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable d = new Procedures().GetHierarchy_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue,user);
            if (d.Rows.Count < 10)
            {

            }
            GridView1.DataSource = d;
            GridView1.DataBind();

        }
        public void UpdateGrid()
        {
                DataTable d = new Procedures().GetHierarchy_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue, user);
            if (d.Rows.Count < 10)
            {

            }
            GridView1.DataSource = d;
            GridView1.DataBind();

        }
        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string count = e.Row.Cells[7].Text;
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
        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Details")
            {
                GridViewRow row = GridView1.Rows[index];
                if (!row.Cells[7].Text.Equals("0"))
                {
                    string se = row.Cells[6].Text;
                    Projects_Grid.DataSource = new Procedures().GetAll_Visits(datepicker_from.Value, datepicker_to.Value, se, "iqra.iqbal");
                    Projects_Grid.DataBind();
                    DataTable dt = new Procedures().GetAll_VisitsCounts(datepicker_from.Value, datepicker_to.Value, se, "iqra.iqbal");

                    Panel1.Visible = true;
                    Projects_Grid.Focus();
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
                        if (role.Equals("1") == true || role.Equals("2") == true || role.Equals("3") == true)
                            reg = DropDownList_Region.SelectedValue.ToString();
                        else
                            reg = DropDownList_SubRegion.SelectedValue.ToString();
                        //     regional_counts.Visible = true;
                        //   UpdateCounts();
                        Panel1.Visible = false;
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
        protected void Export_Click(object sender, EventArgs e)
        {
            try
            {
              //  DataTable dt = new DataTable();
                DataTable d = new Procedures().GetHierarchy_Visits(datepicker_from.Value, datepicker_to.Value, DropDownList_Region.SelectedValue, DropDownList_SubRegion.SelectedValue, DropDownList_TMO.SelectedValue, user);

                ExporttoExcel(d);
            }

            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }
        private void ExporttoExcel(DataTable table)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=File.xls");

            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //am getting my grid's column headers
            int columnscount = Projects_Grid.Columns.Count - 1;

            for (int j = 3; j < columnscount; j++)
            {      //write in new column
                HttpContext.Current.Response.Write("<Td>");
                //Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(Projects_Grid.Columns[j].HeaderText.ToString());
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {//write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

    }
}