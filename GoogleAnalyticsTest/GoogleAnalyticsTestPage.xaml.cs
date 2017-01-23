using System;
using Xamarin.Forms;

namespace GoogleAnalyticsTest
{
    public partial class GoogleAnalyticsTestPage : ContentPage
    {
        private int counter = 0;

        public GoogleAnalyticsTestPage()
        {
            if (Device.OS == TargetPlatform.Android)
            {
                //Track Page
                GASCall.Track_App_Page("Android HomePage");
            }
            //or iOS
            else {
                //Track Page
                GASCall.Track_App_Page("iOS HomePage");
            }

            InitializeComponent();
        }

        public void OnClickButtonGoogleEventMethod(object sender, EventArgs args)
        {
           
            GoogleAnalyticsEvents(GAEventCategory.CountButton, "Button Pressed " + counter++);
            //Navigate();

        }
        public void OnClickButtonExpGoogleEventMethod(object sender, EventArgs args)
        {
            
            int i = 10;
            var data = i / 0;
        }

        //sending event to google analytics
        private void GoogleAnalyticsEvents(string Category, string EventToTrack)
        {
            GASCall.Track_App_Event(Category, EventToTrack);

        }
       


    }
}
