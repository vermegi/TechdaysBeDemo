using Cirrious.MvvmCross.Views;
using Moq;
using NUnit.Framework;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Tests.Concerning_Sessions.Given_the_SessionOverviewViewModel
{
    public class When_SessionDetailCommand_gets_called : AaaTest
    {
        private SessionListItemViewModel _sut;
        private int session_id;

        protected override void Arrange()
        {
            var agendaMock = new Mock<IManageAnAgenda>();
            _ioc.RegisterServiceInstance(agendaMock.Object);

            _sut = new SessionListItemViewModel();
            _sut.SessionId = session_id;
        }

        protected override void Act()
        {
            _sut.SessionDetailCommand.Execute(null);
        }

        [Test]
        public void It_should_navigate_to_the_SessionDetailViewModel_with_the_correct_session_id()
        {
            _navigationMock.Verify(nav => nav.RequestNavigate(It.Is<MvxShowViewModelRequest>(req => req.ViewModelType == typeof(SessionDetailViewModel)
                                                                                                    && req.ParameterValues.Keys.Contains("id")
                                                                                                    && req.ParameterValues.Values.Contains(session_id.ToString()))));
        }
    }
}