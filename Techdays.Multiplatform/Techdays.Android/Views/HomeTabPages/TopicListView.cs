using Android.App;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Android.Views.HomeTabPages
{
    [Activity]
    public class TopicListView : MvxBindingActivityView<TopicListViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Home_TabPage_TopicList);
        }
    }
}