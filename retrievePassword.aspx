<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retrievePassword.aspx.cs" Inherits="retrievePassowrd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Retrieve</title>
    <link  rel="stylesheet" href="App_css/login.css" />
</head>
<body>
    <div>
        <a href="index.aspx"><image id="logo" src="images/logo.jpg"></image></a>
    </div>  
    <form id="form1" runat="server">
    <div id="loginView">
  
        <asp:Label ID="Label1" runat="server" Text="Enter your account name"></asp:Label>
        <br />
        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAccount" ErrorMessage="*Please input your account"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="The E-mail of the account"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Please input your E-mail"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="New password"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="*Please input your password"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Confirm the new password"></asp:Label>
        <br />
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirm" ErrorMessage="*Your input doesn't match"></asp:CompareValidator>
        <br />
        <br />
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" />
&nbsp;
      
    </div>
    </form>
</body>
</html>
