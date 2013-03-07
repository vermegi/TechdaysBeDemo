using Android.App;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Android.Views.SessionTabPages
{
    [Activity]
    public class SessionHomeView : MvxBindingTabActivityView<SessionHomeViewModel>
    {
        protected override void OnCreate(global::Android.OS.Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            
            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Sessions_Page_SessionHome);

            TabHost.TabSpec spec;

            for (int i = 5; i <= 7; i++)
            {
                spec = TabHost.NewTabSpec(string.Format("{0} march", i));
                spec.SetIndicator(string.Format("{0} march", i));
                spec.SetContent(CreateIntentFor(ViewModel.Days[i-5]));
                TabHost.AddTab(spec);                
            }
        }
    }
}