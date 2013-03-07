using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Mappers;
using Techdays.Core.Application.Model;
using Techdays.Core.Application.Service;
using Techdays.Core.Application.Service.Dummies;
using Techdays.Core.ViewModels.Sessions;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Core
{
    /// <summary>
    /// Will own the services, viewmodels and other 
    /// classes in the application.
    /// </summary>
    public class App : MvxApplication, IMvxServiceProducer
    {
        public App()
        {
            var startApplicationObject = new StartApplicationObject();

            Cirrious.MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            Cirrious.MvvmCross.Plugins.ResourceLoader.PluginLoader.Instance.EnsureLoaded();
            Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();
            
            this.RegisterServiceInstance<IMvxStartNavigation>(startApplicationObject);

            this.RegisterServiceInstance<ILoadTechdaysData>(new TechdaysLoader());
            this.RegisterServiceInstance<ILoadSessionData>(new SessionLoader());
            this.RegisterServiceInstance<ILoadTopics>(new TopicLoader());
            this.RegisterServiceInstance<ILoadSpeakers>(new SpeakerLoader());
            this.RegisterServiceInstance<IManageAnAgenda>(new DummyAgendaManager());
            this.RegisterServiceInstance<ILoadTweets>(new FileTweetLoader());
            this.RegisterServiceInstance<IListMapper<Session, SessionListItemViewModel>>(new SessionOverviewMapping());
            this.RegisterServiceInstance<IListMapper<Speaker, SpeakerListItemViewModel>>(new SpeakerListItemMapping());
            this.RegisterServiceInstance<IMapInPlace<Session, SessionDetailViewModel>>(new SessionDetailMapping());
            this.RegisterServiceInstance<IMapInPlace<Speaker, SpeakerOverviewViewModel>>(new SpeakerDetailMapping());
        }
    }
}