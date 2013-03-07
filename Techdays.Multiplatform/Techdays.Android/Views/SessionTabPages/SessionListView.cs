using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Android.Content;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Techdays.Core.ViewModels.Sessions;
using Techdays.Core.ViewModels.Util;
using Object = Java.Lang.Object;

namespace Techdays.Android.Views.SessionTabPages
{
    [Activity]
    public class SessionListView : MvxBindingActivityView<SessionListViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Sessions_TabPage_SessionList);

            var sessionListView = FindViewById<MvxBindableListView>(Resource.Id.listviewArticle);
            sessionListView.Adapter = new GroupedListAdapter(this);
        }
    }

    public class GroupedListAdapter : MvxBindableListAdapter
    {
        private Object[] _sectionHeaders;
        private List<int> _sectionLookup;
        private List<int> _reverseSectionLookup;

        public GroupedListAdapter(Context context) : base(context)
        {
        }

        protected override void SetItemsSource(IEnumerable list)
        {
            var groupedList = list as ObservableCollection<TimeGroup<SessionListItemViewModel>>;

            if (groupedList == null)
            {
                _sectionHeaders = null;
                _sectionLookup = null;
                _reverseSectionLookup = null;
                base.SetItemsSource(null);
                return;
            }

            var flattened = new List<object>();
            _sectionLookup = new List<int>();
            _reverseSectionLookup = new List<int>();
            var sectionHeaders = new List<string>();

            var groupsSoFar = 0;
            foreach (var group in groupedList)
            {
                _sectionLookup.Add(flattened.Count);
                var groupHeader = group.Title;
                sectionHeaders.Add(groupHeader);
                for (int i = 0; i <= group.Count; i++)
                    _reverseSectionLookup.Add(groupsSoFar);

                flattened.Add(groupHeader);
                flattened.AddRange(group.Select(x => (object)x));

                groupsSoFar++;
            }

            _sectionHeaders = CreateJavaStringArray(sectionHeaders.Select(x => x.Length > 10 ? x.Substring(0, 10) : x).ToList());

            base.SetItemsSource(flattened);
        }

        public int GetPositionForSection(int section)
        {
            if (_sectionLookup == null)
                return 0;

            return _sectionLookup[section];
        }

        public int GetSectionForPosition(int position)
        {
            if (_reverseSectionLookup == null)
                return 0;

            return _reverseSectionLookup[position];
        }

        public Java.Lang.Object[] GetSections()
        {
            return _sectionHeaders;
        }

        private static Java.Lang.Object[] CreateJavaStringArray(List<string> inputList)
        {
            if (inputList == null)
                return null;

            var toReturn = new Java.Lang.Object[inputList.Count];
            for (var i = 0; i < inputList.Count; i++)
            {
                toReturn[i] = new Java.Lang.String(inputList[i]);
            }

            return toReturn;
        }

        protected override global::Android.Views.View GetBindableView(global::Android.Views.View convertView, object source, int templateId)
        {
            if (source is SessionListItemViewModel)
                return base.GetBindableView(convertView, source, Resource.Layout.Sessions_item_session);
            else
                return base.GetBindableView(convertView, source, Resource.Layout.Sessions_item_timeslot);
        }

    }
}