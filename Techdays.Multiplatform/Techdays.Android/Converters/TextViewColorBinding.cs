using System;
using Android.Graphics;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Target;
using Cirrious.MvvmCross.Binding.Interfaces;

namespace Techdays.Android.Converters
{
    public class TextViewColorBinding : MvxBaseAndroidTargetBinding
    {
        private readonly TextView _textView;

        public TextViewColorBinding(TextView textView)
        {
            _textView = textView;
        }

        public override void SetValue(object value)
        {
            var colorValue = (Color)value;
            _textView.SetTextColor(colorValue);
        }

        public override Type TargetType
        {
            get { return typeof(Color); }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }
    }
}