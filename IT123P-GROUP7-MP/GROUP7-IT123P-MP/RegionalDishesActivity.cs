using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GROUP7_IT123P_MP
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]

    public class RegionalDishesActivity : Activity
    {
        // we can probs get the values from the database and put them in arrays o multi-dimensional kung di tatamarin
        // GET NUMBER OF FIELDS IN THE TABLE
        // PUT FIELDS IN ARRAY
        // GET NUMBER OF ITEMS IN THE ARRAY

        private string dish_img, dish_name, dish_desc;
        private string food_category;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.food_content_activity);

            LinearLayout foodContainer = FindViewById<LinearLayout>(Resource.Id.foodContainer);
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);

            string[] dish_names = { "Adobo", "Sinigang", "Dinuguan" };
            string[] dish_descs = { "Toyo + Vinegar wieieie", "asim", "best served w/ puto tbh" };
            string[] dish_imgs = { "ADOBO", "SINIGANG", "DINUGUAN" }; // pwede rin gamitin yung dish names.ToUpper instead of making another array for image names
            

            food_category = Intent.GetStringExtra("Category");
            Toast.MakeText(this, food_category, ToastLength.Short).Show();

            /* DATABASE FUNCTIONS HERE 
             * Get dishes based off of the given category !!
             * yung values sa food_categories ay yung pinapass-in ng goToNextPage na function sa MainActivity
             */
            string[] food_categories = { "Pinoy Classics", "Region I", "Region II", "Region III", "Region IV-A", "Region V", "Region VI", "NCR" };

            for (int i = 0; i < dish_names.Length; i++)
            {
                dish_name = dish_names[i];
                dish_desc = dish_descs[i];
                dish_img = dish_imgs[i];

                ImageButton imageButton = new ImageButton(this);

                TextView label = new TextView(this);

                Dish dish = new Dish(dish_name, dish_desc, dish_img, imageButton, label, builder);
                dish.LoadWidgets();

                // Set layout parameters to match the parents'
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.MatchParent,
                    300);
                imageButton.LayoutParameters = layoutParams;
                label.LayoutParameters = layoutParams;

                // Add image button and label to the container
                foodContainer.AddView(imageButton);
                foodContainer.AddView(label);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}