<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Horizon</title>
    <link rel="stylesheet" href="App_css/style-slider.css"/>
    <link rel="stylesheet" href="App_css/index.css"/>
</head>
<body>
    <form id="form1" runat="server">
       <div>
           <a href="index.aspx"><image id="logo" src="images/logo.jpg"></image></a>
       </div>
       <div id="welcomeBack">
           <%=welcomeBack %>
       </div>
       <div id="nav">
       <div id="navbar">
            <ul id="navOption">
                <li class="active"><a href="gameHome.aspx">More Game</a></li>
                <li class="inactive"><a href="newsHome.aspx" >More News</a></li>
                <li class="inactive"><a href="videoHome.aspx" >More Videos</a></li>
            </ul>
      </div>
      <div id="slider">
            <div id="Slide1" class="zy-Slide">
	            <section>prev</section>
	            <section>next</section>
	            <ul>
		            <li>
                        <asp:ImageButton ID="Image1" runat="server" onclick="Image1_Click"/>
                        </li>
		            <li>
                        <asp:ImageButton ID="Image2" runat="server" onclick="Image2_Click"/>
                        </li>
		            <li>
                        <asp:ImageButton ID="Image3" runat="server" onclick="Image3_Click"/>
   		                </li>
		            <li>
                        <asp:ImageButton ID="Image4" runat="server" onclick="Image4_Click"/>
                        </li>
		            <li>
                        <asp:ImageButton ID="Image5" runat="server" onclick="Image5_Click"/>
                        </li>
	            </ul>
            </div>
        </div>
     <div class="clear"></div>
     </div>
     <div id="video">
         <ul id="videoName">
            <li>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></li>
            <li>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></li>
            <li>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></li>
            <li>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></li>
            <li>
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></li>
         </ul>
     </div>
         <div id="videoVideo">
             <div id="video0">
                 <asp:ImageButton ID="ImageButton1" runat="server" onclick="Image01_Click" Height="278px" Width="378px"/>
            </div>
             <div id="video1" hidden="hidden"> 
                 <asp:ImageButton ID="ImageButton2" runat="server" onclick="Image02_Click" Height="278px" Width="378px"/>
            </div>
             <div id="video2" hidden="hidden">
                 <asp:ImageButton ID="ImageButton3" runat="server" onclick="Image03_Click" Height="278px" Width="378px"/>
            </div>
            <div id="video3" hidden="hidden">
                 <asp:ImageButton ID="ImageButton4" runat="server" onclick="Image04_Click" Height="278px" Width="378px"/>
            </div>
             <div id="video4" hidden="hidden"> 
                 <asp:ImageButton ID="ImageButton5" runat="server" onclick="Image05_Click" Height="278px" Width="378px"/>
            </div>
         </div>   
     <div id="news">
          <div id="navNews">
            <ul id="navNewsOption">
                <li class="active"><a href="#" >Game Walkthrough</a></li>
                <li class="inactive"><a href="#" >Recent Activities</a></li>
                <li class="inactive"><a href="#" >Game Path</a></li>
            </ul>
           </div>
           <div id="NewsType">
               <div id="type0">
                   <div class="newsTitleStyle">
                   <asp:GridView ID="GridViewType1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"  ShowHeader="false" GridLines="Horizontal"  Width="560px" style="border:1px solid #ccc; background: rgba(250,250,250,0.4);">
                       <Columns>
                           <asp:TemplateField HeaderText="NewsTitle"> 
                             <ItemTemplate> 
                                    <div class="newsTitleName"><a runat="server" href='<%#"news.aspx?newsID="+Eval("NewsID") %>'><asp:Label ID="NewsTitle" runat="server" Text='<%#Eval("NewsTitle") %>'></asp:Label></a></div>
                            </ItemTemplate> 
                            </asp:TemplateField>
                       </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 NewsTitle,NewsID FROM News WHERE NewsTypeID = 0"></asp:SqlDataSource>
                   </div>
               </div>
               <div id="type1" hidden="hidden">
                    <div class="newsTitleStyle">
                    <asp:GridView ID="GridViewType2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"  ShowHeader="false" GridLines="Horizontal"  Width="560px" style="border:1px solid #ccc; background: rgba(250,250,250,0.4);">
                       <Columns>
                         <asp:TemplateField HeaderText="NewsTitle"> 
                             <ItemTemplate> 
                                 <div class="newsTitleName"><a runat="server" href='<%#"news.aspx?newsID="+Eval("NewsID") %>'><asp:Label ID="NewsTitle" runat="server" Text='<%#Eval("NewsTitle") %>'></asp:Label></a></div>
                            </ItemTemplate> 
                        </asp:TemplateField> 
                       </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 NewsTitle,NewsID FROM News WHERE NewsTypeID = 1"></asp:SqlDataSource>
                   </div>
               </div>
               <div id="type2" hidden="hidden">
                    <div class="newsTitleStyle">
                    <asp:GridView ID="GridViewType3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3"  ShowHeader="false" GridLines="Horizontal"  Width="560px" style="border:1px solid #ccc; background: rgba(250,250,250,0.4);">
                       <Columns>
                        <asp:TemplateField HeaderText="NewsTitle"> 
                             <ItemTemplate> 
                                 <div class="newsTitleName"><a runat="server" href='<%#"news.aspx?newsID="+Eval("NewsID") %>'><asp:Label ID="NewsTitle"  runat="server" Text='<%#Eval("NewsTitle") %>'></asp:Label></a></div>
                            </ItemTemplate> 
                        </asp:TemplateField>
                       </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 NewsTitle,NewsID FROM News WHERE NewsTypeID = 2"></asp:SqlDataSource>
                   </div>
               </div>
           </div>
      </div>
    </form>
    <script src="App_js/jquery.min.js"></script>
    <script src="App_js/tab.js"></script>
    <script src="App_js/slider.js"></script>
</body>
</html>
