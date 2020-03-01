using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refit;


namespace XamarinAuthNodeJSMongoDB.API
{
    public interface IMyAPI
    {
        [Post("/login")]
        Task<string> LoginUser([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

        [Post("/register")]
        Task<string> RegisterUser([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);
    }
}