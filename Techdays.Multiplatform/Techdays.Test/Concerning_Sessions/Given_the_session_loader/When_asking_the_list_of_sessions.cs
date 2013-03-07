using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Json;
using Cirrious.MvvmCross.Plugins.ResourceLoader;
using Moq;
using NUnit.Framework;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.Application.Service;

namespace Techdays.Tests.Concerning_Sessions.Given_the_session_loader
{
    public class When_asking_the_list_of_sessions : AaaTest
    {
        private SessionLoader _sut;
        private IEnumerable<Session> _sessions;

        protected override void Arrange()
        {
            var rdr = File.OpenText("sessions.json");
            var json = rdr.ReadToEnd();
            rdr.Close();

            var loaderMock = new Mock<IMvxResourceLoader>();
            loaderMock.Setup(l => l.GetTextResource(It.IsAny<string>()))
                .Returns(json);

            _ioc.RegisterServiceInstance(loaderMock.Object);
            _ioc.RegisterServiceType<ILoadTechdaysData, TechdaysLoader>();
            _ioc.RegisterServiceType<IMvxJsonConverter, MvxJsonConverter>();

            _sut = new SessionLoader();
        }

        protected override void Act()
        {
            _sessions = _sut.GetSessions();
        }

        [Test]
        public void Should_load_the_session_data_in_the_sessions()
        {
            Assert.IsNotNull(_sessions);
        }

        [Test]
        public void All_the_sessions_should_be_in_the_sessionlist()
        {
            Assert.AreEqual(84, _sessions.Count());
        }

        [Test]
        public void The_sessions_should_be_filles_with_data()
        {
            var firstSession = _sessions.First();

            Assert.AreNotEqual(0, firstSession.Day);
            Assert.IsTrue(firstSession.StartTime > DateTime.MinValue);
            Assert.IsTrue(firstSession.EndTime > DateTime.MinValue);
            Assert.IsNotNullOrEmpty(firstSession.Description);
            Assert.AreNotEqual(0, firstSession.Id);
        }
    }
}