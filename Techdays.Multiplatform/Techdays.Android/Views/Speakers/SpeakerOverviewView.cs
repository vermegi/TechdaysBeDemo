using Android.App;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Android.Views.Speakers
{
    [Activity]
    public class SpeakerOverviewView : MvxBindingTabActivityView<SpeakerOverviewViewModel>
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

            spec = TabHost.NewTabSpec("Bio");
            spec.SetIndicator("Bio");
            spec.SetContent(CreateIntentFor(ViewModel.Speaker));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("Sessions");
            spec.SetIndicator("Sessions");
            spec.SetContent(CreateIntentFor(ViewModel.Sessions));
            TabHost.AddTab(spec);
        }
    }
}