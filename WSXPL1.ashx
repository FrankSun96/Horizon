<%@ WebHandler Language="C#" Class="WSXPL1" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
public class WSXPL1 : IHttpHandler ,System.Web.SessionState.IRequiresSessionState{
    
   // 获取所有的评论数据
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int gameID = Convert.ToInt32(context.Session["gameID"]);
            SqlConnection aConnection = new SqlConnection();
            SqlCommand aCommand = new SqlCommand();
            DataSet aDataSet= new DataSet();
            SqlDataAdapter aAdapter = new SqlDataAdapter();
            string aConnectionString;
            aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
            string aQuery = "SELECT UserAccount, ReviewText, Date FROM Review where GameID = "+gameID+" order by Date DESC";
            aConnection.ConnectionString = aConnectionString;
            aCommand = new SqlCommand(aQuery, aConnection);
            aAdapter.SelectCommand = aCommand;
            aAdapter.SelectCommand.Connection.Open();
            aAdapter.Fill(aDataSet, "Reuslts");   
            StringBuilder sb = new StringBuilder(); //创建StringBuilder更加方便的搜集数据
            foreach (DataRow row in aDataSet.Tables[0].Rows)
            {
                sb.Append(row[0].ToString()).Append("|").Append(row[1].ToString()).Append("|").Append(row[2].ToString()).Append("$");
            }
            aConnection.Close();
            context.Response.Write(sb);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

}
