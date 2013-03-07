using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Core.Application.Mappers
{
    public class SessionDetailMapping : IMapInPlace<Session, SessionDetailViewModel>,
                IMvxServiceConsumer<IManageAnAgenda>
    {
        public void Map(Session session, SessionDetailViewModel vm)
        {
            vm.SessionId = session.Id;
            vm.StartTime = session.StartTime;
            vm.EndTime = session.EndTime;
            vm.Speaker = session.Speaker;
            vm.SpeakerPicture = session.SpeakerPicture;
            vm.SpeakerId = session.SpeakerId;
            vm.Speakers = session.Speakers;
            vm.Title = session.Title;
            vm.Day = session.Day;
            vm.Description = session.Description;
            vm.Topic = session.Topics != null ? string.Join(", ", session.Topics) : string.Empty;
            vm.Room = session.Room;

            var agendaService = this.GetService<IManageAnAgenda>();
            vm.InAgenda = agendaService.IsInAgenda(session.Id);
        }
    }
}