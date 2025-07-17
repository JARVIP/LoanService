Ext.define('ClientApp.view.login.Login', {
    extend: 'Ext.form.Panel',
    xtype: 'loginpage',

    controller: 'login',
    viewModel: 'login',

    title: 'Login',
    bodyPadding: 20,
    width: 340,
    layout: {
        type: 'vbox',
        align: 'center',
        pack: 'center'
    },
    defaultType: 'textfield',
    items: [
        {
            fieldLabel: 'Email',
            name: 'email',
            allowBlank: false,
            bind: '{email}',
            labelAlign: 'top',
            width: 300
        },
        {
            fieldLabel: 'Password',
            name: 'password',
            inputType: 'password',
            allowBlank: false,
            bind: '{password}',
            labelAlign: 'top',
            width: 300
        },
        {
            xtype: 'button',
            text: 'Login',
            formBind: true,
            handler: 'onLoginClick',
            margin: '20 0 0 0',
            width: 300
        }
    ]
}); 