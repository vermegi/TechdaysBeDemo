using System.Collections.Generic;
using System.Linq;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Core.Application.Mappers
{
    public class SpeakerListItemMapping : IListMapper<Speaker, SpeakerListItemViewModel>
    {
        public IEnumerable<SpeakerListItemViewModel> Map(IEnumerable<Speaker> speakers)
        {
            var mappedSpeakers = from speaker in speakers
                                 select new SpeakerListItemViewModel
                                            {
                                                Name = string.Format("{0} {1}", speaker.FirstName, speaker.LastName),
                                                PictureUrl = speaker.PictureUrl, 
                                                SpeakerId = speaker.Id
                                            };

            return mappedSpeakers;
        }
    }
}