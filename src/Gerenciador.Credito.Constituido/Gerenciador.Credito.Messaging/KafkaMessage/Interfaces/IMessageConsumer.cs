using Gerenciador.Credito.Domain.Entities;

namespace Gerenciador.Credito.Messaging.KafkaMessage.Interfaces;

public interface IMessageConsumer
{
    Task<CreditoEntity?> ConsumeAsync(CancellationToken cancellationToken = default);
}
