using Android.App;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Android.Views.SessionTabPages
{
    [Activity]
    public class SessionDetailView : MvxBindingActivityView<SessionDetailViewModel>
    {
        protected override void OnCreate(global::Android.OS.Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Sessions_Page_SessionDetail);
        }
    }
}