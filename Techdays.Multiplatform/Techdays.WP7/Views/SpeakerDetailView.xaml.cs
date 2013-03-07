using Cirrious.MvvmCross.WindowsPhone.Views;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.WP7.Views
{
    public partial class SpeakerDetailView : BaseSpeakerDetailView
    {
        public SpeakerDetailView()
        {
            InitializeComponent();
        }
    }

    public class BaseSpeakerDetailView : MvxPhonePage<SpeakerOverviewViewModel>
    {
        
    }
}