using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common;
public partial class games : System.Web.UI.Page
{
    public string welcomeBack;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["WebUser"] == null){
            btnpinglun.Disabled = true;
            msg.Disabled = true;
        }
        welcomeBack = new Request().ReturnValue;
        int gameID = Int32.Parse(Request.QueryString["gameID"]);
        //int gameID = 13;
        Session["gameID"] = gameID;
        SqlConnection aConnection = new SqlConnection();
        SqlCommand aCommand = new SqlCommand();
        DataSet aDataSet = new DataSet();
        SqlDataAdapter aDataAdapter = new SqlDataAdapter();
        string aConnectionString;
        aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        string aQuery = "SELECT GameName,GameImg,Introduction,GameTypeName,ProducerName,GameConfiguration FROM Game,GameType,Producer WHERE Game.GameTypeID = GameType.GameTypeID AND Game.GameProducerID = Producer.ProducerID AND GameID = " + gameID;
        string aVideoURL = "SELECT TOP 1 VideoURL FROM Video WHERE GameID = " + gameID;
        aConnection.ConnectionString = aConnectionString;
        aCommand = new SqlCommand(aQuery, aConnection);
        aDataAdapter.SelectCommand = aCommand;
        aDataAdapter.SelectCommand.Connection.Open();
        aDataAdapter.Fill(aDataSet, "Results");
        GameName.Text = aDataSet.Tables[0].Rows[0][0].ToString();
        ImageGame.ImageUrl = aDataSet.Tables[0].Rows[0][1].ToString();
        Introduction.Text= aDataSet.Tables[0].Rows[0][2].ToString();
        Type.Text = aDataSet.Tables[0].Rows[0][3].ToString();
        publisher.Text = aDataSet.Tables[0].Rows[0][4].ToString();
        Configuration.Text = aDataSet.Tables[0].Rows[0][5].ToString();
        aConnection.Close();
        aCommand = new SqlCommand(aVideoURL, aConnection);
        aDataAdapter.SelectCommand = aCommand;
        aDataAdapter.SelectCommand.Connection.Open();
        aDataAdapter.Fill(aDataSet, "Results");
        this.video_content.InnerHtml = PlayMedia.Play(aDataSet.Tables[0].Rows[0][0].ToString(), 600, 400);
        aConnection.Close();
    }
    
}