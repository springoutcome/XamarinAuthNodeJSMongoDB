using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using XamarinAuthNodeJSMongoDB.API;
using Refit;

namespace XamarinAuthNodeJSMongoDB
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView txt_create_account;
        Button btn_login;
        EditText edt_email, edt_password;
        IMyAPI myAPI;
        APIRequestHelper apiRequestHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Create API
            myAPI = RestService.For<IMyAPI>("http://10.0.2.2:3000");

            apiRequestHelper = new APIRequestHelper(this, myAPI);

            edt_email = FindViewById<EditText>(Resource.Id.edt_email);
            edt_password = FindViewById<EditText>(Resource.Id.edt_password);

            btn_login = FindViewById<Button>(Resource.Id.btn_login);
            btn_login.Click += async delegate
            {
                await apiRequestHelper.RequestLoginUserAsync(edt_email.Text.ToString(), edt_password.Text.ToString());
            };

            txt_create_account = FindViewById<TextView>(Resource.Id.txt_create_account);
            txt_create_account.Click += delegate
            {
                RegisterDialog dialog = new RegisterDialog(this, apiRequestHelper);
                dialog.Show();
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}