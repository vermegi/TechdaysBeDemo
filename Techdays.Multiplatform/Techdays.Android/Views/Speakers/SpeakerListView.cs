using Android.App;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Android.Views.Speakers
{
    [Activity(Label = "Speakers", Icon = "@drawable/speakers_icon")]
    public class SpeakerListView : MvxBindingActivityView<SpeakerListViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Speaker_Page_SpeakerList);
        }
    }
}