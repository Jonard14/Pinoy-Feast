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
using Android.Graphics;

namespace testing_playground_it123p_mp
{
    internal class Dish
    {
        private string name, desc, img;
        private ImageButton img_bttn;
        private TextView label_tv;
        private Android.App.AlertDialog.Builder modal_builder;

        public Dish(string dish_name, string dish_desc, string dish_img, ImageButton dish_img_bttn, TextView dish_label_tv, Android.App.AlertDialog.Builder modal)
        {
            name = dish_name;
            desc = dish_desc;
            img = dish_img;
            img_bttn = dish_img_bttn;
            label_tv = dish_label_tv;
            modal_builder = modal; // for creating the pop-up message with food desc
        }

        // for loading in the widgets 
        public void LoadWidgets()
        {
            int resourceId = (int)typeof(Resource.Drawable).GetField(img).GetValue(null);

            img_bttn.SetImageResource(resourceId);
            img_bttn.SetBackgroundColor(Color.Transparent);
            img_bttn.Click += ImageButton_Click;

            label_tv.Text = name;
            label_tv.Gravity = GravityFlags.CenterHorizontal;
            label_tv.SetPadding(0, 0, 0, 100);
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            // for pop-up modal
            modal_builder.SetTitle(name);
            modal_builder.SetMessage(desc);


            // optional buttons sa pop-up 
            modal_builder.SetPositiveButton("OK", (sender, args) =>
            {
                // Handle OK button click
            });

            modal_builder.SetNegativeButton("Cancel", (sender, args) =>
            {
                // Handle Cancel button click
            });

            Android.App.AlertDialog dialog = modal_builder.Create();
            dialog.Show();
        }
    }
}