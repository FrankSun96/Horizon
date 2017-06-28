using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Request
/// </summary>
public class Request : System.Web.UI.Page
{
    private string result;
    public Request()
    {
        
        if (Session["WebUser"] != null)
        {
            result = "Welcome back, " + Session["WebUser"];
        }
        else
        {
            result = "<a class='login' href='Login.aspx'>login</a>";
        }
    }
    public string ReturnValue   
    {
        get
        {
            return result;
        }
    }
}