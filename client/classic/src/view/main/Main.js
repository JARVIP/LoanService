Ext.define('ClientApp.view.main.Main', {
    extend: 'Ext.container.Container',
    xtype: 'app-main',

    requires: [
        'Ext.plugin.Viewport',
        'Ext.window.MessageBox',
        'ClientApp.view.main.MainController',
        'ClientApp.view.main.MainModel',
        'ClientApp.view.login.Login',
        'ClientApp.view.login.LoginController',
        'ClientApp.view.login.LoginModel',
        'ClientApp.view.createLoan.CreateLoan',
        'ClientApp.view.createLoan.CreateLoanController',
        'ClientApp.view.createLoan.CreateLoanModel',
        'ClientApp.view.sentLoans.SentLoans',
        'ClientApp.view.sentLoans.SentLoansController',
        'ClientApp.view.sentLoans.SentLoansModel',
        'ClientApp.view.editLoan.EditLoan',
        'ClientApp.view.editLoan.EditLoanController',
        'ClientApp.view.editLoan.EditLoanModel',
        'ClientApp.config.Api'
    ],

    controller: 'main',
    viewModel: 'main',

    layout: 'fit',

    items: [],

    initComponent: function() {
        this.callParent(arguments);
        this.showAppropriateView();
    },

    showAppropriateView: function() {
        var isLoggedIn = localStorage.getItem('isLoggedIn') === 'true';
        var role = localStorage.getItem('role');
        this.removeAll(true);
        if (isLoggedIn) {
            var items = [
                {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [
                        { xtype: 'component', flex: 1 },
                        {
                            xtype: 'button',
                            text: 'Logout',
                            handler: 'onLogoutClick',
                            margin: '10 10 0 0',
                            align: 'right'
                        }
                    ]
                }
            ];
            if (role === 'client') {
                items.push({
                    xtype: 'createloan',
                    flex: 1
                });
            } else if (role === 'manager') {
                items.push({
                    xtype: 'sentloans',
                    flex: 1
                });
            }
            this.add({
                xtype: 'container',
                layout: {
                    type: 'vbox',
                    align: 'stretch'
                },
                items: items
            });
        } else {
            this.add({
                xtype: 'loginpage'
            });
        }
    }
});
