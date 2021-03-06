﻿using System;
using Nybus.Configuration;
using Nybus.Logging;

namespace Nybus.MassTransit
{
    public class MassTransitOptions
    {
        public IQueueStrategy CommandQueueStrategy { get; set; } = new AutoGeneratedNameQueueStrategy();

        public IErrorStrategy CommandErrorStrategy { get; set; } = new RetryErrorStrategy(5);

        public IQueueStrategy EventQueueStrategy { get; set; } = new TemporaryQueueStrategy();

        public IErrorStrategy EventErrorStrategy { get; set; } = new RetryErrorStrategy(5);

        public IServiceBusFactory ServiceBusFactory { get; set; } = new RabbitMqServiceBusFactory(Environment.ProcessorCount);

        public IContextManager ContextManager { get; set; } = new RabbitMqContextManager();

        public ILoggerFactory LoggerFactory { get; set; } = Nybus.Logging.LoggerFactory.Default;
    }
}