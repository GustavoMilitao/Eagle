$('#login-form').submit(function () {
    $.ajax({
        type: 'POST',
        url: '/Login',
        data: {
            user: $('#user').val(),
            senha: $('#password').val(),
            keepLogged: $('#keep-logged').prop('checked') 
        }, 
        success: function (data){

        }
    });
});