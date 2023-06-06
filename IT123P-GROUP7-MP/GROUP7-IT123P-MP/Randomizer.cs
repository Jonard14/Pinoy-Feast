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
        string[] dish_descs, dish_imgs;

        int speed;
        Timer timer;
        Random rand;

        public Randomizer(ImageView iv, TextView dish_title_tv, TextView dish_desc_tv, string[] dish_descs, string[] dish_imgs)
        {
            this.iv = iv;
            this.title_tv = dish_title_tv;
            this.desc_tv = dish_desc_tv;
            this.dish_descs = dish_descs;
            this.dish_imgs = dish_imgs;
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
            rand = new System.Random();
            int cnt = rand.Next(dish_imgs.Length);

            int resourceId = (int)typeof(Resource.Drawable).GetField(dish_imgs[cnt]).GetValue(null);
            iv.SetImageResource(resourceId);
            iv.LayoutParameters.Height = 1200;
            iv.LayoutParameters.Width = 1200;

            title_tv.Text = dish_imgs[cnt];
            desc_tv.Text = dish_descs[cnt];

            throw new NotImplementedException();
        }
    }
}