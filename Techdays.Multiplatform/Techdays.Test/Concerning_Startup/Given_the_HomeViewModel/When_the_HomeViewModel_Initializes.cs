using Moq;
using NUnit.Framework;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.ViewModels;

namespace Techdays.Tests.Concerning_Startup.Given_the_HomeViewModel
{
    public class When_the_HomeViewModel_Initializes : AaaTest
    {
        private HomeViewModel _sut;

        protected override void Arrange()
        {
            var tweetMock = new Mock<ILoadTweets>();
            _ioc.RegisterServiceInstance(tweetMock.Object);

            var service = new Mock<ILoadTopics>();
            _ioc.RegisterServiceInstance(service.Object);
        }

        protected override void Act()
        {
            _sut = new HomeViewModel();
        }

        [Test]
        public void It_should_initialize_the_viewmodels_to_which_we_can_navigate()
        {
            Assert.IsNotNull(_sut.Overview);
            Assert.IsNotNull(_sut.Topics);
            Assert.IsNotNull(_sut.UpcomingSessions);
            Assert.IsNotNull(_sut.Tweets);
        }

        [Test]
        public void It_should_initialize_the_appname()
        {
            Assert.IsNotNull(_sut.AppName);
        }
    }
}