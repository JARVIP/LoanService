Ext.define('ClientApp.view.sentLoans.SentLoans', {
    extend: 'Ext.grid.Panel',
    xtype: 'sentloans',

    controller: 'sentloans',
    viewModel: 'sentloans',

    title: 'Sent Loans',
    width: '100%',
    height: '100%',
    store: {
        type: 'loansstore'
    },
    columns: [
        { text: 'ID', dataIndex: 'id', width: 50 },
        { text: 'Amount', dataIndex: 'amount', flex: 1 },
        { text: 'Currency', dataIndex: 'currency', flex: 1 },
        { text: 'Type', dataIndex: 'type', flex: 1 },
        { text: 'Period', dataIndex: 'periodMonths', flex: 1 },
        { text: 'Status', dataIndex: 'status', flex: 1 },
        {
            xtype: 'actioncolumn',
            width: 120,
            items: [
                {
                    iconCls: 'x-fa fa-check',
                    tooltip: 'Accept',
                    handler: 'onAcceptClick'
                },
                {
                    iconCls: 'x-fa fa-times',
                    tooltip: 'Reject',
                    handler: 'onRejectClick'
                },
                {
                    iconCls: 'x-fa fa-edit',
                    tooltip: 'Edit',
                    handler: 'onEditClick'
                }
            ]
        }
    ]
}); 