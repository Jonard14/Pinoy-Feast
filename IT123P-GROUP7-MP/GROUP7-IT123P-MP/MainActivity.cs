using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;
using Android.Widget;
using Android.Content;
using System.Timers;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

/* IT123P-B54 - MP (Final Exam)
Group 7:
    Jonard Cyrus Francisco
    Zoe Aleczandra Pineda
    Leonard Reshley Tiangsing
    Gerico Tolayba
*/

namespace GROUP7_IT123P_MP
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        ImageView iv;
        TextView dish_title_tv, dish_desc_tv;
        int speed;
        Timer timer;
        System.Random rand;
        string food_category;

        Randomizer randclass; //Random Class

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            iv = FindViewById<ImageView>(Resource.Id.imageView1);
            //iv.SetImageResource(Resource.Drawable.ADOBO);

            iv.LayoutParameters.Height = 600;
            iv.LayoutParameters.Width = 600;

            dish_title_tv = FindViewById<TextView>(Resource.Id.title_tv);
            dish_desc_tv = FindViewById<TextView>(Resource.Id.desc_tv);

            //Calls Randomizer.cs Class
            displayfood(iv, dish_title_tv, dish_desc_tv);
        }

        // Triggers goToNextPage function upon selection of nav item
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            food_category = item.TitleFormatted.ToString(); // stores title of category in string var
            goToNextPage(food_category);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        // Passes the food category into the Food Activity 
        public void goToNextPage(string food_category)
        {
            Intent intent = new Intent(this, typeof(RegionalDishesActivity));
            intent.PutExtra("Category", food_category);
            StartActivity(intent);
        }

        //Displays Content
        public void displayfood(ImageView iv, TextView dish_title_tv, TextView dish_desc_tv) //retrieve data from the database
        {
            DBClass response = new DBClass();
            HttpWebResponse res = response.RetrieveData("search_record.php");
            StreamReader reader = new StreamReader(res.GetResponseStream());
            var result = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            List<string> title = new List<string>();
            List<string> imageFiles = new List<string>(); //empty lists for desc and imgfile
            List<string> desc = new List<string>();

            for (int i = 0; i < root.GetArrayLength(); i++) //loops through the database and assign it in a variable
            {
                var u1 = root[i];

                string searchedname = u1.GetProperty("name").ToString();
                string searchedimgfile = u1.GetProperty("imgfile").ToString();
                string searcheddesc = u1.GetProperty("description").ToString();

                title.Add(searchedname);
                imageFiles.Add(searchedimgfile); //added imgfile and desc in the lists
                desc.Add(searcheddesc);
            }
            string[] titleArray = title.ToArray();
            string[] imgArray = imageFiles.ToArray(); //converted the lists to an array and then assign it in the parameters for randclass
            string[] descArray = desc.ToArray();

            //Calls Randomizer class
            randclass = new Randomizer(iv, dish_title_tv, dish_desc_tv, titleArray, descArray, imgArray);
            //Randomize content when the user opens the app
            randclass.startup();
            //Runs the content randomly every 10 seconds
            randclass.Play();
        }

        

        

        // built-in template functions (ignore)
        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

