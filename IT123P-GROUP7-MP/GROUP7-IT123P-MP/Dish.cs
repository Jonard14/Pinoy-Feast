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

namespace GROUP7_IT123P_MP
{
    internal class Dish
    {
        private string name, desc, img;
        private bool hidden_status = false, first_trigger=true;
        private ImageButton img_bttn, img_hide_bttn;
        private TextView label_tv;
        private LinearLayout hidden_dishes_page, visible_dishes_page;
        private RelativeLayout img_bttn_container;
        private Android.App.AlertDialog.Builder modal_builder;

        public Dish(string dish_name, string dish_desc, string dish_img, RelativeLayout dish_img_container, LinearLayout food_container, LinearLayout hidden_dishes_layout, ImageButton dish_img_bttn,ImageButton dish_hide_bttn, TextView dish_label_tv, Android.App.AlertDialog.Builder modal)
        {
            name = dish_name;
            desc = dish_desc;
            img = dish_img;
            img_bttn = dish_img_bttn;
            img_hide_bttn = dish_hide_bttn;
            label_tv = dish_label_tv;
            img_bttn_container = dish_img_container;
            visible_dishes_page = food_container;
            hidden_dishes_page = hidden_dishes_layout;
            modal_builder = modal; // for creating the pop-up message with food desc
        }

        // for loading in the widgets 
        public void LoadWidgets()
        {
            int resourceId = (int)typeof(Resource.Drawable).GetField(img).GetValue(null);
            
            // Set layout parameters to match the parents'
            RelativeLayout.LayoutParams imgButtonLayoutParams = new RelativeLayout.LayoutParams(650, 300);
            imgButtonLayoutParams.AddRule(LayoutRules.CenterHorizontal);
            imgButtonLayoutParams.AddRule(LayoutRules.AlignParentTop);

            img_bttn.SetImageResource(resourceId);
            img_bttn.SetBackgroundColor(Color.Transparent);
            img_bttn.Click += ImageButton_Click;
            img_bttn.LayoutParameters = imgButtonLayoutParams;

            // hide button attributes
            RelativeLayout.LayoutParams hideButtonLayoutParams = new RelativeLayout.LayoutParams(100, 90);
            hideButtonLayoutParams.AddRule(LayoutRules.AlignRight, img_bttn.Id);
            hideButtonLayoutParams.AddRule(LayoutRules.AlignTop, img_bttn.Id);
            img_hide_bttn.LayoutParameters = hideButtonLayoutParams;

            img_hide_bttn.SetImageResource(Resource.Drawable.eye_open);
            img_hide_bttn.SetBackgroundColor(new Android.Graphics.Color(0, 0, 0, 0));
            img_hide_bttn.Click += this.UpdateHiddenStatus;

            // label attributes
            RelativeLayout.LayoutParams dishLabelParams = new RelativeLayout.LayoutParams(
                RelativeLayout.LayoutParams.WrapContent,
                RelativeLayout.LayoutParams.WrapContent); 
            dishLabelParams.AddRule(LayoutRules.CenterHorizontal);
            dishLabelParams.AddRule(LayoutRules.AlignBottom, img_bttn.Id);

            label_tv.Text = name;
            label_tv.Gravity = GravityFlags.CenterHorizontal;
            label_tv.SetTextColor(Android.Graphics.Color.White);

            label_tv.LayoutParameters = dishLabelParams;
        }

        // updates main image button container after adding image buttons to it
        public void UpdateContainers(RelativeLayout updated_img_button_container, LinearLayout main_food_container)
        {
            img_bttn_container = updated_img_button_container;
            img_bttn_container.LayoutDirection = Android.Views.LayoutDirection.Rtl;

            visible_dishes_page = main_food_container;
        }

        public void UpdateHiddenStatus(object sender, EventArgs e)
        {    
            string res="";
            int status;
            //pass name and status
            DBClass response = new DBClass();

            // if it is the first time the hide button is clicked, execute:
            //0=default; 1=Hidden
            if(hidden_status == false && first_trigger == true)
            {

                hidden_status = true;            
                first_trigger = false;
            }

            if(hidden_status == false)
            {
                status = 1;
                res = response.UpdateStatus("update_record.php?name=" + name + "&status=" + status);
                img_hide_bttn.SetImageResource(Resource.Drawable.eye_open);
                MakeDishVisible(img_bttn_container);
            }
            else if(hidden_status == true)
            {
                status = 0;  
                res = response.UpdateStatus("update_record.php?name=" + name + "&status=" + status);
                img_hide_bttn.SetImageResource(Resource.Drawable.eye_closed);
                MakeDishHidden(img_bttn_container);
            }

            hidden_status = !hidden_status; // if true = false, if false=true;
            Toast.MakeText(Application.Context, String.Format(res), ToastLength.Short).Show();

        }

        public void MakeDishHidden(RelativeLayout dish_img_bttn_container)
        {
            visible_dishes_page.RemoveView(dish_img_bttn_container);
            hidden_dishes_page.AddView(dish_img_bttn_container);
        }

        public void MakeDishVisible(RelativeLayout dish_img_bttn_container)
        {
            hidden_dishes_page.RemoveView(dish_img_bttn_container);
            visible_dishes_page.AddView(dish_img_bttn_container);
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            // for pop-up modal
            modal_builder.SetTitle(name);
            modal_builder.SetIcon((int)typeof(Resource.Drawable).GetField(img).GetValue(null));
            modal_builder.SetMessage(desc);

            // optional buttons sa pop-up 
            modal_builder.SetPositiveButton("OK", (sender, args) =>
            {
                // Handle OK button click
            });

            Android.App.AlertDialog dialog = modal_builder.Create();
            dialog.Show();
        }
    }
}