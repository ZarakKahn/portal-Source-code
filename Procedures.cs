using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Training_Solution
{
    public class Procedures
    {
        SqlConnection Con = new SqlConnection("Data Source=192.168.0.12;Initial Catalog=PowerBI;User Id=powerbi;Password=powerbi");

        public DataTable GetUserIdentity(string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CheckUserIdentity", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NT", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable GetUserIdentityPassword(string NT, string pass)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CheckUser", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NT", NT);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable Region(string role)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetRegion", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@role", role);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable GetWeekly_Visits(string region, string month)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MVR_Weekly_Report", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@region", region);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable SubRegion(string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetSubRegion", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable SubRegion_R(string user, string region)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetSubRegion_R", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@region", region);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable GetRegion_hierarchy(string region)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetRegion_hierarchy", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", region);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable Team(string region, string role, string type)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTeam", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@user", role);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable Areas(string region, string subregion, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetAreas", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable Retailors(string region, string subregion, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetRetailor", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable TeamSubRegion(string subregion, string type)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTeam_SubRegion", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@Type", type);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public DataTable GetTeam()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTeam", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }

        public DataTable GetDealers()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetDealers", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }

        public DataTable GetOMC_Sales()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetOMC_Sales", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetType_Dropdown()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetType_Dropdown", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }

        public DataTable GetAudience_BYID(string id)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetAudience_BYID", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;

        }

        public DataTable GetAudience_Dropdown()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetAudience_Dropdown", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetLocation_Dropdown()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetLocation_Dropdown", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetSubType_Dropdown()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Get_SubType_Dropdown", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }

        public DataTable GetRegional_Counts(string from, string to, string region, string subreg, string user, string team)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetRegional_Counts_", Con);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.AddWithValue("@fromdate", from);
            cmd.Parameters.AddWithValue("@todate", to);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subreg);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@team", team);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable Get_Location(string from, string to, string region, string subreg, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Get_Location", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", from);
            cmd.Parameters.AddWithValue("@todate", to);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subreg);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }

        internal DataTable GetUserHirarchy(string region, string search_user, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("UserHirarchy", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usertype", search_user);
            cmd.Parameters.AddWithValue("@username", user);
            cmd.Parameters.AddWithValue("@region", region);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }

        public DataTable Get_PerformanceKPIs_Monthly()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Get_PerformanceKPIs_Monthly", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable Get_PerformanceKPIs_Yearly()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Get_PerformanceKPIs_Yearly", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }

        public DataTable Get_Projects_BYID(int id)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Get_Projects_BYID", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", id);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;
        }
        public string Updatepassword(string username, string newpass)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("UpdatePassword", Con);
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@newpassword", newpass);
            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            return cmd.Parameters["@Msg"].Value.ToString();
        }

        public string AddSales(string date, string dealer, string PMG, string HSD, string HOBC,string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("AddOMCSS", Con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dealer", dealer);
            cmd.Parameters.AddWithValue("@PMG", PMG);
            cmd.Parameters.AddWithValue("@HSD", HSD);
            cmd.Parameters.AddWithValue("@HOBC", HOBC);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            return cmd.Parameters["@Msg"].Value.ToString();
        }
        public string UpdateSales(string date, string dealer, string PMG, string HSD, string HOBC, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("UpdateOMCSS", Con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dealer", dealer);
            cmd.Parameters.AddWithValue("@PMG", PMG);
            cmd.Parameters.AddWithValue("@HSD", HSD);
            cmd.Parameters.AddWithValue("@HOBC", HOBC);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            return cmd.Parameters["@Msg"].Value.ToString();
        }
        public string DeleteOMCSales(string id)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("DeleteOMCSS", Con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            return cmd.Parameters["@Msg"].Value.ToString();
        }
        public string InsertTraining_KPI(string Trainer, string qSL, string feedback, string impact, string agent_KPI, string treshhold, string audit, string addedBy)
        {
            SqlCommand cmd = new SqlCommand("InsertTraining_KPI", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Trainer", Trainer);
            cmd.Parameters.AddWithValue("@QSL", qSL);
            cmd.Parameters.AddWithValue("@feedback", feedback);
            cmd.Parameters.AddWithValue("@impact", impact);

            cmd.Parameters.AddWithValue("@agent_KPI", agent_KPI);
            cmd.Parameters.AddWithValue("@treshhold", treshhold);
            cmd.Parameters.AddWithValue("@audit", audit);
            cmd.Parameters.AddWithValue("@addedby", addedBy);


            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            return cmd.Parameters["@Msg"].Value.ToString();

        }

        public  DataTable Get_Individual_Summary()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Get_Individual_Summary", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }

        public DataTable GetAll_Projects_Search(string trainer, string sUBTYPE, string mONTHS)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetAll_Projects_Search", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NT", trainer);
            cmd.Parameters.AddWithValue("@SUBTYPE", sUBTYPE);
            cmd.Parameters.AddWithValue("@MONTHS", mONTHS);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            Con.Open();
            da.Fill(dt);
            Con.Close();

            return dt;

        }

        public DataTable GetAll_Projects()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetProjets", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetHierarchy_Visits(string fromdate, string todate, string region, string subregion, string team, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetHierarchy_Visits_", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@team", team);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetArea_Visits(string fromdate, string todate, string region, string subregion, string Area, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetArea_Visits", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetArea_RegionalVisits(string fromdate, string todate, string region, string subregion, string Area, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetArea_RegionalVisits", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
          
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTeam_Visits(string fromdate, string todate, string region, string subregion, string TMO, string SE, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTeam_Visits", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@TMO", TMO);
            cmd.Parameters.AddWithValue("@SE", SE);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTop_Visits(string fromdate, string todate, string region, string subregion, string team, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTop_Visits_", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@team", team);
            
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTop_RetailorVisits(string fromdate, string todate, string region, string subregion, string TMO, string SE, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTop_RetailorVisits", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@TMO", TMO);
            cmd.Parameters.AddWithValue("@SE", SE);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        
        public DataTable GetLeast_Visits(string fromdate, string todate, string region, string subregion, string team, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetLeast_Visits_", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@team", team);
            
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetLeast_Retailor(string fromdate, string todate, string region, string subregion, string TMO, string SE, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetLeast_Retailor", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@TMO", TMO);
            cmd.Parameters.AddWithValue("@SE", SE);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetLeastArea_Visits(string fromdate, string todate, string region, string subregion, string team, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetLeastArea_Visits_", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@team", team);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTopArea_Visits(string fromdate, string todate, string region, string subregion, string team, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTopArea_Visits_", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@team", team);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable Get_Complaints(string fromdate, string todate, string region, string subregion, string team, string user)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Get_Complaints_", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@subregion", subregion);
            cmd.Parameters.AddWithValue("@team", team);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable Get_VisitsCounts(string fromdate, string todate, string region, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetHierarchy_Visits", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetLeastVisitors(string fromdate, string todate, string region, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetLeastVisitors", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetLeastVisitors_SubRegion(string fromdate, string todate, string region)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetLeastVisitors_SubRegion", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTopVisitors(string fromdate, string todate, string region, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTopVisitors", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTopVisitors_SubRegion(string fromdate, string todate, string region)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTopVisitors_SubRegion", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTopVisitors_Team(string fromdate, string todate, string Name)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTopVisitors_Team", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@name", Name);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTopVisitors_BYArea(string fromdate, string todate, string region, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTopVisitors_BYCity", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetTopVisitors_BYArea_Sub(string fromdate, string todate, string region)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetTopVisitors_BYCity_SubReg", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetLeastVisitors_BYArea(string fromdate, string todate, string region, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetVisitors_BYCity", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetLeastVisitors_BYArea_Sub(string fromdate, string todate, string region)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("etVisitors_BYCity_SubReg", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@region", region);
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetAll_Visits(string fromdate, string todate, string visitor_name, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetVisits", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@visitor_name", visitor_name);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetAll_VisitsCounts(string fromdate, string todate, string visitor_name, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetVisits_Counts", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@visitor_name", visitor_name);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetAll_Visits_Area(string fromdate, string todate, string area,string order, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetVisits_Area", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@area", area);
            cmd.Parameters.AddWithValue("@order", order);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public DataTable GetAll_VisitsCounts_Area(string fromdate, string todate, string area, string NT)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GetVisits_AreaCounts", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@area", area);
            cmd.Parameters.AddWithValue("@username", NT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Con.Open();
            da.Fill(dt);
            Con.Close();
            return dt;
        }
        public string InsertTraining(string Name, string Audience, string Type, string SUBTYPE, string MONTHS, string Trainer, string Intiation, string
                Participants, string Duration, string Days, string FeedbackScore, string BeofreSession, string
                AfterSession, string location, string Impact, string Remarks, string addedby,DataTable dt)//DataTable ClosureForm
        {
            SqlCommand cmd = new SqlCommand("InsertTraining", Con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Audience", Audience);
            cmd.Parameters.AddWithValue("@Type", Type);

            cmd.Parameters.AddWithValue("@SUBTYPE", SUBTYPE);
            cmd.Parameters.AddWithValue("@MONTHS", MONTHS);
            cmd.Parameters.AddWithValue("@Trainer", Trainer);
            cmd.Parameters.AddWithValue("@Intiation", Intiation);
            cmd.Parameters.AddWithValue("@Participants", Participants);
            cmd.Parameters.AddWithValue("@location", location);
            cmd.Parameters.AddWithValue("@Duration", Duration);
            cmd.Parameters.AddWithValue("@Days", Days);
            cmd.Parameters.AddWithValue("@FeedbackScore", FeedbackScore);
            cmd.Parameters.AddWithValue("@BeofreSession", BeofreSession);
            cmd.Parameters.AddWithValue("@AfterSession", AfterSession);

            cmd.Parameters.AddWithValue("@Impact", Impact);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@addedby", addedby);

            cmd.Parameters.Add("@Pro_Audience", SqlDbType.Structured);
            cmd.Parameters["@Pro_Audience"].Value = dt;

            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            return cmd.Parameters["@Msg"].Value.ToString();
        }
        public string UpdateTraining(int id,string Name, string Audience, string Type, string SUBTYPE, string MONTHS, string Trainer, string Intiation, string
                Participants, string Duration, string Days, string FeedbackScore, string BeofreSession, string
                AfterSession, string location, string Impact, string Remarks, string addedby)//DataTable ClosureForm
        {
            SqlCommand cmd = new SqlCommand("UpdateTraining", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Audience", Audience);
            cmd.Parameters.AddWithValue("@Type", Type);

            cmd.Parameters.AddWithValue("@SUBTYPE", SUBTYPE);
            cmd.Parameters.AddWithValue("@MONTHS", MONTHS);
            cmd.Parameters.AddWithValue("@Trainer", Trainer);
            cmd.Parameters.AddWithValue("@Intiation", Intiation);
            cmd.Parameters.AddWithValue("@Participants", Participants);
            cmd.Parameters.AddWithValue("@location", location);
            cmd.Parameters.AddWithValue("@Duration", Duration);
            cmd.Parameters.AddWithValue("@Days", Days);
            cmd.Parameters.AddWithValue("@FeedbackScore", FeedbackScore);
            cmd.Parameters.AddWithValue("@BeofreSession", BeofreSession);
            cmd.Parameters.AddWithValue("@AfterSession", AfterSession);

            cmd.Parameters.AddWithValue("@Impact", Impact);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@updatedby", addedby);


            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            return cmd.Parameters["@Msg"].Value.ToString();
        }

        public string InsertBulk_Training(string addedBy, DataTable dt)
        {
            SqlCommand cmd = new SqlCommand("Bulk_InsertTraining", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@addedby", addedBy);

            cmd.Parameters.Add("@Pro_Audience", SqlDbType.Structured);
            cmd.Parameters["@Pro_Audience"].Value = dt;

            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            return cmd.Parameters["@Msg"].Value.ToString();
        }
    }
}
