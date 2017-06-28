<%@ WebHandler Language="C#" Class="WSXPL" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
public class WSXPL : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
  // 执行插入数据处理程序
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = context.Request["msg"];
            string account = context.Session["WebUser"].ToString();
            int gameID = Convert.ToInt32(context.Session["gameID"]);
            SqlConnection aConnection = new SqlConnection();
            SqlCommand aCommand = new SqlCommand();
            string aConnectionString;
            aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
            string aQuery = "INSERT INTO Review(GameID, UserAccount, ReviewText, Date, UIRate, FunRate, DifficultyRate) Values ('"+gameID+"','"+account+"','" + msg + "','" + DateTime.Now + "', 0, 0, 0)";
            aConnection.ConnectionString = aConnectionString;
            aCommand = new SqlCommand(aQuery, aConnection);
            aConnection.Open();
            aCommand.ExecuteNonQuery();
            aConnection.Close();
            context.Response.Write("ok");
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
}