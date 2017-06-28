<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>news></title>
         <link rel="stylesheet" href="App_css/news.css"/>
</head>
<body>
     <div>
           <a href="index.aspx"><image id="logo" src="images/logo.jpg"></image></a>
     </div>
     <div id="welcomeBack">
           <%=welcomeBack %>
      </div>
    <form id="form1" runat="server">
    <div id = "news">
        <asp:Label ID="newsTitle" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="newsDate" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="newsUserAccount" runat="server" Text="Label"></asp:Label>
        <div id ="newscontent">
        <asp:Image ID="newImg" runat="server" />
        <asp:Label ID="newsContent" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
