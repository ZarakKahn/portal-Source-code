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
    public partial class mAP : System.Web.UI.Page
    {
        static string from, to, region = "", subreg = "", role = "", user = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            to = Request.QueryString["to"];
            from = Request.QueryString["from"];
            region = Request.QueryString["region"];
            subreg = Request.QueryString["subregion"];
            user = Request.QueryString["user"];
        }

        protected void ShowAlert(string msg)
        {
            string alertmessage = "alert('" + msg + "')";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", alertmessage, true);  // "alert('Complaint has been registered successfully.')"
        }
        public string ConvertDataTabletoString()
        {
            DataTable dt = new DataTable();
            dt = new Procedures().Get_Location(from, to, region, subreg, user);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                   
                    rows.Add(row);
                }
            }
            else
                ShowAlert("No Locations");
                return serializer.Serialize(rows);
            }
        }
    }
