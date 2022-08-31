using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppHotel.Model
{
    public class Suite : ContentPage
    {
        public Suite()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}