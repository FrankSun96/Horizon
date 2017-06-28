using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common;
public partial class videos : System.Web.UI.Page
{
    public string welcomeBack;
    protected void Page_Load(object sender, EventArgs e)
    {
        welcomeBack = new Request().ReturnValue;
        int videoID = Int32.Parse(Request.QueryString["videoID"]);
        Session["videoID"] = videoID;
        SqlConnection aConnection = new SqlConnection();
        SqlCommand aCommand = new SqlCommand();
        DataSet aDataSet = new DataSet();
        SqlDataAdapter aDataAdapter = new SqlDataAdapter();
        string aConnectionString;
        aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        string aQuery = "SELECT VideoName,VideoIntroduction,VideoURL,Date,UserAccount FROM Video WHERE videoID = " + videoID;
        aConnection.ConnectionString = aConnectionString;
        aCommand = new SqlCommand(aQuery, aConnection);
        aDataAdapter.SelectCommand = aCommand;
        aDataAdapter.SelectCommand.Connection.Open();
        aDataAdapter.Fill(aDataSet, "Results");
        VideoName.Text = aDataSet.Tables[0].Rows[0][0].ToString();
        Introduction.Text = aDataSet.Tables[0].Rows[0][1].ToString();
        this.video_content.InnerHtml = PlayMedia.Play(aDataSet.Tables[0].Rows[0][2].ToString(), 472, 385);
   
        Date.Text = aDataSet.Tables[0].Rows[0][3].ToString();
        UserAccount.Text = aDataSet.Tables[0].Rows[0][4].ToString();

        aConnection.Close();
    }
}