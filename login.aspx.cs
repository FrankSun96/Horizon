using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookies = Request.Cookies["USER_COOKIE"];
        if (cookies != null)
        {
            //如果Cookie不为空，则将Cookie里面的用户名和密码读取出来赋值给前台的文本框。
            this.txtAccount.Text = cookies["UserName"];
            this.txtPassword.Attributes.Add("value", cookies["UserPassword"]);
            //这里依然把记住密码的选项给选中。
            this.radRem.Checked = true;
        }

    }
    protected void bntOK_Click(object sender, EventArgs e)
    {
        string account, password;
        account = txtAccount.Text;
        password = txtPassword.Text;
        rememberMeCheck(account, password);
        SqlConnection aConnection = new SqlConnection();
        SqlCommand aCommand = new SqlCommand();
        DataSet aDataSet = new DataSet();
        SqlDataAdapter aDataAdapter = new SqlDataAdapter();
        string aConnectionString, aInputQueryString;
        account = txtAccount.Text;
        password = txtPassword.Text;
        aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;";
        aConnectionString += "Integrated Security=True";
        aInputQueryString = "SELECT * FROM WebUser WHERE UserAccount = @account AND UserPassword = @password";
        SqlParameter[] paras = new SqlParameter[]{  
                new SqlParameter ("@account",account ),
                new SqlParameter ("@password",password )  
            }; 
        aConnection.ConnectionString = aConnectionString;
        aCommand = new SqlCommand(aInputQueryString, aConnection);
        aDataAdapter.SelectCommand = aCommand;
        for (int i = 0; i < paras.Length; i++)
            aCommand.Parameters.Add(paras[i]);
            aDataAdapter.SelectCommand.Connection.Open();
        aDataAdapter.Fill(aDataSet, "InputUser");
        if (aDataSet.Tables["InputUser"].Rows.Count == 0)
        {
            Response.Write("No User Founded");
        }
        else
        {
            Session["WebUser"] = txtAccount.Text.Trim();
            Response.Redirect("index.aspx");
        }

    }
    protected void rememberMeCheck(string account, string password)
    {
        if (radRem.Checked)
        {
            HttpCookie cookie = new HttpCookie("USER_COOKIE");
            cookie.Values.Add("UserName", account);
            cookie.Values.Add("UserPassword", password);
            //这里是设置Cookie的过期时间，这里设置一个星期的时间，过了一个星期之后状态保持自动清空。
            cookie.Expires = System.DateTime.Now.AddDays(7.0);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        else
        {
            Response.Cookies["USER_COOKIE"].Expires = DateTime.Now;
        }
    }
}