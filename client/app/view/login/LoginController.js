Ext.define('ClientApp.view.login.LoginController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.login',

    decodeJwt: function(token) {
        // Basic JWT decode (no validation, just base64 decode)
        var payload = token.split('.')[1];
        var decoded = atob(payload.replace(/-/g, '+').replace(/_/g, '/'));
        return JSON.parse(decodeURIComponent(escape(decoded)));
    },

    onLoginClick: function(btn) {
        var form = btn.up('form').getForm();
        if (form.isValid()) {
            var values = form.getValues();
            var apiUrl = ClientApp.config.Api.loanServiceBaseUrl + '/auth/login';
            Ext.Ajax.request({
                url: apiUrl,
                method: 'POST',
                jsonData: values,
                success: function(response) {
                    var data = Ext.decode(response.responseText);
                    if (data.token) {
                        localStorage.setItem('isLoggedIn', 'true');
                        localStorage.setItem('token', data.token);
                        // Decode JWT and store role
                        var payload = this.decodeJwt(data.token);

                        console.log(payload);
                            
                        if (payload && payload.role) {
                            localStorage.setItem('role', payload.role);
                        }
                    }
                    Ext.ComponentQuery.query('app-main')[0].getController().onLoginSuccess();
                },
                failure: function(response) {
                    Ext.Msg.alert('Login Failed', 'Invalid credentials or server error');
                },
                scope: this
            });
        }
    }
}); 