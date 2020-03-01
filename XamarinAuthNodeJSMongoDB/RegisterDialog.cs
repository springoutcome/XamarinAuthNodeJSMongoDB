using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using XamarinAuthNodeJSMongoDB.API;

namespace XamarinAuthNodeJSMongoDB
{
    public class RegisterDialog : AlertDialog
    {

        APIRequestHelper apiRequestHelper;

        public RegisterDialog(Context context):base(context)
        {

        }

        public RegisterDialog(Context context, APIRequestHelper apiRequestHelper) : base(context)
        {
            this.apiRequestHelper = apiRequestHelper;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register_layout);

            Button btn_cancel = FindViewById<Button>(Resource.Id.btn_cancel);
            btn_cancel.Click += delegate
            {
                Dismiss();
            };

            EditText edt_login_email = FindViewById<EditText>(Resource.Id.edt_email);
            EditText edt_login_name = FindViewById<EditText>(Resource.Id.edt_name);
            EditText edt_login_password = FindViewById<EditText>(Resource.Id.edt_password);

            Button btn_register = FindViewById<Button>(Resource.Id.btn_register);
            btn_register.Click += async delegate
            {
                await apiRequestHelper.RequestRegisterUserAsync(edt_login_email.Text.ToString(),
                    edt_login_name.Text.ToString(),
                    edt_login_password.Text.ToString());
            };
        }
    }
}