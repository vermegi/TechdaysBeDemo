using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Techdays.WP8.Controls
{
    public partial class TechdaysButton : UserControl
    {
        public TechdaysButton()
        {
            InitializeComponent();
        }

        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty FillProperty =
        DependencyProperty.Register("Fill", typeof(Brush), typeof(TechdaysButton),
                                    new PropertyMetadata(new SolidColorBrush(Colors.Blue), OnFillChanged));

        private static void OnFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (TechdaysButton) d;
            parent.BackgroundRec.Fill = (Brush) e.NewValue;
        }

        public bool Wide
        {
            get { return (bool)GetValue(WideProperty); }
            set { SetValue(WideProperty, value); }
        }

        public static readonly DependencyProperty WideProperty =
                DependencyProperty.Register("Wide", typeof(bool), typeof(TechdaysButton),
                                            new PropertyMetadata(false, OnWideChanged));

        private static void OnWideChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (TechdaysButton)d;
            parent.Width = 330;
            parent.BackgroundRec.Width = 330;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TechdaysButton),
                                        new PropertyMetadata(null, OnTextChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (TechdaysButton)d;
            parent.MainText.Text = (string)e.NewValue;
        }

        public string SubText
        {
            get { return (string)GetValue(SubTextProperty); }
            set { SetValue(SubTextProperty, value); }
        }

        public static readonly DependencyProperty SubTextProperty =
            DependencyProperty.Register("SubText", typeof(string), typeof(TechdaysButton),
                                        new PropertyMetadata(null, OnSubTextChanged));

        private static void OnSubTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (TechdaysButton)d;
            parent.SubberText.Text = (string)e.NewValue;
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(TechdaysButton), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(TechdaysButton), new PropertyMetadata(null));



        private void OnTap(object sender, GestureEventArgs e)
        {
            if (Command == null)
                return;

            Command.Execute(CommandParameter);
        }

    }
}
