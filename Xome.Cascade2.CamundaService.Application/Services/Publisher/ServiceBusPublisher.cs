using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;

namespace Xome.Cascade2.CamundaService.Application.Services
{
    public  class ServiceBusPublisher
    {

        private readonly ServiceBusSettings _settings;
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;

        public ServiceBusPublisher(IOptions<ServiceBusSettings> options)
        {
            _settings = options.Value;
            _client = new ServiceBusClient(_settings.ConnectionString);
            _sender = _client.CreateSender(_settings.QueueName);
        }

        public async Task SendMessageAsync(string messageBody)
        {
            ServiceBusMessage message = new ServiceBusMessage(messageBody);
            await _sender.SendMessageAsync(message);
        }
    }
}
