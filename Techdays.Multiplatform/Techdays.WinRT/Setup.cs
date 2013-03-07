using Cirrious.MvvmCross.WinRT.Platform;
using Windows.UI.Xaml.Controls;

namespace Techdays.WinRT
{
    public class Setup : MvxBaseWinRTSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override void InitializeDefaultTextSerializer()
        {
            Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded(true);
        }

        protected override Cirrious.MvvmCross.Application.MvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void AddPluginsLoaders(Cirrious.MvvmCross.Platform.MvxLoaderPluginRegistry loaders)
        {
            loaders.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.ResourceLoader.WinRT.Plugin>();
            loaders.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.File.WinRT.Plugin>();

            base.AddPluginsLoaders(loaders);
        }
    }
}