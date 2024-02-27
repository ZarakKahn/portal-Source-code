using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market_Visit_Portal
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         //   user = ;
            Response.Write(Request.LogonUserIdentity.Name.Replace("MASGROUP\\", string.Empty));
        }
    }
}