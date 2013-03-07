using Cirrious.MvvmCross.Console.Platform;
using Cirrious.MvvmCross.Interfaces.IoC;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.Views;
using Cirrious.MvvmCross.IoC;
using Cirrious.MvvmCross.OpenNetCfIoC;
using Cirrious.MvvmCross.Platform;
using Moq;
using NUnit.Framework;

namespace Techdays.Tests
{
    public abstract class AaaTest
    {
        protected IMvxServiceProviderRegistry _ioc;
        protected Mock<IMvxViewDispatcher> _navigationMock;
        protected Mock<IMvxViewDispatcherProvider> _navigationDispatcherMock;

        [SetUp]
        public void Setup()
        {
            RegisterCoreServices();

            RegisterMockNavigationServices();

            Arrange();
            Act();
        }

        private void RegisterMockNavigationServices()
        {
            _navigationDispatcherMock = new Mock<IMvxViewDispatcherProvider>();
            _navigationMock = new Mock<IMvxViewDispatcher>();
            _navigationDispatcherMock.Setup(disp => disp.Dispatcher)
                                     .Returns(_navigationMock.Object);

            _ioc.RegisterServiceInstance(_navigationMock.Object);
            _ioc.RegisterServiceInstance(_navigationDispatcherMock.Object);
        }

        private void RegisterCoreServices()
        {
            MvxOpenNetCfContainer.ClearAllSingletons();
            IMvxIoCProvider serviceProvider = new MvxSimpleIoCServiceProvider();
            _ioc = new MvxServiceProvider(serviceProvider);
            _ioc.RegisterServiceInstance(_ioc);
            _ioc.RegisterServiceInstance<IMvxServiceProvider>(_ioc);
            _ioc.RegisterServiceInstance(new MvxDebugTrace());
        }

        protected abstract void Arrange();
        protected abstract void Act();
    }
}