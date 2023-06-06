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
        
        string[] dish_descs = { "Toyo + Suka slay", "asim", "best served w/ puto tbh" };
        string[] dish_imgs = { "ADOBO", "SINIGANG", "DINUGUAN" };//ganito muna for testing pero db talaga kukunin

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
            iv.SetImageResource(Resource.Drawable.ADOBO);

            iv.LayoutParameters.Height = 600;
            iv.LayoutParameters.Width = 600;

            dish_title_tv = FindViewById<TextView>(Resource.Id.title_tv);
            dish_title_tv.Text = dish_imgs[0];

            dish_desc_tv = FindViewById<TextView>(Resource.Id.desc_tv);
            dish_desc_tv.Text = dish_descs[0];

            //Calls Randomizer.cs Class
            randclass = new Randomizer(iv, dish_title_tv, dish_desc_tv, dish_descs, dish_imgs);
            randclass.Play();
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

