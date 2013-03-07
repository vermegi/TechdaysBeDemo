using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Tests.Concerning_Sessions.Given_the_SessionListViewModel
{
    public class When_we_initialize_the_viewmodel_for_the_first_day : AaaTest
    {
        private SessionListViewModel _sut;
        private Mock<ILoadSessionData> _service;
        private Mock<IListMapper<Session, SessionListItemViewModel>> _mapper;
        private List<Session> _sessionsBeforeMapping;

        protected override void Arrange()
        {
            var agendaMock = new Mock<IManageAnAgenda>();
            _ioc.RegisterServiceInstance(agendaMock.Object);

            _service = new Mock<ILoadSessionData>();
            var sessions = new List<SessionListItemViewModel>
                               {
                                   new SessionListItemViewModel
                                       {
                                           Day = 5,
                                           Track = "dev",
                                           StartTime = DateTime.Parse("9:00"),
                                           EndTime = DateTime.Parse("10:00"),
                                           Title = "yoda",
                                           Speaker = "Obi Wan",
                                           Topic = "Dark Knight"
                                       },
                                   new SessionListItemViewModel
                                       {
                                           Day = 6,
                                           Track = "dev",
                                           StartTime = DateTime.Parse("9:00"),
                                           EndTime = DateTime.Parse("10:00"),
                                           Title = "yoda",
                                           Speaker = "Obi Wan",
                                           Topic = "Dark Knight"
                                       },
                                   new SessionListItemViewModel
                                       {
                                           Day = 5,
                                           Track = "dev",
                                           StartTime = DateTime.Parse("9:00"),
                                           EndTime = DateTime.Parse("10:00"),
                                           Title = "yoda",
                                           Speaker = "Obi Wan",
                                           Topic = "Dark Knight"
                                       },
                                   new SessionListItemViewModel
                                       {
                                           Day = 5,
                                           Track = "dev",
                                           StartTime = DateTime.Parse("10:00"),
                                           EndTime = DateTime.Parse("11:00"),
                                           Title = "yoda",
                                           Speaker = "Obi Wan",
                                           Topic = "Dark Knight"
                                       }
                               };
            _sessionsBeforeMapping = new List<Session>();
            _service.Setup(svc => svc.GetSessions())
                    .Returns(_sessionsBeforeMapping);

            _mapper = new Mock<IListMapper<Session, SessionListItemViewModel>>();
            _mapper.Setup(map => map.Map(It.IsAny<IEnumerable<Session>>()))
                .Returns(sessions);

            _ioc.RegisterServiceInstance(_service.Object);
            _ioc.RegisterServiceInstance(_mapper.Object);
        }

        protected override void Act()
        {
            _sut = new SessionListViewModel(5, "dev");
        }

        [Test]
        public void Should_ask_the_list_of_sessions_from_the_service()
        {
            _service.Verify(svc => svc.GetSessions());
        }

        [Test]
        public void It_should_ask_the_mapper_to_map_these_sessions()
        {
            _mapper.Verify(map => map.Map(_sessionsBeforeMapping));
        }
    }
}