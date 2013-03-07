using Android.App;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Android.Views.Speakers
{
    [Activity]
    public class SpeakerDetailView : MvxBindingActivityView<SpeakerDetailViewModel>
    {
        protected override void OnCreate(global::Android.OS.Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Speaker_TabPage_Bio);
        }
    }
}