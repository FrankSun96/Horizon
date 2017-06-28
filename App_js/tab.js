$(document).ready(function(){
    $('#navOption li').mousemove(function(){
        var number = $(this).index();
        $('#navOption li').removeClass('inactive').addClass('active');
        $('#navOption li').not(this).removeClass('active').addClass('inactive');
    });
     $('#videoName li').mousemove(function(){
        var number1 = $(this).index();
        for(var i = 0; i < 5; i++){
            if(number1 != i){
                $('#video' + i).hide();
             }else{
                $('#video' + i).show();
            }
        }
     });
     $('#navNewsOption li').mousemove(function () {
         var number2 = $(this).index();
         $('#navNewsOption li').removeClass('inactive').addClass('active');
         $('#navNewsOption li').not(this).removeClass('active').addClass('inactive');
         for (var i = 0; i < 3; i++) {
             if (number2 != i) {
                 $('#type' + i).hide();

             } else {
                 $('#type' + i).show();
                
             }
         }
     });
});
