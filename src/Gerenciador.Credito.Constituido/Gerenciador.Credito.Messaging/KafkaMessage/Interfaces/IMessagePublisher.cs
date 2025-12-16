namespace Gerenciador.Credito.Messaging.KafkaMessage.Interfaces;

public interface IMessagePublisher
{
    Task PublishAsync<T>(string topic, T message);
}
