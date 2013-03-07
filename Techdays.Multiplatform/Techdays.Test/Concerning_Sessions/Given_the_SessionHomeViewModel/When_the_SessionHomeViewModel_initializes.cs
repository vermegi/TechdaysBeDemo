using Cirrious.MvvmCross.Views;
using Moq;
using NUnit.Framework;
using Techdays.Core.ViewModels;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Tests.Concerning_Sessions.Given_the_SessionHomeViewModel
{
    public class When_the_SessionHomeViewModel_initializes : AaaTest
    {
        private SessionHomeViewModel _sut;

        protected override void Arrange()
        {
            _sut = new SessionHomeViewModel("dev");
        }

        protected override void Act()
        {
        }

        //[Test]
        //public void It_should_be_able_to_navigate_to_tuesdays_sessions()
        //{
        //    _sut.ShowTuesdaysDevSessionsCommand.Execute(null);
        //    _navigationMock.Verify(nav => nav.RequestNavigate(It.Is<MvxShowViewModelRequest>(req => req.ViewModelType == typeof(SessionOverviewViewModel) && req.ParameterValues.Keys.Contains("day") && req.ParameterValues.Values.Contains("5"))));
        //}

        //[Test]
        //public void It_should_be_able_to_navigate_to_wednessdays_dev_sessions()
        //{
        //    _sut.ShowWednessdaysDevSessionsCommand.Execute(null);
        //    _navigationMock.Verify(nav => nav.RequestNavigate(It.Is<MvxShowViewModelRequest>(req => req.ViewModelType == typeof(SessionOverviewViewModel) 
        //                                                                                            && req.ParameterValues.Keys.Contains("day") 
        //                                                                                            && req.ParameterValues.Values.Contains("6")
        //                                                                                            && req.ParameterValues.Keys.Contains("track") 
        //                                                                                            && req.ParameterValues.Values.Contains("dev"))));
        //}

        //[Test]
        //public void It_should_be_able_to_navigate_to_thursdays_dev_sessions()
        //{
        //    _sut.ShowThursdaysDevSessionsCommand.Execute(null);
        //    _navigationMock.Verify(nav => nav.RequestNavigate(It.Is<MvxShowViewModelRequest>(req => req.ViewModelType == typeof(SessionOverviewViewModel) 
        //                                                                                            && req.ParameterValues.Keys.Contains("day") 
        //                                                                                            && req.ParameterValues.Values.Contains("7")
        //                                                                                            && req.ParameterValues.Keys.Contains("track") 
        //                                                                                            && req.ParameterValues.Values.Contains("dev"))));
        //}

        //[Test]
        //public void It_should_be_able_to_navigate_to_wednessdays_itpro_sessions()
        //{
        //    _sut.ShowWednessdaysItProSessionsCommand.Execute(null);
        //    _navigationMock.Verify(nav => nav.RequestNavigate(It.Is<MvxShowViewModelRequest>(req => req.ViewModelType == typeof(SessionOverviewViewModel) 
        //                                                                                            && req.ParameterValues.Keys.Contains("day") 
        //                                                                                            && req.ParameterValues.Values.Contains("6")
        //                                                                                            && req.ParameterValues.Keys.Contains("track") 
        //                                                                                            && req.ParameterValues.Values.Contains("itpro"))));
        //}

        //[Test]
        //public void It_should_be_able_to_navigate_to_thursdays_itpro_sessions()
        //{
        //    _sut.ShowThursdaysItProSessionsCommand.Execute(null);
        //    _navigationMock.Verify(nav => nav.RequestNavigate(It.Is<MvxShowViewModelRequest>(req => req.ViewModelType == typeof(SessionOverviewViewModel) 
        //                                                                                            && req.ParameterValues.Keys.Contains("day") 
        //                                                                                            && req.ParameterValues.Values.Contains("7")
        //                                                                                            && req.ParameterValues.Keys.Contains("track") 
        //                                                                                            && req.ParameterValues.Values.Contains("itpro"))));
        //}
    }
}