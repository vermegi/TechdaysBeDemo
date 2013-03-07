using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Plugins.Json;
using Cirrious.MvvmCross.Plugins.ResourceLoader;
using Techdays.Core.Application.Interfaces;

namespace Techdays.Core.Application.Service
{
    public class TechdaysLoader : ILoadTechdaysData, 
                                  IMvxServiceConsumer<IMvxResourceLoader>,
                                  IMvxServiceConsumer<IMvxJsonConverter>

    {
        private TopXml _event;

        public TopXml GetEvent()
        {
            if (_event == null)
            {
                var loader = this.GetService<IMvxResourceLoader>();
                var jsonSessions = loader.GetTextResource("sessions.json");
                var jsonConvert = this.GetService<IMvxJsonConverter>();
                _event = jsonConvert.DeserializeObject<TopXml>(jsonSessions);
            }

            return _event;
        }
    }
}