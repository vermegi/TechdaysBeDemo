using Android.Content;
using Android.Widget;
using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Binding.Droid;
using Techdays.Android.Converters;
using Techdays.Core;

namespace Techdays.Android
{
    public class Setup : MvxBaseAndroidBindingSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override Cirrious.MvvmCross.Application.MvxApplication CreateApp()
        {
            return new App();
        }

        protected override System.Collections.Generic.IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                var toReturn = base.ViewNamespaceAbbreviations;
                toReturn["Techdays"] = "Techdays.Android.Controls";
                return toReturn;
            }
        }

        protected override System.Collections.Generic.IEnumerable<System.Type> ValueConverterHolders
        {
            get
            {
                return new[]{typeof(MyConverters)};
            }
        }

        protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Interfaces.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterFactory(new MvxCustomBindingFactory<TextView>("TextColor", tv => new TextViewColorBinding(tv)));
        }
    }
}