Ext.define('ClientApp.view.editLoan.EditLoanController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.editloan',

    onSaveClick: function(btn) {
        var form = btn.up('form').getForm();
        var vm = this.getView().getViewModel();
        var id = vm.get('id');
        if (form.isValid() && id) {
            var values = form.getValues();
            var payload = {
                amount: parseFloat(values.amount),
                currency: values.currency,
                type: parseInt(values.type)
            };
            if (values.periodMonths) {
                payload.periodMonths = parseInt(values.periodMonths);
            }
            var apiUrl = ClientApp.config.Api.loanServiceBaseUrl + '/loan/' + id;
            var token = localStorage.getItem('token');
            Ext.Ajax.request({
                url: apiUrl,
                method: 'PUT',
                jsonData: payload,
                headers: {
                    'Authorization': 'Bearer ' + token
                },
                success: function(response) {
                    Ext.Msg.alert('Success', 'Loan updated successfully!');
                    btn.up('window') ? btn.up('window').close() : btn.up('form').close && btn.up('form').close();
                },
                failure: function(response) {
                    Ext.Msg.alert('Error', 'Failed to update loan.');
                }
            });
        }
    }
}); 