using Moq;
using NUnit.Framework;
using Techdays.Core.Application;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Tests.Concerning_Sessions.Given_the_SessionDetailViewModel
{
    public class When_it_is_initialized : AaaTest
    {
        private SessionDetailViewModel _sut;
        private Mock<ILoadSessionData> _loader;
        private Mock<IMapInPlace<Session, SessionDetailViewModel>>  _mapper;
        private Session _session;

        protected override void Arrange()
        {
            _session = new Session();

            _loader = new Mock<ILoadSessionData>();
            _loader.Setup(l => l.GetSession(It.IsAny<int>())).Returns(_session);

            _mapper = new Mock<IMapInPlace<Session, SessionDetailViewModel>>();

            _ioc.RegisterServiceInstance(_loader.Object);
            _ioc.RegisterServiceInstance(_mapper.Object);
        }

        protected override void Act()
        {
            _sut = new SessionDetailViewModel(5);
        }

        [Test]
        public void It_should_ask_this_session_from_the_loader()
        {
            _loader.Verify(l => l.GetSession(5));
        }

        [Test]
        public void It_should_ask_the_mapper_to_map_the_sessiondetail()
        {
            _mapper.Verify(map => map.Map(_session, _sut));
        }
    }
}