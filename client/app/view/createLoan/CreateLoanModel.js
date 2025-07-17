Ext.define('ClientApp.view.createLoan.CreateLoanModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.createloan',
    data: {
        amount: null,
        currency: '',
        type: null,
        periodMonths: 5
    }
}); 