<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>login</title>
    <link  rel="stylesheet" href="App_css/login.css" />
</head>
<body>
    <div>
        <a href="index.aspx"><image id="logo" src="images/logo.jpg"></image></a>
    </div>  
    <form id="form1" runat="server">
    <div id="loginView">
    &nbsp;&nbsp;
        <asp:Label ID="lblAccount" runat="server" Text="Account&nbsp;&nbsp;:"></asp:Label>
        &nbsp; &nbsp;
        <asp:TextBox ID="txtAccount" runat="server" ></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAccount" ErrorMessage="RequiredFieldValidator">* Please input your account</asp:RequiredFieldValidator>
        <br />
&nbsp;&nbsp;
        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator">* Please input your password</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:RadioButton ID="radRem" runat="server" Text="Remember me" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
        <div id="bnt">
        <asp:Button ID="bntOK" runat="server" Text="OK" width="60" OnClick="bntOK_Click"/>
        <br />
        </div>
            <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div id="link">
        <asp:HyperLink ID="hlRegister" runat="server" ForeColor="black" NavigateUrl="~/register.aspx">register</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="hlForget" runat="server" ForeColor="black" NavigateUrl="~/retrievePassword.aspx">forget the password?</asp:HyperLink>
        </div>
    </div>
    </form>
</body>
</html>
