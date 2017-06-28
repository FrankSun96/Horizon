<%@ Page Language="C#" AutoEventWireup="true" CodeFile="games.aspx.cs" Inherits="games"  ValidateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>games</title>
    <link rel="stylesheet" href="App_css/games.css"/>
    <script src="App_js/jquery-1.4.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $.post("WSXPL1.ashx", function (data, status) { //通过WSXPL1.ashx获取所有的评论内容
                if (status == "success") {
                    var result = data.split("$");   //按照$分割字符串
                    for (var i = 0; i < result.length - 1; i++) {
                        var msg = result[i];
                        var line = msg.split("|");      //按照|分割字符串
                        var pinglun = $("<div>UserAccount：" + line[0] + " Review time：" + line[2] + "<br><div class='PersonReview'> " + line[1] + " </div></div><br><br>");
                        $("#pinglunlist").append(pinglun);  //把得到的评论结果追加到ul元素上
                    }
                }
                else {
                    alert("warning: ajax！");
                }
            })
            $("#btnpinglun").click(function () {    //设置btn事件
                var msg = $("#msg").val().replace(/\n/g, '_@').replace(/\r/g, '_#');
                msg = msg.replace(/_#_@/g, '<br/>');//IE7-8
                msg = msg.replace(/_@/g, '<br/>');//IE9、FF、chrome
                msg = msg.replace(/\s/g, '&nbsp;');//空格处理
                var ui = $("#UIRatingRate").
                $.post("WSXPL.ashx", { "msg": msg ,""}, function (data, status) {
                    if (status == "success") {
                        if (data == "ok") {
                            $.post("WSXPL1.ashx", function (data, status) { //为了实现评论的时候评论内容会自动的添加到ul上
                                if (status == "success") {
                                    var result = data.split("$");
                                    var msg = result[result.length - 2];        //获取最后一条评论
                                    var line = msg.split("|");
                                    var pinglun = $("<div>UserAccount：" + line[0] + " Review time：" + line[2] + "<br><div class='PersonReview'> " + line[1] + " </div></div><br><br>");
                                    $("#pinglunlist").append(pinglun);      //把最后一条评论追加到ul上
                                }
                                else {
                                    alert("warning: ajax！");
                                }
                            })
                        }
                    }
                })
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <div>
           <a href="index.aspx"><image id="logo" src="images/logo.jpg"></image></a>
       </div>
    <div id="welcomeBack">
        <%=welcomeBack %>
    </div>
    <div id="gameMain">
        <div id="gameName">
            <asp:Label ID="GameName" runat="server" ></asp:Label> 
        </div>
        <div id="up">
            <div id="video">
                <div id="video_content" runat="server" style=""></div>
            </div>
            <div id="info">
                <div id="ImageGameD">
                    <asp:Image ID="ImageGame" runat="server"  height="225px" width="400px"/>
                </div>
                <div id="introD">
                    <asp:Label ID="Introduction" runat="server"  ></asp:Label>
                </div>
                <div id="typeD">
                    <asp:Label ID="Type" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="clear"></div>
        <div id="down">
            <div id="review">
                <textarea id="msg" runat="server"></textarea>&nbsp;
                <input id="btnpinglun" type="button" value="submit" runat="server"/></div>
            <div id="reviewList">
                 <ul id="pinglunlist"></ul>
            </div>    
            <div id="down_right_info">
                <div id="pub">
                    Publisher:
                    <br><br>
                    <asp:Label ID="publisher" runat="server" ></asp:Label>
                </div>
                <div id="conf">
                    Recommended Configuration:
                    <br><br>
                    <asp:Label ID="Configuration" runat="server"></asp:Label>
                </div>
                
            </div>
        </div>   
    </div>
    </form>
</body>
</html>
