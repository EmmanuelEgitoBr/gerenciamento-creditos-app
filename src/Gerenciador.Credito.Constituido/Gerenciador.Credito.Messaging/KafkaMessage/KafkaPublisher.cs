using Confluent.Kafka;
using Gerenciador.Credito.Messaging.KafkaMessage.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Gerenciador.Credito.Messaging.KafkaMessage
{
    public class KafkaPublisher : IMessagePublisher
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _defaultTopic;

        public KafkaPublisher(IConfiguration configuration)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                Acks = Acks.All,
                EnableIdempotence = true
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
            _defaultTopic = configuration["Kafka:Topic"]!;
        }

        public async Task PublishAsync<T>(string topic, T message)
        {
            var json = JsonSerializer.Serialize(message);

            await _producer.ProduceAsync(
                topic ?? _defaultTopic,
                new Message<string, string>
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = json
                });
        }
    }
}
