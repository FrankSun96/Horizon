<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsHome.aspx.cs" Inherits="newsHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>newsHome</title>
    <script src="App_js/jquery.min.js"></script>
    <link rel="stylesheet" href="App_css/gameHome.css"/>
    <link rel="stylesheet" href="App_css/newsHome.css"/>
</head>
<body>
    <form id="form1" runat="server">
       <div>
           <a href="index.aspx"><image id="logo" src="images/logo.jpg"></image></a>
       </div>
    <div id="welcomeBack">
        <%=welcomeBack %>
     </div>
     <div id="tab">
     <div id="main"> 
              <div id="search">
                    <table>
                    <tr>
                    <td>
                        <asp:Label ID="lb" runat="server" Text="Name of Game"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="SearchName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="PagerBtnCommand_OnClick" CommandName="search" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Order by"></asp:Label>
                        <asp:DropDownList ID="orderBy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="orderBy_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="count">Most Popular</asp:ListItem>
                            <asp:ListItem Value="Date">Updated</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                    </tr>
                    </table>
              </div>
              <div id="gridView"> 
                 <asp:GridView ID="UserGridView" runat="server"  AutoGenerateColumns="false" Width="800px" style="border:1px solid #ccc; background: rgba(250,250,250,0.4); "  ShowHeader="false" GridLines="Horizontal"> 
                    <Columns> 
                    <asp:TemplateField HeaderText="NewsTitle"> 
                    <ItemTemplate> 
                        <div id="newsName"><a runat="server" href='<%#"news.aspx?newsID="+Eval("NewsID") %>'><asp:Label ID="NewsTitle" runat="server" Text='<%#Eval("NewsTitle") %>'></asp:Label></a></div> 
                    </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="NewsDate"> 
                    <ItemTemplate> 
                       <a runat="server" href='<%#"news.aspx?newsID="+Eval("NewsID") %>'><asp:Label ID="NewsDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label></a> 
                    </ItemTemplate> 
                    </asp:TemplateField> 
                    </Columns> 
                    </asp:GridView> 
                </div> 
                <div id="page"> 
        <table> 
         <tr> 
         <td> 
        <asp:Label ID="lbcurrentpage1" runat="server" Text="Current page:"></asp:Label> 
        <asp:Label ID="lbCurrentPage" runat="server" Text=""></asp:Label> 
        <asp:Label ID="lbFenGe" runat="server" Text="/"></asp:Label> 
        <asp:Label ID="lbPageCount" runat="server" Text=""></asp:Label> 
        </td> 
         <td> 
         <asp:Label ID="recordscount" runat="server" Text="Total games:"></asp:Label> 
          <asp:Label ID="lbRecordCount" runat="server" Text=""></asp:Label> 
        </td> 
        <td> 
        <asp:Button ID="Fistpage" runat="server" CommandName="" Text="The first page" OnClick="PagerBtnCommand_OnClick" /> 
        <asp:Button ID="Prevpage" runat="server" CommandName="prev" Text="<" 
                OnClick="PagerBtnCommand_OnClick" /> 
        <asp:Button ID="Nextpage" runat="server" CommandName="next" Text=">" OnClick="PagerBtnCommand_OnClick" /> 
        <asp:Button ID="Lastpage" runat="server" CommandName="last" Text="The last page" 
               key="last" OnClick="PagerBtnCommand_OnClick" /> 
        </td> 
        <td> 
        <asp:Label ID="lbjumppage" runat="server" Text="jump to page:"></asp:Label> 
        <asp:TextBox ID="GotoPage" runat="server" Width="25px"></asp:TextBox> 
        <asp:Button ID="Jump" runat="server" Text="Jump" CommandName="jump" OnClick="PagerBtnCommand_OnClick" /> 
        </td> 
        </tr> 
        </table> 
        </div> 
        </div> 
        </div>
    <div id="tagChoice0">
        <p>The tag you can seleted</p>
        <asp:RadioButtonList ID="selectedTag" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NewsTypeName" DataValueField="NewsTypeID" OnSelectedIndexChanged="SelectedTag_SelectedIndexChanged">
        </asp:RadioButtonList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT NewsTypeName, NewsTypeID FROM NewsType"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
