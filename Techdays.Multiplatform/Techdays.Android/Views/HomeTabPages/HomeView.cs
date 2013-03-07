using Android.App;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels;

namespace Techdays.Android.Views.HomeTabPages
{
    [Activity(Label = "Techdays")]
    public class HomeView : MvxBindingTabActivityView<HomeViewModel>
    {
        protected override void OnCreate(global::Android.OS.Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Home_Page_HomeView);

            TabHost.TabSpec spec;

            spec = TabHost.NewTabSpec("Overview");
            spec.SetIndicator("Overview");
            spec.SetContent(CreateIntentFor(ViewModel.Overview));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("Topics");
            spec.SetIndicator("Topics");
            spec.SetContent(CreateIntentFor(ViewModel.Topics));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("Tweets");
            spec.SetIndicator("Tweets");
            spec.SetContent(CreateIntentFor(ViewModel.Tweets));
            TabHost.AddTab(spec);
            
            //spec = TabHost.NewTabSpec("Upcoming Sessions");
            //spec.SetIndicator("Upcoming Sessions");
            //spec.SetContent(CreateIntentFor(ViewModel.UpcomingSessions));
            //TabHost.AddTab(spec);
        }
    }
}