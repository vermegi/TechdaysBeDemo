using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Java.Lang;
using Techdays.Android.Views.SessionTabPages;
using Techdays.Core.ViewModels.Sessions;
using Techdays.Core.ViewModels.Speakers;
using Techdays.Core.ViewModels.Util;

namespace Techdays.Android.Views.Speakers
{
    [Activity]
    public class SpeakerSessionsView : MvxBindingActivityView<SpeakerSessionsViewModel>
    {
        protected override void OnCreate(global::Android.OS.Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Speaker_TabPage_Sessions );

            var sessionListView = FindViewById<MvxBindableListView>(Resource.Id.listviewArticle);
            sessionListView.Adapter = new GroupedListAdapter(this);
        }
    }
}