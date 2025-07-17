Ext.define('ClientApp.view.sentLoans.SentLoansController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.sentloans',

    init: function() {
        this.reloadLoans();
    },

    reloadLoans: function() {
        var store = this.getView().getStore();
        var token = localStorage.getItem('token');
        store.load({
            headers: {
                'Authorization': 'Bearer ' + token
            }
        });
    },

    onAcceptClick: function(grid, rowIndex) {
        var rec = grid.getStore().getAt(rowIndex);
        Ext.Msg.confirm('Accept Loan', 'Do you really want to accept this loan?', function(choice) {
            if (choice === 'yes') {
                this.sendDecision(rec, true);
            }
        }, this);
    },

    onRejectClick: function(grid, rowIndex) {
        var rec = grid.getStore().getAt(rowIndex);
        Ext.Msg.confirm('Reject Loan', 'Do you really want to reject this loan?', function(choice) {
            if (choice === 'yes') {
                this.sendDecision(rec, false);
            }
        }, this);
    },

    sendDecision: function(rec, isApproved) {
        var token = localStorage.getItem('token');
        var apiUrl = ClientApp.config.Api.loanServiceBaseUrl + '/loan/approve';
        Ext.Ajax.request({
            url: apiUrl,
            method: 'POST',
            jsonData: {
                loanId: rec.get('id'),
                isApproved: isApproved
            },
            headers: {
                'Authorization': 'Bearer ' + token
            },
            success: function() {
                Ext.Msg.alert('Success', 'Loan decision sent.');
                this.reloadLoans();
            },
            failure: function() {
                Ext.Msg.alert('Error', 'Failed to send decision.');
            },
            scope: this
        });
    },

    onEditClick: function(grid, rowIndex) {
        var rec = grid.getStore().getAt(rowIndex);
        this.openEditWindow(rec);
    },

    openEditWindow: function(rec) {
        Ext.create('Ext.window.Window', {
            title: 'Edit Loan',
            modal: true,
            layout: 'fit',
            width: 450,
            items: [{
                xtype: 'editloan',
                viewModel: {
                    type: 'editloan',
                    data: {
                        amount: rec.get('amount'),
                        currency: rec.get('currency'),
                        type: rec.get('type'),
                        periodMonths: rec.get('periodMonths'),
                        id: rec.get('id')
                    }
                }
            }],
            listeners: {
                close: this.reloadLoans,
                scope: this
            }
        }).show();
    }
}); 