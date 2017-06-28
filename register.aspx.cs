using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int type = Convert.ToInt32(radUserType.SelectedValue);
        if (type == 1)
        {
            txtIPC.Enabled = true;
        }
        else
        {
            txtIPC.Enabled = false;
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        SqlConnection aConnection = new SqlConnection();
        SqlCommand aCommand = new SqlCommand();
        string username = txtAccount.Text;
        string password = txtPassword.Text;
        string nickname = txtNickname.Text;
        string email = txtEmail.Text;
        string ipc = txtIPC.Text;
        int type = Convert.ToInt32(radUserType.SelectedValue);
        string aConnectionString;
        aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        string aUserQuery = "INSERT INTO WebUser(UserTypeID,UserAccount,UserPassword,UserNickName,UserEmail,Banned) VALUES (1,'"+username+"','"+password+"','"+nickname+"','"+email+"'," + 0 + ")";
        string aPublisherQuery = "INSERT INTO WebUser(UserTypeID,UserAccount,UserPassword,UserNickName,UserEmail,Banned,IdentifierInsurance) VALUES (2,'" + username + "','" + password + "','" + nickname + "','" + email + "'," + 0 + ",'"+ipc+"')";
        aConnection.ConnectionString = aConnectionString;
        if(type == 0)
            aCommand = new SqlCommand(aUserQuery, aConnection);
        else
            aCommand = new SqlCommand(aPublisherQuery, aConnection);
        aConnection.Open();
        aCommand.ExecuteNonQuery();
        aConnection.Close();
        Session["WebUser"] = username;
        Response.Redirect("index.aspx");
    }
    protected void chbAgree_CheckedChanged(object sender, EventArgs e)
    {
        if (chbAgree.Checked)
        {
            btnCreate.Visible = true;
        }
    }
}