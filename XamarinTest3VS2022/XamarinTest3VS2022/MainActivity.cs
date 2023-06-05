using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace XamarinTest3VS2022
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btn_getdata;
        TextView title, imgfile, desc, status;

        DBClass dbClass = new DBClass();
        JsonElement root;

        HttpWebResponse response;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btn_getdata = FindViewById<Button>(Resource.Id.btn_getdata);
            btn_getdata.Click += Data;

            title = FindViewById<TextView>(Resource.Id.tv_title);
        }

        public void Data (object sender, EventArgs e)
        {
            /*
             Jonard NOTE: Cannot place this to another class to return the JsonElement Value
             Why? Because it returns a dispose JsonDocument which causes an error
            Check my DBClass at RetrieveData function for detail
            */
            response = dbClass.RetrieveData("search_record.php");
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            for (int i = 0; i < root.GetArrayLength(); i++)
            {
                var u1 = root[i];

                string searchedname = u1.GetProperty("name").ToString(); //Name of food
                string searchedimgfile = u1.GetProperty("imgfile").ToString(); //Filename of food
                string searcheddesc = u1.GetProperty("description").ToString(); //Description of food
                string searchedstatus = u1.GetProperty("status").ToString(); //Status to show or hide content (note: db val is set to boolean 0 or 1)

                //returns multi-line text
                title.Text = title.Text + "\n" + searchedname + "\n" + searchedimgfile + "\n" + searcheddesc + "\n" + searchedstatus;
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}