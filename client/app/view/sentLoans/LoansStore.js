Ext.define('ClientApp.view.sentLoans.LoansStore', {
    extend: 'Ext.data.Store',
    alias: 'store.loansstore',
    model: 'Ext.data.Model', 
    autoLoad: true,
    proxy: {
        type: 'ajax',
        url: ClientApp.config.Api.loanServiceBaseUrl + '/loan',
        reader: {
            type: 'json',
            rootProperty: ''
        }
    },
    listeners: {
        beforeload: function(store, operation) {
            var token = localStorage.getItem('token');
            if (token) {
                store.getProxy().setHeaders({
                    'Authorization': 'Bearer ' + token
                });
            }
        }
    }
}); 