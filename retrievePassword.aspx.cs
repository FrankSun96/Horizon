using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class retrievePassowrd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string account = txtAccount.Text.ToString();
        string email = txtEmail.Text.ToString();
        string password = txtPassword.Text.ToString();
        SqlConnection aConnection = new SqlConnection();
        SqlCommand aCommand = new SqlCommand();
        DataSet aDataSet = new DataSet();
        SqlDataAdapter aDataAdapter = new SqlDataAdapter();
        string aConnectionString;
        aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        string aUserQuery = "SELECT * FROM WebUser WHERE UserAccount = '" + account + "' AND UserEmail = '" + email + "';";
        string aChangeQuery = "UPDATE WebUser SET UserPassword = '"+password+"' WHERE UserAccount = '"+account+"';";
        aConnection.ConnectionString = aConnectionString;
        aCommand = new SqlCommand(aUserQuery, aConnection);
        aDataAdapter.SelectCommand = aCommand;
        aDataAdapter.SelectCommand.Connection.Open();
        aDataAdapter.Fill(aDataSet, "InputUser");
        if (aDataSet.Tables["InputUser"].Rows.Count == 0)
        {
            Response.Write("No User Founded");
        }
        else
        {
            aCommand = new SqlCommand(aChangeQuery, aConnection);
            aCommand.ExecuteNonQuery();

        }
        aConnection.Close();
        Response.Redirect("index.aspx");
    }
}