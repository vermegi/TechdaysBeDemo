using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;
using Techdays.Core.ViewModels.Sessions;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Core.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        public OverviewViewModel()
        {
            HomeLinks = new List<HomeLinkViewModel>
                            {
                                new HomeLinkViewModel
                                    {
                                        Name = "full program 2013",
                                        LinkCommand = FullProgramCommand,
                                        LinkPicture = "program-icon"
                                    },
                                new HomeLinkViewModel
                                    {
                                        Name = "our speakers",
                                        LinkCommand = SpeakersCommand,
                                        LinkPicture = "speakers-icon"
                                    },
                                new HomeLinkViewModel
                                    {
                                        Name = "practical information",
                                        LinkCommand = PracticalInfoCommand,
                                        LinkPicture = "logo-30x30"
                                    }
                            };
        }

        public List<HomeLinkViewModel> HomeLinks { get; private set; }

        public ICommand FullProgramCommand
        {
            get { return new MvxRelayCommand(() => RequestNavigate<SessionHomeViewModel>(new Dictionary<string, object> { { "track", string.Empty }})); }
        }

        public ICommand SponsorsCommand
        {
            get { return new MvxRelayCommand(() => RequestNavigate<SponsorListViewModel>()); }
        }

        public ICommand SpeakersCommand
        {
            get { return new MvxRelayCommand(() => RequestNavigate<SpeakerListViewModel>()); }
        }

        public ICommand PracticalInfoCommand
        {
            get { return new MvxRelayCommand(() => RequestNavigate<InfoViewModel>()); }
        }
    }
}