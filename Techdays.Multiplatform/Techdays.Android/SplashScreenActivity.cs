using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace Techdays.Android
{
    [Activity(Label = "Techdays", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class SplashScreenActivity : MvxBaseSplashScreenActivity
    {
        public SplashScreenActivity() : base(Resource.Layout.SplashScreen)
        {
        }

		protected override void OnViewModelSet ()
		{
			// ignored
		}
    }
}