$(function () {
    $.post("App_Code/WSXPL1.ashx", function (data, status) { //通过WSXPL1.ashx获取所有的评论内容
        if (status == "success") {
            var result = data.split("$");   //按照$分割字符串
            for (var i = 0; i < result.length - 1; i++) {
                var msg = result[i];
                var line = msg.split("|");      //按照|分割字符串
                var pinglun = $("<li class='PersonReview'>UserAccount：" + line[0] + " Review time：" + line[2] + "<br> Review Content：" + line[1] + " </li>");
                $("#pinglunlist").append(pinglun);  //把得到的评论结果追加到ul元素上
            }
        }
        else {
            alert("warning: ajax！");
        }
    })

    $("#btnpinglun").click(function () {    //设置btn事件
        var msg = $("#msg").val(); 
        $.post("App_Code/WSXPL.ashx", { "msg": msg }, function (data, status) {
            if (status == "success") {
                if (data == "ok") {
                    $.post("WSXPL1.ashx", function (data, status) { //为了实现评论的时候评论内容会自动的添加到ul上
                        if (status == "success") {
                            var result = data.split("$");
                            var msg = result[result.length - 2];        //获取最后一条评论
                            var line = msg.split("|");
                            var pinglun = $("<li class='PersonReview'>UserAccount：" + line[0] + " Review time：" + line[2] + "<br> Review Content：" + line[1] + " </li>");
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