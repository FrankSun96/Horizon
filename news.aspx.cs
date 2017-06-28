using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class news : System.Web.UI.Page
{
    public string welcomeBack;
    protected void Page_Load(object sender, EventArgs e)
    {
        welcomeBack = new Request().ReturnValue;
        //int newsID = Int32.Parse(Request.QueryString["newsID"]);
        int newsID = 0;
        Session["newsID"] = newsID;
        SqlConnection aConnection = new SqlConnection();
        SqlCommand aCommand = new SqlCommand();
        DataSet aDataSet = new DataSet();
        SqlDataAdapter aDataAdapter = new SqlDataAdapter();
        string aConnectionString;
        aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        string aQuery = "SELECT NewsTitle,NewsText,NewsImg,Date,UserAccount FROM News WHERE NewsID = " + newsID;
        aConnection.ConnectionString = aConnectionString;
        aCommand = new SqlCommand(aQuery, aConnection);
        aDataAdapter.SelectCommand = aCommand;
        aDataAdapter.SelectCommand.Connection.Open();
        aDataAdapter.Fill(aDataSet, "Results");
        newsTitle.Text = aDataSet.Tables[0].Rows[0][0].ToString();
        newsContent.Text = aDataSet.Tables[0].Rows[0][1].ToString();
        newImg.ImageUrl = aDataSet.Tables[0].Rows[0][2].ToString();
        newsDate.Text = aDataSet.Tables[0].Rows[0][3].ToString();
        newsUserAccount.Text = aDataSet.Tables[0].Rows[0][4].ToString();
       
        aConnection.Close();
    }
}