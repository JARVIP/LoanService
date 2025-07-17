Ext.define('ClientApp.view.createLoan.CreateLoan', {
    extend: 'Ext.form.Panel',
    xtype: 'createloan',

    controller: 'createloan',
    viewModel: 'createloan',

    title: 'Create Loan',
    bodyPadding: 20,
    width: 400,
    layout: {
        type: 'vbox',
        align: 'center',
        pack: 'center'
    },
    items: [
        {
            xtype: 'numberfield',
            fieldLabel: 'Amount',
            name: 'amount',
            allowBlank: false,
            minValue: 0.01,
            bind: '{amount}',
            labelAlign: 'top',
            width: 300
        },
        {
            xtype: 'combobox',
            fieldLabel: 'Currency',
            name: 'currency',
            store: [
                { value: 'USD', name: 'USD' },
                { value: 'EUR', name: 'EUR' },
                { value: 'GEL', name: 'GEL' }
            ],
            queryMode: 'local',
            displayField: 'name',
            valueField: 'value',
            allowBlank: false,
            bind: '{currency}',
            labelAlign: 'top',
            width: 300
        },
        {
            xtype: 'combobox',
            fieldLabel: 'Type',
            name: 'type',
            store: [
                { value: 0, name: 'Quick' },
                { value: 1, name: 'Auto' },
                { value: 2, name: 'Installment' }
            ],
            queryMode: 'local',
            displayField: 'name',
            valueField: 'value',
            allowBlank: false,
            bind: '{type}',
            labelAlign: 'top',
            width: 300
        },
        {
            xtype: 'numberfield',
            fieldLabel: 'Period (months)',
            name: 'periodMonths',
            allowBlank: true,
            minValue: 1,
            maxValue: 120,
            bind: '{periodMonths}',
            labelAlign: 'top',
            width: 300
        },
        {
            xtype: 'button',
            text: 'Submit',
            formBind: true,
            handler: 'onSubmitClick',
            margin: '20 0 0 0',
            width: 300
        }
    ]
}); 