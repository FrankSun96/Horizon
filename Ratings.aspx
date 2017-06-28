<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ratings.aspx.cs" Inherits="Ratings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style type="text/css">
    body{
        background-color:black;
    } 
.ratingStar 
{ 
    font-size: 0pt; 
    width: 13px; 
    height: 12px; 
    margin: 0px; 
    padding: 0px; 
    cursor: pointer; 
    display: block; 
    background-repeat: no-repeat; 
} 

.waitingRatingStar /*normal mode empty style*/ 
{ 
    background-image: url(Rating_default.gif); 
} 

.filledRatingStar /*normal mode filled style*/ 
{ 
    background-image: url(Rating_normal.gif); 
} 

.emptyRatingStar /*readonly mode empty style*/ 
{ 
    background-image: url(Rating_empty.gif); 
}
</style>  

<body> 
    <form id="form1" runat="server"> 
    <div> 
        <asp:ScriptManager ID="ScriptManager1" runat="server" > 
        </asp:ScriptManager> 
        <asp:Rating ID="RatingRate" runat="server" BehaviorID="RatingRate1" MaxRating="5"  
            StarCssClass="ratingStar" WaitingStarCssClass="waitingRatingStar" 
            FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" 
            AutoPostBack="false" OnClick="SubmitRating" ></asp:Rating>
    </div> 
    </form> 
</body> 
</html>
