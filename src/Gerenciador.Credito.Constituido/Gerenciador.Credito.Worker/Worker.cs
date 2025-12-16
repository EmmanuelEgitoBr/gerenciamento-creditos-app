using Gerenciador.Credito.Domain.Interfaces;
using Gerenciador.Credito.Messaging.KafkaMessage.Interfaces;

namespace Gerenciador.Credito.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMessageConsumer _consumer;

        public Worker(ILogger<Worker> logger
            ,IServiceScopeFactory scopeFactory
            ,IMessageConsumer consumer
            )
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var credito = await _consumer.ConsumeAsync();

                if (credito != null)
                {
                    using var scope = _scopeFactory.CreateScope();
                    var creditoRepository = scope.ServiceProvider.GetRequiredService<ICreditoRepository>();

                    if (!await creditoRepository.ExistsAsync(credito.NumeroCredito))
                        await creditoRepository.AddAsync(credito);
                }
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
