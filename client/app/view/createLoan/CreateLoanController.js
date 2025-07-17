Ext.define('ClientApp.view.createLoan.CreateLoanController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.createloan',

    onSubmitClick: function(btn) {
        var form = btn.up('form').getForm();
        if (form.isValid()) {
            var values = form.getValues();
            // Prepare payload to match LoanCreateRequest
            var payload = {
                amount: parseFloat(values.amount),
                currency: values.currency,
                type: parseInt(values.type)
            };
            if (values.periodMonths) {
                payload.periodMonths = parseInt(values.periodMonths);
            }
            var apiUrl = ClientApp.config.Api.loanServiceBaseUrl + '/loan';
            var token = localStorage.getItem('token');
            Ext.Ajax.request({
                url: apiUrl,
                method: 'POST',
                jsonData: payload,
                headers: {
                    'Authorization': 'Bearer ' + token
                },
                success: function(response) {
                    Ext.Msg.alert('Success', 'Loan created successfully!');
                    form.reset();
                },
                failure: function(response) {
                    Ext.Msg.alert('Error', 'Failed to create loan.');
                }
            });
        }
    }
}); 