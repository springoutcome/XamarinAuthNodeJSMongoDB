using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using EDMTDialog;

namespace XamarinAuthNodeJSMongoDB.API
{
    public class APIRequestHelper
    {
        Context context;
        IMyAPI myAPI;

        public APIRequestHelper(Context context, IMyAPI myAPI)
        {
            this.context = context;
            this.myAPI = myAPI;
        }

        public async Task RequestRegisterUserAsync(string email, string name, string password)
        {
            if(String.IsNullOrEmpty(email))
            {
                Toast.MakeText(context, "Email cannot be null or empty", ToastLength.Short).Show();
                return;
            }

            if (String.IsNullOrEmpty(name))
            {
                Toast.MakeText(context, "Name cannot be null or empty", ToastLength.Short).Show();
                return;
            }

            if (String.IsNullOrEmpty(password))
            {
                Toast.MakeText(context, "Password cannot be null or empty", ToastLength.Short).Show();
                return;
            }

            //Create Dialog
            AlertDialog dialog = new EDMTDialogBuilder()
                .SetContext(context)
                .SetMessage("Please wait ..")
                .Build();

            if (!dialog.IsShowing)
                dialog.Show();

            //Create params to POST request
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("email", email);
            data.Add("name", name);
            data.Add("password", password);

            string result = await myAPI.RegisterUser(data);

            Toast.MakeText(context, result, ToastLength.Short).Show();

            if (dialog.IsShowing)
                dialog.Dismiss();
        }

        public async Task RequestLoginUserAsync(string email, string password)
        {
            if (String.IsNullOrEmpty(email))
            {
                Toast.MakeText(context, "Email cannot be null or empty", ToastLength.Short).Show();
                return;
            }

            if (String.IsNullOrEmpty(password))
            {
                Toast.MakeText(context, "Password cannot be null or empty", ToastLength.Short).Show();
                return;
            }

            //Create Dialog
            AlertDialog dialog = new EDMTDialogBuilder()
                .SetContext(context)
                .SetMessage("Please wait ..")
                .Build();

            if (!dialog.IsShowing)
                dialog.Show();

            //Create params to POST request
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("email", email);
            data.Add("password", password);

            string result = await myAPI.LoginUser(data);

            Toast.MakeText(context, result, ToastLength.Short).Show();

            if (dialog.IsShowing)
                dialog.Dismiss();
        }
    }
}