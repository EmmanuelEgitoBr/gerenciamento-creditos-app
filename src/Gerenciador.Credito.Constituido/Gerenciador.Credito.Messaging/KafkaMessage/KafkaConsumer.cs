using Confluent.Kafka;
using Gerenciador.Credito.Domain.Entities;
using Gerenciador.Credito.Messaging.KafkaMessage.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Gerenciador.Credito.Messaging.KafkaMessage;

public class KafkaConsumer : IMessageConsumer, IDisposable
{
    private readonly IConsumer<string, string> _consumer;
    private readonly string _topic;

    public KafkaConsumer(IConfiguration configuration)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = "credito-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };

        _consumer = new ConsumerBuilder<string, string>(config).Build();
        _topic = configuration["Kafka:Topic"]!;

        _consumer.Subscribe(_topic);
    }

    public async Task<CreditoEntity?> ConsumeAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await Task.Run(
                () => _consumer.Consume(cancellationToken),
                cancellationToken);

            if (result?.Message?.Value is null)
                return null;

            var credito = JsonSerializer.Deserialize<CreditoEntity>(
                result.Message.Value);

            _consumer.Commit(result);

            return credito;
        }
        catch (ConsumeException)
        {
            return null;
        }
        catch (OperationCanceledException)
        {
            return null;
        }
    }

    public void Dispose()
    {
        _consumer.Close();
        _consumer.Dispose();
    }
}
