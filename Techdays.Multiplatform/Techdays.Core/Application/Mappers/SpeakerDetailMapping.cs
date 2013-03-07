using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Speakers;

namespace Techdays.Core.Application.Mappers
{
    public class SpeakerDetailMapping : IMapInPlace<Speaker, SpeakerOverviewViewModel>
    {
        public void Map(Speaker speaker, SpeakerOverviewViewModel topvm)
        {
            if (topvm.Speaker == null)
                topvm.Speaker = new SpeakerDetailViewModel();

            var vm = topvm.Speaker;

            vm.Bio = speaker.Bio;
            vm.Blog = speaker.Blog;
            vm.Company = speaker.Company;
            vm.FullName = string.Format("{0} {1}", speaker.FirstName, speaker.LastName);
            vm.SpeakerPicture = speaker.PictureUrl;
            vm.Twitter = speaker.Twitter;
        }
    }
}