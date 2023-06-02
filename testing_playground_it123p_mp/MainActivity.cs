using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.Navigation;
using Android.Content;

namespace testing_playground_it123p_mp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout drawerLayout;
        private NavigationView navigationView;
        private RelativeLayout relativeLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            relativeLayout = FindViewById<RelativeLayout>(Resource.Id.main_content);
            navigationView = FindViewById<NavigationView>(Resource.Id.navigation_view);
            LinearLayout linear = FindViewById<LinearLayout>(Resource.Id.linearlayout);

            Button btnActivity1 = navigationView.FindViewById<Button>(Resource.Id.btnActivity1);
            Button btnActivity2 = navigationView.FindViewById<Button>(Resource.Id.btnActivity2);
            Button btntestlang = relativeLayout.FindViewById<Button>(Resource.Id.btntest);

            btnActivity1.Click += this.goToNextPage;
            btnActivity2.Click += this.goToNextPage;
            btntestlang.Click += this.goToNextPage;

        }

        public void goToNextPage(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegionalDishesActivity));
            StartActivity(intent);
            drawerLayout.CloseDrawers();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
