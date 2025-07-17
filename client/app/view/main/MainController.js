/**
 * This class is the controller for the main view for the application. It is specified as
 * the "controller" of the Main view class.
 */
Ext.define('ClientApp.view.main.MainController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.main',

    onItemSelected: function (sender, record) {
        Ext.Msg.confirm('Confirm', 'Are you sure?', 'onConfirm', this);
    },

    onConfirm: function (choice) {
        if (choice === 'yes') {
            //
        }
    },

    onLoginSuccess: function() {
        // Refresh the main view to show the list page
        this.getView().showAppropriateView();
    },

    onLogoutClick: function() {
        localStorage.removeItem('isLoggedIn');
        localStorage.removeItem('token'); // if you store JWT
        localStorage.removeItem('role'); // if you store role
        this.getView().showAppropriateView();
    }
});
