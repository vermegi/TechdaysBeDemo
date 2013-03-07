using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Core.ViewModels.Sessions
{
    public class SessionDetailViewModel : BaseViewModel, 
        IMvxServiceConsumer<ILoadSessionData>, 
        IMvxServiceConsumer<IMapInPlace<Session, SessionDetailViewModel>>,
        IMvxServiceConsumer<IManageAnAgenda>
    {
        private bool _inAgenda;

        public SessionDetailViewModel(int id)
        {
            var service = this.GetService<ILoadSessionData>();
            var session = service.GetSession(id);

            var mapper = this.GetService<IMapInPlace<Session, SessionDetailViewModel>>();
            mapper.Map(session, this);
        }

        public SessionDetailViewModel()
        {
        }

        public int SessionId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Speaker { get; set; }
        public int SpeakerId { get; set; }
        public string SpeakerPicture { get; set; }

        public string Title { get; set; }

        public int Day { get; set; }

        public string Description { get; set; }

        public string Topic { get; set; }

        public string Room { get; set; }

        public string FullTimeSlot
        {
            get { return string.Format("{0} March {1} - {2}", Day, StartTime.ToString("H:mm"), EndTime.ToString("H:mm")); }
        }

        public bool InAgenda
        {
            get { return _inAgenda; }
            set { _inAgenda = value; RaisePropertyChanged(() => InAgenda); }
        }

        public ICommand SpeakerDetailCommand { get { return new MvxRelayCommand(() => RequestNavigate<SpeakerOverviewViewModel>(new Dictionary<string, object> { { "id", SpeakerId }})); } }

        public ICommand AddToAgenda
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    var agendaManager = this.GetService<IManageAnAgenda>();
                    InAgenda = true;
                    agendaManager.Add(SessionId);
                });
            }
        }

        public IEnumerable<SpeakerBase> Speakers { get; set; }
    }
}