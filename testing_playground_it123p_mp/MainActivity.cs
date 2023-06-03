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
using System.Timers;

namespace testing_playground_it123p_mp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout drawerLayout;
        private NavigationView navigationView;
        private RelativeLayout relativeLayout;
        ImageView iv;
        TextView tv;
        int speed;
        Timer timer;
        Random rand;
        string[] dish_descs = { "Toyo + Vinegar wieieie", "asim", "best served w/ puto tbh" };
        string[] dish_imgs = { "ADOBO", "SINIGANG", "DINUGUAN" };//ganito muna for testing pero db talaga kukunin
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
            iv = FindViewById<ImageView>(Resource.Id.imageView1);
            tv = FindViewById<TextView>(Resource.Id.textView1);
            tv.Text = dish_descs[0];
            iv.SetImageResource(Resource.Drawable.ADOBO);
            iv.LayoutParameters.Height = 1200;
            iv.LayoutParameters.Width = 1200;

            

            Play();

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

        public void SetIntervalMode(string n)
        {
            speed = 10000;

        }

        public void Play()
        {
            speed = 10000;
            timer = new Timer();
            timer.Interval = speed;
            timer.Elapsed += displayInfo;
            timer.Start();
        }

        private void displayInfo(object sender, System.Timers.ElapsedEventArgs e)
        {
            rand = new Random();
            int cnt = rand.Next(dish_imgs.Length);


            int resourceId = (int)typeof(Resource.Drawable).GetField(dish_imgs[cnt]).GetValue(null);
            iv.SetImageResource(resourceId);
            iv.LayoutParameters.Height = 1200;
            iv.LayoutParameters.Width = 1200;
           
            tv.Text = dish_descs[cnt];

            throw new NotImplementedException();



        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
