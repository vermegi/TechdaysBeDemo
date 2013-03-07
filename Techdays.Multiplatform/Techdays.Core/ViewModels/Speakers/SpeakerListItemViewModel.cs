using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;

namespace Techdays.Core.ViewModels.Speakers
{
    public class SpeakerListItemViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public ICommand SpeakerDetailCommand
        {
            get
            {
                return
                    new MvxRelayCommand(
                        () =>
                        RequestNavigate<SpeakerOverviewViewModel>(new Dictionary<string, object> {{"id", SpeakerId}}));
            }
        }

        public int SpeakerId { get; set; }
    }
}