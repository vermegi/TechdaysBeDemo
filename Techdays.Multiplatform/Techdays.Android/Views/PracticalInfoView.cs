using System.Collections.Generic;
using Android.App;
using Android.GoogleMaps;
using Android.Graphics.Drawables;
using Android.Views;
using Cirrious.MvvmCross.Droid.Maps;
using Techdays.Core.ViewModels;

namespace Techdays.Android.Views
{
    [Activity]
    public class PracticalInfoView : MvxBindingMapActivityView<InfoViewModel>
    {
        protected override void OnCreate(global::Android.OS.Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.PracticalInfo_Page);

            var map = FindViewById<MapView>(Resource.Id.map);

            map.Clickable = true;
            map.Traffic = false;
            map.Satellite = true;

            map.SetBuiltInZoomControls(true);
            map.Controller.SetZoom(15);
            var point = new GeoPoint((int)(ViewModel.Latitude * 1e6), (int)(ViewModel.Longitude * 1e6));
            map.Controller.SetCenter(point);

            AddPinOverlay(map, point);
        }

        private void AddPinOverlay(MapView map, GeoPoint point)
        {
            var pin = Resources.GetDrawable(Resource.Drawable.Icon);
            var pinOverlay = new MapPinOverlay(pin, point);
            map.Overlays.Add(pinOverlay);
        }

        protected override bool IsRouteDisplayed
        {
            get { return false; }
        }
    }

    class MapPinOverlay : ItemizedOverlay
    {
        readonly List<OverlayItem> _pins;

        public MapPinOverlay(Drawable pin, GeoPoint point)
            : base(pin)
        {
            // populate some sample location data for the overlay items
            _pins = new List<OverlayItem>{
                    new OverlayItem (point, null, null),
                };

            BoundCenterBottom(pin);
            Populate();
        }

        protected override Java.Lang.Object CreateItem(int i)
        {
            var item = _pins[i];
            return item;
        }

        public override int Size()
        {
            return _pins.Count;
        }
    }

}