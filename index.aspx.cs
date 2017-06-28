using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    int[] id = new int[5];
    int[] videoID= new int[5];
    public string welcomeBack;
    protected void Page_Load(object sender, EventArgs e)
    {
        welcomeBack = new Request().ReturnValue;
        SqlConnection aConnection = new SqlConnection();
        SqlCommand aCommand = new SqlCommand();
        DataSet aTop5ImgDataSet = new DataSet();
        SqlDataAdapter aTop5ImgAdapter = new SqlDataAdapter();
        string aConnectionString;
        aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        string aSelectTop7GameImgQuery = "SELECT TOP 5 Gameimg, GameID FROM Game ORDER BY Count DESC";
        aConnection.ConnectionString = aConnectionString;
        aCommand = new SqlCommand(aSelectTop7GameImgQuery, aConnection);
        aTop5ImgAdapter.SelectCommand = aCommand;
        aTop5ImgAdapter.SelectCommand.Connection.Open();
        aTop5ImgAdapter.Fill(aTop5ImgDataSet, "Top5Img");
        Image1.ImageUrl = aTop5ImgDataSet.Tables[0].Rows[0][0].ToString();
        Image2.ImageUrl = aTop5ImgDataSet.Tables[0].Rows[1][0].ToString();
        Image3.ImageUrl = aTop5ImgDataSet.Tables[0].Rows[2][0].ToString();
        Image4.ImageUrl = aTop5ImgDataSet.Tables[0].Rows[3][0].ToString();
        Image5.ImageUrl = aTop5ImgDataSet.Tables[0].Rows[4][0].ToString();
        for (int i = 0; i < 5; i++)
        {
            id[i] = Int32.Parse(aTop5ImgDataSet.Tables[0].Rows[i][1].ToString());
        }
        aConnection.Close();
        SqlConnection aConnection2 = new SqlConnection();
        SqlCommand aCommand2 = new SqlCommand();
        DataSet aTop5ImgDataSet2 = new DataSet();
        SqlDataAdapter aTop5ImgAdapter2 = new SqlDataAdapter();
        string aConnectionString2;
        aConnectionString2 = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        string aSelectVideQuery = "SELECT TOP 5 CoverImg,VideoID, VideoName FROM Video ORDER BY Count DESC";
        aConnection2.ConnectionString = aConnectionString2;
        aCommand2 = new SqlCommand(aSelectVideQuery, aConnection2);
        aTop5ImgAdapter2.SelectCommand = aCommand2;
        aTop5ImgAdapter2.SelectCommand.Connection.Open();
        aTop5ImgAdapter2.Fill(aTop5ImgDataSet2, "Top5Img");
        ImageButton1.ImageUrl = aTop5ImgDataSet2.Tables[0].Rows[0][0].ToString();
        ImageButton2.ImageUrl = aTop5ImgDataSet2.Tables[0].Rows[1][0].ToString();
        ImageButton3.ImageUrl = aTop5ImgDataSet2.Tables[0].Rows[2][0].ToString();
        ImageButton4.ImageUrl = aTop5ImgDataSet2.Tables[0].Rows[3][0].ToString();
        ImageButton5.ImageUrl = aTop5ImgDataSet2.Tables[0].Rows[4][0].ToString();
        Label1.Text = aTop5ImgDataSet2.Tables[0].Rows[0][2].ToString();
        Label2.Text = aTop5ImgDataSet2.Tables[0].Rows[1][2].ToString();
        Label3.Text = aTop5ImgDataSet2.Tables[0].Rows[2][2].ToString();
        Label4.Text = aTop5ImgDataSet2.Tables[0].Rows[3][2].ToString();
        Label5.Text = aTop5ImgDataSet2.Tables[0].Rows[4][2].ToString();
        for (int i = 0; i < 5; i++)
        {
            videoID[i] = Int32.Parse(aTop5ImgDataSet2.Tables[0].Rows[i][1].ToString());
        }
        aConnection2.Close();
    }

    protected void Image1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("games.aspx?gameID=" + id[0]);
    }
    protected void Image2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("games.aspx?gameID=" + id[1]);
    }
    protected void Image3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("games.aspx?gameID=" + id[2]);
    }
    protected void Image4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("games.aspx?gameID=" + id[3]);
    }
    protected void Image5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("games.aspx?gameID=" + id[4]);
    }
   
    protected void Image01_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("videos.aspx?videoID=" + videoID[0]);

    }
    protected void Image02_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("videos.aspx?videoID=" + videoID[1]);

    }
    protected void Image03_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("videos.aspx?videoID=" + videoID[2]);

    }
    protected void Image04_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("videos.aspx?videoID=" + videoID[3]);

    }
    protected void Image05_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("videos.aspx?videoID=" + videoID[4]);

    }
}