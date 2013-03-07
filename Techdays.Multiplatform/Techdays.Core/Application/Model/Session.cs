using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;
using Techdays.Core.Application.Service;
using Techdays.Core.ViewModels;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Core.Application.Model
{
    public class Session
    {
        public int Day { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Speaker { get; set; }

        public string Title { get; set; }
        
        public string Track { get; set; }

        public IEnumerable<string> Topics { get; set; }

        public int Id { get; set; }

        public string SpeakerPicture { get; set; }

        public string Description { get; set; }

        public int SpeakerId { get; set; }

        public string Room { get; set; }

        public IEnumerable<SpeakerBase> Speakers { get; set; } 
    }

    public class SpeakerBase : BaseViewModel
    {
        public SpeakerBase(int id, string fullname, string picture)
        {
            Id = id;
            Fullname = fullname;
            Picture = picture;
        }

        public string Picture { get; set; }

        public string Fullname { get; set; }

        public int Id { get; set; }

        public ICommand SpeakerDetailCommand { get { return new MvxRelayCommand(() => RequestNavigate<SpeakerOverviewViewModel>(new Dictionary<string, object> { { "id", Id }})); } }
    }
}