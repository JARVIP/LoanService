Ext.define('Client.view.Main', {
    extend: 'Ext.Container',
    xtype: 'app-main',
    requires: [
        'ClientApp.view.login.Login'
    ],
    layout: 'center',
    items: [
        {
            xtype: 'loginform',
            width: 320,
            height: 300
        }
    ]
}); 