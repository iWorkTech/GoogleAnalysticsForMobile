# Mobile app analytics using the Google analytics
This code helps a developer to do the analysis of the mobile application using the google analytics. Google analytics for mobile apps to measure and optimise user acquisition and engagement with mobile apps. 
With easy-to-use SDKs for Android and iOS, helpful classes and methods to track user activities, one can generate useful statistics. It allows user to discover the popular screen or a path of your app which is used mostly by it’s users.  
Google Analytics for Mobile Apps enables you to:
- Understand the number of app users. User’s behaviour and demographic. 
- Customize reports as per your need. 
- Visualize user navigation paths.
- List of app’s most popular devices with their OS versions, brands and screen resolution related information.
- Visualise crash reporting and exception handling.

## Available on 

![icons] (https://thedistance.co.uk/wp-content/uploads/2015/10/ios.android.icon_.jpg)

## Installation and Usage
Import packages for Android and iOS.

### For Android 
Brief:
Using the following code user can track/analyse the following activities.
- Tracking page name
- Tracking event
- Tracking exception

```
using System;
using Android.Content;
using Android.Gms.Analytics;
using Xamarin.Forms;
[assembly: Dependency(typeof(GoogleAnalyticsTest.Droid.GAService))]
namespace GoogleAnalyticsTest.Droid
{
    public class GAService : IGAService
    {
        //replace with your tracking id https://analytics.google.com/
        public string TrackingId = "UA-88590627-1";

        private static GoogleAnalytics GAInstance;
        private static Tracker GATracker;

        #region Instantiation ...
        private static GAService thisRef;
        public GAService()
        {
            // no code req'd
        }

        public static GAService GetGASInstance()
        {
            if (thisRef == null)
                // it's ok, we can call this constructor
                thisRef = new GAService();
            return thisRef;
        }
        #endregion

        public void Initialize_NativeGAS(Context AppContext = null)
        {
            GAInstance = GoogleAnalytics.GetInstance(AppContext.ApplicationContext);
            GAInstance.SetLocalDispatchPeriod(10);
            GATracker = GAInstance.NewTracker(TrackingId);
            GATracker.EnableExceptionReporting(true);
            GATracker.EnableAdvertisingIdCollection(true);
            GATracker.EnableAutoActivityTracking(true);
        }

        public void Track_App_Page(String PageNameToTrack)
        {
            GATracker.SetScreenName(PageNameToTrack);
            GATracker.Send(new HitBuilders.ScreenViewBuilder().Build());
        }

        public void Track_App_Event(String GAEventCategory, String EventToTrack)
        {
            HitBuilders.EventBuilder builder = new HitBuilders.EventBuilder();
            builder.SetCategory(GAEventCategory);
            builder.SetAction(EventToTrack);
            builder.SetLabel("AppEvent");
            GATracker.Send(builder.Build());
        }

        public void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException)
        {
            HitBuilders.ExceptionBuilder builder = new HitBuilders.ExceptionBuilder();
            builder.SetDescription(ExceptionMessageToTrack);
            builder.SetFatal(isFatalException);
            GATracker.Send(builder.Build());
        }
    }

}
```

Using the above code, you can view the following results on Google Analytics

![Fig1] (http://52.77.35.210:83/Media/Default/images/githubimages/Google%20Analytic_Fig1.png)

Fig 1- Overview with active users, active screens and app versions

![Fig2] (http://52.77.35.210:83/Media/Default/images/githubimages/Google%20Analytic_Fig2.png)

Fig 2- Tracking events with category, action and active users.

![Fig3] (http://52.77.35.210:83/Media/Default/images/githubimages/Google%20Analytic_Fig3.png)

Fig 2- Tracking crashes and exceptions.


### For iOS 
Brief:
Using the following code user can track/analyse the following activities.
- Tracking screen (Page) name
- Tracking event
- Tracking exception

```
using System;
using Foundation;
using Google.Analytics;
using Xamarin.Forms;
[assembly: Dependency(typeof(GoogleAnalyticsTest.iOS.GAService))]
namespace GoogleAnalyticsTest.iOS
{
    public class GAService : IGAService
    {
        //replace with your tracking id https://analytics.google.com/
        public string TrackingId = "UA-88590627-1";
        public ITracker Tracker;
        const string AllowTrackingKey = "AllowTracking";

        #region Instantition...
        private static GAService thisRef;
        public GAService()
        {
            // no code req'd
        }

        public static GAService GetGASInstance()
        {
            if (thisRef == null)
                // it's ok, we can call this constructor
                thisRef = new GAService();
            return thisRef;
        }
        #endregion

        public void Initialize_NativeGAS()
        {
            var optionsDict = NSDictionary.FromObjectAndKey(new NSString("YES"), new NSString(AllowTrackingKey));
            NSUserDefaults.StandardUserDefaults.RegisterDefaults(optionsDict);

            Gai.SharedInstance.OptOut = !NSUserDefaults.StandardUserDefaults.BoolForKey(AllowTrackingKey);

            Gai.SharedInstance.DispatchInterval = 10;
            Gai.SharedInstance.TrackUncaughtExceptions = true;

            Tracker = Gai.SharedInstance.GetTracker("Test App", TrackingId);
        }

        public void Track_App_Page(String PageNameToTrack)
        {
            Gai.SharedInstance.DefaultTracker.Set(GaiConstants.ScreenName, PageNameToTrack);
            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateScreenView().Build());
        }

        public void Track_App_Event(String GAEventCategory, String EventToTrack)
        {
            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateEvent(GAEventCategory, EventToTrack, "AppEvent", null).Build());
            Gai.SharedInstance.Dispatch(); // Manually dispatch the event immediately
        }

        public void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException)
        {
            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateException(ExceptionMessageToTrack, isFatalException).Build());
        }
    }
}

```

## To get this code readymade take the following steps:

- Step 1 - Create account on Google analytics
- Step 2 - Copy google analytics tracking ID (e.g.: UA-xxxxxxxx-1)

![Fig4] (http://52.77.35.210:83/Media/Default/images/githubimages/Google%20Analytic_Fig4.png)

- Step 3 - Go to GitHub, Down load code using URL: https://github.com/iWorkTech
- Step 4- Unzip the code and open the solution file in Visual Studio.
- Step 5 – Replace Tracking ID with yours google analytics tracking ID.
- Step 6 – Run the code.
