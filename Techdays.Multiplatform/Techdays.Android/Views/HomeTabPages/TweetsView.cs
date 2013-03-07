using Android.App;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels;

namespace Techdays.Android.Views.HomeTabPages
{
    [Activity]
    public class TweetsView : MvxBindingActivityView<TweetsViewModel>
    {
        protected override void OnViewModelSet()
        {
            this.SetContentView(Resource.Layout.Home_TabPage_Tweets);
        }
    }
}