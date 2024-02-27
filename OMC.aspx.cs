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
    public partial class OMC : System.Web.UI.Page
    {
        static string from, to, subreg = "", role = "", user = "", team = "";

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

                        DropDownList_Dealers.DataSource = new Procedures().GetDealers();
                        DropDownList_Dealers.DataTextField = "DealerName";
                        DropDownList_Dealers.DataValueField = "DealerName";
                        DropDownList_Dealers.DataBind();
                        DropDownList_Dealers.Items.Insert(0, new ListItem("Select", "0"));
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
        protected void DropDownList_Dealers_SelectedIndexChanged(object sender, EventArgs e)
        {
            team = DropDownList_Dealers.SelectedValue;
            DataTable dt = new DataTable();
            dt = new Procedures().GetDealers();

            foreach (DataRow item in dt.Rows)
            {
                try
                {

                    if (item[0].ToString() == team)
                    {
                        Text_type.Value = item[1].ToString();
                        Text_salesperson.Value = item[2].ToString();
                        Text_region.Value = item[3].ToString();
                    }
                }
                catch (Exception ex)
                {
                    ShowAlert(ex.Message);
                }
            }
        }
        protected void Show_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            string msg = new Procedures().UpdateSales(datepicker_to.Value, DropDownList_Dealers.SelectedValue, PMG.Value, HSD.Value, HOBC.Value, user);
            ShowAlert(msg);
            UpdateGrid();
        }
        protected void Submit_Click2(object sender, EventArgs e)
        {
            try
            {

                if (datepicker_to.Value.Equals(""))
                {
                    ShowAlert("Kindly Select Date !");
                }
                else if (DropDownList_Dealers.SelectedValue.Equals("0"))
                    {
                    ShowAlert("Kindly Select Dealer !");
                }
                else
                {
                    string msg = new Procedures().AddSales(datepicker_to.Value,DropDownList_Dealers.SelectedValue,PMG.Value,HSD.Value,HOBC.Value,user);
                    ShowAlert(msg);
                    UpdateGrid();
                }
                } catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void UpdateGrid()
        {
            DataTable dtt = new Procedures().GetOMC_Sales();
            OMC_Sales_Grid.DataSource = dtt;
            OMC_Sales_Grid.DataBind();

        }
        protected void GridView_Visitors_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = OMC_Sales_Grid.Rows[index];
            if (e.CommandName == "EditRow")
            {
                datepicker_to.Value = Convert.ToDateTime(row.Cells[8].Text).ToShortDateString().ToString();
                datepicker_to.Attributes.Add("disabled", "disabled");
                
                DropDownList_Dealers.SelectedValue = row.Cells[1].Text;
                DropDownList_Dealers.Attributes.Add("disabled", "disabled");
                Text_type.Value = row.Cells[2].Text;
                Text_salesperson.Value = row.Cells[3].Text;
                Text_region.Value = row.Cells[4].Text;
                PMG.Value = row.Cells[5].Text;
                HSD.Value = row.Cells[6].Text;
                HOBC.Value = row.Cells[7].Text;
                Button1.Visible = false;
                Button4.Visible = true;
              
            }
            else if (e.CommandName== "DeleteRow")
            {
                string id = row.Cells[0].Text;
                string msg = new Procedures().DeleteOMCSales(id);
                ShowAlert(msg);
                UpdateGrid();
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dateTime = DateTime.UtcNow.Date.AddDays(-1);
                    Console.WriteLine(dateTime.ToString("dd/MM/yyyy"));
                  //  GridViewRow row = OMC_Sales_Grid.Rows[index];
                    string d = Convert.ToDateTime(e.Row.Cells[8].Text).ToShortDateString().ToString();
                    string dd = dateTime.ToString("M/d/yyyy");
                    DateTime dt1 = DateTime.Parse(e.Row.Cells[8].Text);
                    DateTime dt2 = DateTime.UtcNow.Date.AddDays(-1);
                    string f = dt1.Date.ToString();
                    string fd = dt1.Date.ToString();
                    Console.WriteLine(dt1.Date);
                    Console.WriteLine(dt2.Date);
                   
                    if (dt1.Date < dt2.Date)
                    {
                        Button btndel = (Button)e.Row.FindControl("btndelete");

                        btndel.Visible = false;

                           Button btnEdit = (Button)e.Row.FindControl("btnedit");

                        btnEdit.Visible = false;
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
        protected void ShowAlert(string msg)
        {
            string alertmessage = "alert('" + msg + "')";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", alertmessage, true);  // "alert('Complaint has been registered successfully.')"
        }
    }
}