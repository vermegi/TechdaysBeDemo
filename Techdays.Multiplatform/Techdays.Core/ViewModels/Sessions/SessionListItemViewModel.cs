using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;

namespace Techdays.Core.ViewModels.Sessions
{
    public class SessionListItemViewModel : BaseViewModel,
        IMvxServiceConsumer<IManageAnAgenda>
    {
        private bool _inAgenda;

        public SessionListItemViewModel()
        {
            var agendaService = this.GetService<IManageAnAgenda>();
            
            ViewUnRegistered += (s, e) =>
            {
                if (!HasViews)
                {
                    agendaService.SessionAdded -= HandleSessionAdded(agendaService);
                }
            };

            agendaService.SessionAdded += HandleSessionAdded(agendaService);
        }

        private EventHandler HandleSessionAdded(IManageAnAgenda agendaService)
        {
            return (s, e) => InAgenda = agendaService.IsInAgenda(SessionId);
        }


        public int SessionId { get; set; }

        public string Track { get; set; }

        public int Day { get; set; }

        public DateTime StartTime { get; set; }

        public string StartTimeStr { get { return StartTime.ToString("H:mm"); } }
        public string EndTimeStr { get { return EndTime.ToString("H:mm"); } }

        public DateTime EndTime { get; set; }

        public string Title { get; set; }

        public string ShortTitle
        {
            get
            {
                if (Title.Length < 39)
                    return Title;

                return string.Format("{0} ...", Title.Substring(0, 40));
            }
        }

        public string Speaker { get; set; }

        public string Topic { get; set; }

        public string Room { get; set; }

        public bool InAgenda
        {
            get { return _inAgenda; }
            set
            {
                _inAgenda = value;
                RaisePropertyChanged(() => InAgenda);
            }
        }

        public ICommand SessionDetailCommand
        {
            get
            {
                return new MvxRelayCommand(() => RequestNavigate<SessionDetailViewModel>(new Dictionary<string, object> {{ "id", SessionId }} ));
            }
        }

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

        public IEnumerable<string> Speakers { get; set; }

        public string SpeakerString
        {
            get
            {
                if (Speakers == null)
                    return string.Empty;

                return string.Join(", ", Speakers); 
            }
        }
    }
}