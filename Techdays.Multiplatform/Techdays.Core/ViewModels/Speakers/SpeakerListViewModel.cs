using System.Collections.ObjectModel;
using System.Linq;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Util;

namespace Techdays.Core.ViewModels.Speakers
{
    public class SpeakerListViewModel : BaseViewModel, 
        IMvxServiceConsumer<ILoadSpeakers>, 
        IMvxServiceConsumer<IListMapper<Speaker, SpeakerListItemViewModel>>
    {
        public SpeakerListViewModel()
        {
            var speakerService = this.GetService<ILoadSpeakers>();
            var speakerMapper = this.GetService<IListMapper<Speaker, SpeakerListItemViewModel>>();
            
            var speakers = speakerService.GetAll();

            var mapped = speakerMapper.Map(speakers).ToList();
            var grouped = mapped.OrderBy(sp => sp.Name)
                                .GroupBy(sp => sp.Name[0])
                                .Select(sp => new TimeGroup<SpeakerListItemViewModel>(new ObservableCollection<SpeakerListItemViewModel>(sp), sp.Key.ToString()));

            Speakers = new ObservableCollection<TimeGroup<SpeakerListItemViewModel>>(grouped);

            FlatSpeakers = new ObservableCollection<SpeakerListItemViewModel>(mapped.OrderBy(sp => sp.Name));
        }

        public ObservableCollection<SpeakerListItemViewModel> FlatSpeakers { get; set; }

        public ObservableCollection<TimeGroup<SpeakerListItemViewModel>> Speakers { get; private set; } 
    }
}