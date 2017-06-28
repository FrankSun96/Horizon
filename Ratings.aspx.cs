using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Ratings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RatingRate.CurrentRating = 2;

    }
    protected void SubmitRating(object sender, EventArgs e)
    {
        int rating = RatingRate.CurrentRating;
        SqlConnection aConnection = new SqlConnection();
        SqlCommand aCommand = new SqlCommand();
        DataSet aDataSet = new DataSet();
        SqlDataAdapter aAdapter = new SqlDataAdapter();
        string aConnectionString;
        aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        string aQuery = "SELECT *";
        aConnection.ConnectionString = aConnectionString;
        aCommand = new SqlCommand(aQuery, aConnection);
        aAdapter.SelectCommand = aCommand;
        aAdapter.SelectCommand.Connection.Open();
        aAdapter.Fill(aDataSet, "Reuslts");
        aConnection.Close();
    }
}