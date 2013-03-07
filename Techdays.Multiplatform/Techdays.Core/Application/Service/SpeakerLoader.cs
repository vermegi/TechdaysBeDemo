using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;

namespace Techdays.Core.Application.Service
{
    public class SpeakerLoader : ILoadSpeakers,
        IMvxServiceConsumer<ILoadTechdaysData>
    {
        private IEnumerable<Speaker> _speakers;

        public IEnumerable<Speaker> GetAll()
        {
            if (_speakers == null)
                LoadSpeakers();

            return _speakers;
        }

        public Speaker GetById(int id)
        {
            if (_speakers == null)
                LoadSpeakers();

            return _speakers.FirstOrDefault(s => s.Id == id);
        }

        private void LoadSpeakers()
        {
            var loader = this.GetService<ILoadTechdaysData>();
            var techdaysEvent = loader.GetEvent();

            _speakers = from data in techdaysEvent.@event.details.speakers.speaker
                        select new Speaker
                                   {
                                       Id = data.id,
                                       Bio = data.bio.cdata,
                                       Blog = data.blog,
                                       Company = data.company,
                                       Email = data.email,
                                       FirstName = data.firstname,
                                       LastName = data.lastname,
                                       HomePage = data.homepage,
                                       LinkedIn = string.Join(", ", data.linkedin),
                                       PictureUrl = data.picture,
                                       Twitter = data.twitter
                                   };
        }
    }
}