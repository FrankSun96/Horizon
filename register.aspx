<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reigister</title>
    <script src="App_js/jquery.min.js"></script>
    <link  rel="stylesheet" href="App_css/login.css" />
</head>
<body>
       <div>
           <a href="index.aspx"><image id="logo" src="images/logo.jpg"></image></a>
       </div> 
    <form id="form1" runat="server">
    <div id="reView">
   
        <asp:Label ID="lblNewAccount" runat="server" Text="Create a  account name"></asp:Label>
        <br />
        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccount" ErrorMessage="*Please input your account"></asp:RequiredFieldValidator>
        &nbsp;<br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Account Type"></asp:Label>
        <asp:RadioButtonList ID="radUserType" runat="server" AutoPostBack="True" Width="126px">
            <asp:ListItem Selected="True" Value="2">General user</asp:ListItem>
            <asp:ListItem Value="1">Publisher</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="lblIPC" runat="server" Text="Input the IPC of your company:" ></asp:Label>
        <br />
        <asp:TextBox ID="txtIPC" runat="server" Enabled="False"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIPC" Enabled="False" ErrorMessage="*Please input your IPC"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Choose a nickname"></asp:Label>
        <br />
        <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNickname" ErrorMessage="*Please input your nickname"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Choose a password"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*Please input your password"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblReenter" runat="server" Text="Re-enter password"></asp:Label>
        <br />
        <asp:TextBox ID="txtReenter" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtReenter" ErrorMessage="*Your input doesn't match"></asp:CompareValidator>
        <br />
        <br /><asp:Label ID="lblEmail" runat="server" Text="Your current email address"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Please input your email"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <br />
        <p>Please review the agreement(s) below and agree by selecting the checkbox at the bottom of the page. <br />You must agree with the terms of these agreements to continue.</p>
        <p>
            <textarea id="TextArea1" name="S1">HORIZEN® SUBSCRIBER AGREEMENT</textarea></p>
   
        <asp:CheckBox ID="chbAgree" runat="server" Text="I agree with it and I am greater than 13 years old" Checked="false"/>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create my account" hidden="false" />
    </div>
         </form>
    <script src="App_js/register.js"></script>
</body>
</html>
