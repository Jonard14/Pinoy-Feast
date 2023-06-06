using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

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
        private ToggleButton toggleVisibilityButton;
        private LinearLayout foodContainer, hiddenFoodContainer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.food_content_activity);

            foodContainer = FindViewById<LinearLayout>(Resource.Id.foodContainer);
            hiddenFoodContainer = FindViewById<LinearLayout>(Resource.Id.hiddenFoodContainer);
            toggleVisibilityButton = FindViewById<ToggleButton>(Resource.Id.toggleVisibilityBttn);
            toggleVisibilityButton.CheckedChange += toggleVisibilityButtonCheckedChange;

            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);

            /*
            string[] dish_names = { "Adobo", "Sinigang", "Dinuguan" };
            string[] dish_descs = { "Toyo + Vinegar wieieie", "asim", "best served w/ puto tbh" };
            string[] dish_imgs = { "ADOBO", "SINIGANG", "DINUGUAN" }; // pwede rin gamitin yung dish names.ToUpper instead of making another array for image names
            */
            food_category = Intent.GetStringExtra("Category");
            Toast.MakeText(this, food_category, ToastLength.Short).Show();

            /* DATABASE FUNCTIONS HERE 
             * Get dishes based off of the given category !!
             * yung values sa food_categories ay yung pinapass-in ng goToNextPage na function sa MainActivity
             */

            string[] food_categories = { "Pinoy Classics", "Region I", "Region II", "Region III", "Region IV-A", "Region V", "Region VI", "NCR" };

            DisplayContent(builder);

            /* (Code before connecting to Database)
            for (int i = 0; i < dish_names.Length; i++)
            {
                ImageButton dish_image_button = new ImageButton(this);
                ImageButton hide_dish_button = new ImageButton(this);
                TextView dish_label = new TextView(this);

                // container for each image button + hide button
                RelativeLayout dish_img_bttn_container = new RelativeLayout(this);

                RelativeLayout.LayoutParams container_params = new RelativeLayout.LayoutParams(
                    RelativeLayout.LayoutParams.MatchParent,
                    RelativeLayout.LayoutParams.MatchParent);
                container_params.TopMargin = 50 * (i+1); // Adjusts the top margin 


                dish_img_bttn_container.LayoutParameters = container_params;

                dish_name = dish_names[i];
                dish_desc = dish_descs[i];
                dish_img = dish_imgs[i];

                Dish dish = new Dish(dish_name, dish_desc, dish_img, dish_img_bttn_container, foodContainer, hiddenFoodContainer, dish_image_button, hide_dish_button, dish_label, builder);
                dish.LoadWidgets();

                // Add image buttons and dish label to the containers
                dish_img_bttn_container.AddView(dish_image_button);
                dish_img_bttn_container.AddView(hide_dish_button);
                dish_img_bttn_container.AddView(dish_label);

                foodContainer.AddView(dish_img_bttn_container);
                dish.UpdateContainers(dish_img_bttn_container, foodContainer);
            }
            */
        }

        //Display Content
        public void DisplayContent(AlertDialog.Builder builder)
        {
            //Get data from database
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
                string searchedstatus = u1.GetProperty("status").ToString();

                title.Add(searchedname);
                imageFiles.Add(searchedimgfile); //added imgfile and desc in the lists
                desc.Add(searcheddesc);
            }
            string[] titleArray = title.ToArray();
            string[] imgArray = imageFiles.ToArray(); //converted the lists to an array and then assign it in the parameters for randclass
            string[] descArray = desc.ToArray();

            //Display content
            for (int i = 0; i < titleArray.Length; i++)
            {
                ImageButton dish_image_button = new ImageButton(this);
                ImageButton hide_dish_button = new ImageButton(this);
                TextView dish_label = new TextView(this);

                // container for each image button + hide button
                RelativeLayout dish_img_bttn_container = new RelativeLayout(this);

                RelativeLayout.LayoutParams container_params = new RelativeLayout.LayoutParams(
                    RelativeLayout.LayoutParams.MatchParent,
                    RelativeLayout.LayoutParams.MatchParent);
                container_params.TopMargin = 50 * (i + 1); // Adjusts the top margin 


                dish_img_bttn_container.LayoutParameters = container_params;

                dish_name = titleArray[i];
                dish_desc = descArray[i];
                dish_img = imgArray[i];

                Dish dish = new Dish(dish_name, dish_desc, dish_img, dish_img_bttn_container, foodContainer, hiddenFoodContainer, dish_image_button, hide_dish_button, dish_label, builder);
                dish.LoadWidgets();

                // Add image buttons and dish label to the containers
                dish_img_bttn_container.AddView(dish_image_button);
                dish_img_bttn_container.AddView(hide_dish_button);
                dish_img_bttn_container.AddView(dish_label);

                foodContainer.AddView(dish_img_bttn_container);
                dish.UpdateContainers(dish_img_bttn_container, foodContainer);
            }
        }

        private void toggleVisibilityButtonCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {
                // Show hidden food and hide visible food
                hiddenFoodContainer.Visibility = Android.Views.ViewStates.Visible;
                foodContainer.Visibility = Android.Views.ViewStates.Gone;
            }
            else
            {
                // Show visible food and hide hidden food
                foodContainer.Visibility = Android.Views.ViewStates.Visible;
                hiddenFoodContainer.Visibility = Android.Views.ViewStates.Gone;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}