using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GROUP7_IT123P_MP
{
    //Randomizer
    internal class Randomizer
    {
        ImageView iv;
        TextView title_tv, desc_tv;
        string[] dish_titles, dish_descs, dish_imgs, dish_ingredients, dish_steps;

        int speed;
        Timer timer;
        Random rand;

        public Randomizer(ImageView iv, TextView dish_title_tv, TextView dish_desc_tv, string[] dish_titles, string[] dish_descs, string[] dish_imgs, string[] dish_ingredients, string[] dish_steps)
        {
            this.iv = iv;
            this.title_tv = dish_title_tv;
            this.desc_tv = dish_desc_tv;
            this.dish_titles = dish_titles;
            this.dish_descs = dish_descs;
            this.dish_imgs = dish_imgs;
            this.dish_ingredients = dish_ingredients;
            this.dish_steps = dish_steps;
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

        private void displayInfo(object sender, ElapsedEventArgs e)
        {
            rand = new Random();
            int cnt = rand.Next(dish_imgs.Length);

            int resourceId = (int)typeof(Resource.Drawable).GetField(dish_imgs[cnt]).GetValue(null);
            iv.SetImageResource(resourceId);
            iv.LayoutParameters.Height = 1200;
            iv.LayoutParameters.Width = 1200;

            title_tv.Text = dish_titles[cnt];
            desc_tv.Text = dish_descs[cnt] + "\n\n" + dish_ingredients[cnt] + "\n" + dish_steps[cnt];

            throw new NotImplementedException();
        }

        //When the app opened
        public void startup()
        {
            rand = new Random();
            int cnt = rand.Next(dish_imgs.Length);

            int resourceId = (int)typeof(Resource.Drawable).GetField(dish_imgs[cnt]).GetValue(null);
            iv.SetImageResource(resourceId);
            iv.LayoutParameters.Height = 1200;
            iv.LayoutParameters.Width = 1200;

            title_tv.Text = dish_titles[cnt];
            desc_tv.Text = dish_descs[cnt] + "\n\n" + dish_ingredients[cnt] + "\n" + dish_steps[cnt];
        }
    }
}