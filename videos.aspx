<%@ Page Language="C#" AutoEventWireup="true" CodeFile="videos.aspx.cs" Inherits="videos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>videos</title>
    <link rel="stylesheet" type="text/css" href="App_css/videos.css">
</head>
<body>
       <div>
           <a href="index.aspx"><image id="logo" src="images/logo.jpg"></image></a>
       </div>
       <div id="welcomeBack">
           <%=welcomeBack %>
       </div>
    <form id="form1" runat="server">
    <div id="A">
        <div id="B">
        <asp:Label ID="VideoName" runat="server" Text="Label"></asp:Label></div>
        <div id="C">
        <asp:Label ID="UserAccount" runat="server" Text="Label"></asp:Label></div>
        <div id="D">
        <asp:Label ID="Date" runat="server" Text="Label"></asp:Label></div>
        <div id="E">
        <div id="F">
        <div id="video_content" runat="server" style=""></div></div>
        <div id="G">
        <asp:Label ID="Introduction" runat="server" Text="Label"></asp:Label></div>
        </div>
    </div>
    </form>
</body>
</html>
