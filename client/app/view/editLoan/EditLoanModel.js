Ext.define('ClientApp.view.editLoan.EditLoanModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.editloan',
    data: {
        amount: null,
        currency: '',
        type: null,
        periodMonths: 5,
        id: null
    }
}); 