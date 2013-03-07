using Cirrious.MvvmCross.WindowsPhone.Views;
using Techdays.Core.ViewModels.Sessions;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.WP8.Views
{
    public partial class SpeakerListView : BaseSpeakerListView
    {
        public SpeakerListView()
        {
            InitializeComponent();
        }
    }

    public class BaseSpeakerListView : MvxPhonePage<SpeakerListViewModel>
    {}
}