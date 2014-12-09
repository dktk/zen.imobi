using Base.Domain;
using Ninject;
using Ploeh.AutoFixture.Xunit;
using System;
using Xunit;
using Xunit.Extensions;

namespace Base.Tests.Domain
{
    internal class EventHandler : IEventHandler<SpecialEvent>
    {
        public static string Value { get; set; }

        public void Handle(SpecialEvent @event)
        {
            Value = @event.Value;
        }
    }

    internal class SpecialEvent: Event
    {
        public string Value { get; set; }

        public SpecialEvent(string value)
            : base(Guid.NewGuid())
        {
            Value = value;
        }
    }

    public class EventBusTests
    {
        [Theory]
        [AutoData]
        public void Publish(string value)
        {
            var kernel = new StandardKernel();
            kernel.Bind<EventHandler>().To<EventHandler>();

            /// TODO: can we moq this?
            /// 
            var bus = new EventBus(kernel);
            bus.Register<SpecialEvent, EventHandler>();
            bus.Publish(new SpecialEvent(value));

            Assert.Equal(value, EventHandler.Value);
        }
    }
}
