﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Autofac.Events.Tests
{
    public class EventPublisherTests : UnitTests
    {
        [Fact]
        public void EventPublisherPublishes()
        {
            using (var scope = BeginScope())
            {
                var start = new StartEvent();
                var stop = new StopEvent();
                var pub = scope.Resolve<IEventPublisher>();
                pub.Publish(start);
                pub.Publish(stop);
                var handler = scope.Resolve<InfrastructureEventHandler>();
                Assert.Equal(2, handler.Events.Count);
                Assert.Equal(start, handler.Events[0]);
                Assert.Equal(stop, handler.Events[1]);
            }
        }
    }
}
