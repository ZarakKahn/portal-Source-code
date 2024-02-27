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
    public partial class Login : System.Web.UI.Page
    {
        string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               // Control list = this.Page.Master.FindControl("mainMenu");
                 this.Page.Master.FindControl("mainMenu").FindControl("test").Visible=false;

                if (Session["user"] != null)
                {
                    Response.Redirect("Dashboard.aspx");
                }
               
                    
            }
        }
        protected void change_pass(object sender, EventArgs e)
        {
            try
            {
                reset.Visible = true;
                login.Visible = false;
                Button2.Visible = true;
                Button1.Visible = false;
            }
            catch (Exception ex)

            {
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                string ntlogin = Email1.Value;
               
                string new_password = new_pass.Value;
                if (ntlogin.Equals(""))
                {
                    ShowAlert("Kindly enter email !");
                }
                
                else if (new_password.Equals(""))
                {
                    ShowAlert("Kindly enter new password !");
                }
                else if (new_password.Length<6)
                {
                    ShowAlert("Kindly enter Valid new password (minimum length must be 6 and above) !");
                }
                else
                {
                    string msg = new Procedures().Updatepassword(ntlogin.Replace("@masgroup.org", ""), new_password);
                    ShowAlert(msg);
                    reset.Visible = false;
                    login.Visible = true;
                    Button2.Visible = false;
                    Button1.Visible = true;
                }

            }
            catch (Exception ex)

            {
                ShowAlert(ex.Message);
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string ntlogin = inputEmail3.Value;
                string password = inputPassword3.Value;
                if (ntlogin.Equals(""))
                {
                    ShowAlert("Kindly enter email !");
                }
                else if (password.Equals(""))
                {
                    ShowAlert("Kindly enter password !");
                }
                else
                {
                     //Response.Write(user);
                        DataTable dt = new Procedures().GetUserIdentityPassword(ntlogin.Replace("@masgroup.org",""),password);

                    if (dt.Rows.Count != 0)

                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item["ntlogin"].ToString().Equals("Not Authorized"))
                            {
                                Response.Redirect("ErrorPage.aspx");
                            }
                            else
                            {
                                Session["user"] = ntlogin.Replace("@masgroup.org", "");
                                Response.Redirect("Dashboard.aspx");
                            }
                        }
                    }
                    else
                    {

                        ShowAlert("Wrong Passowrd !");
                    }
                    
                }
            }
            catch (Exception ex)

            {
            }
        }

        protected void ShowAlert(string msg)
        {
            string alertmessage = "alert('" + msg + "')";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", alertmessage, true);  // "alert('Complaint has been registered successfully.')"
        }
    }
}